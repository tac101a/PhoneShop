const User = require('../models/User');

const userController = {
    getAllUsers: async (req, res) => {
        try {
            const users = await User.find();

            res.status(200).json({
                success: true,
                message: 'Get all Users successfully!',
                data: users
            });
        } catch (err) {
            res.status(500).json({
                success: false,
                message: err.message,
                data: []
            });
        }
    },

    getUserById: async (req, res) => {
        try {
            const id = req.params.id;

            const user = await User.findById(id);

            res.status(200).json({
                success: true,
                message: 'Get user successfully!',
                data: user
            });
        } catch (err) {
            res.status(500).json({
                success: false,
                message: err.message,
                data: {}
            });
        }
    },

    createUser: async (req, res) => {
        try {
            const newUser = new User(req.body);
            const savedUser = await newUser.save();

            res.status(201).json({
                success: true,
                message: 'User created successfully!',
                data: savedUser
            });

        } catch (err) {
            res.status(500).json({
                success: false,
                message: err.message,
                data: {}
            });
        }
    },

    updateUser: async (req, res) => {
        try {
            const id = req.params.id;
           
            const updateFields = req.body;
            delete updateFields._id;

            console.log(updateFields)

            const updatedUser = await User.findByIdAndUpdate(id, updateFields, { new: true });

            res.status(200).json({
                success: true,
                message: 'User updated successfully!',
                data: updatedUser
            });
        } catch (err) {
            console.log(err)
            res.status(500).json({
                success: false,
                message: err.message,
                data: {}
            });
        }
    },

    deleteUser: async (req, res) => {
        try {
            const id = req.params.id;
            const deletedUser = await User.findByIdAndDelete(id);

            res.status(200).json({
                success: true,
                message: 'User deleted successfully!',
                data: deletedUser
            });
        } catch (err) {
            res.status(500).json({
                success: false,
                message: err.message,
                data: {}
            });
        }
    }

    
}

module.exports = userController;
