const User = require("../models/User");
const bcrypt = require("bcrypt");
const jwt = require('jsonwebtoken');

const authController = {
    //REGISTER
    registerUser: async (req, res) => {
        try {
            const existingUser = await User.findOne({
                $or: [{ username: req.body.userName }, { email: req.body.email }],
            });
            

            if (existingUser) {
                return res.status(400).json({
                    success: false,
                    message: 'Username or email already exists',
                    data: {},
                });
            }
            console.log("Found existing user:", existingUser);

            console.log(req.body);
            if (!req.body.userPassword) {
                return res.status(400).json({
                    success: false,
                    message: 'Password is required',
                    data: {},
                });
            }
            console.log("Password received:", req.body.userPassword);
            const salt = await bcrypt.genSalt(10);
            const hashed = await bcrypt.hash(req.body.userPassword, salt);
            console.log("Password received (after hashed):", hashed);
            //Create new user
            const newUser = await new User({
                name: req.body.name,
                userName: req.body.userName,
                email: req.body.email,
                userPassword: hashed,
            });

            //Save user to DB
            const user = await newUser.save();

            const { userPassword, ...others } = user._doc;

            res.status(200).json({
                success: true,
                message: 'Register successfully !',
                data: others
            });
        } catch (err) {
            console.log(err);
            if (err.code === 11000) {
                res.status(400).json({
                    success: false,
                    message: 'A user with that username or email already exists.',
                    data: {}
                });
            } else {
                res.status(500).json({
                    success: false,
                    message: 'Internal Server Error',
                    data: {}
                });
            }
        }
    },

    //LOGIN
    loginUser: async (req, res) => {
        try {
            // Find the user by either username or email
            console.log("Attempting to log in with:", req.body.email);
            const user = await User.findOne({
                $or: [
                    { userName: req.body.emailOrUserName },
                    { email: req.body.emailOrUserName }
                ]
            });

            console.log("Found user:", user);
            if (!user) {
                return res.status(404).json({
                    success: false,
                    message: "User not found",
                    data: {}
                });
            }

            const validPassword = await bcrypt.compare(
                req.body.userPassword,
                user.userPassword
            );
            console.log("Password valid?", validPassword);

            if (!validPassword) {
                return res.status(404).json({
                    success: false,
                    message: "Incorrect password",
                    data: {}
                });
            }

            if (user && validPassword) {
                // User is authenticated, create a token
                const token = jwt.sign(
                    { id: user._id }, // payload could include user id
                    process.env.JWT_SECRET, // Secret for signing the token
                    { expiresIn: '24h' } // Set the expiration time for the token
                );
                if (!process.env.JWT_SECRET) {
                    console.error('FATAL ERROR: JWT_SECRET is not defined');
                }
                // Exclude password and other sensitive info from the response
                const { userPassword, ...userWithoutPassword } = user._doc;

                return res.status(200).json({
                    success: true,
                    message: "Login successfully!",
                    token, // Send the token to the client
                    data: userWithoutPassword // Send user data without the password
                });
            } else {
                // Handle wrong credentials
                return res.status(400).json({
                    success: false,
                    message: "Incorrect username or password"
                });
            }
        } catch (err) {
            return res.status(500).json({
                success: false,
                message: "Internal Server Error",
                data: {}
            });
        }
    },
};

module.exports = authController;