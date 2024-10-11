const mongoose = require("mongoose");

const userSchema = new mongoose.Schema(
    {
        name: {
            type: String,
            required: true,
        },
        userName: {
            type: String,
            required: true,
            unique: true,
        },
        email: {
            type: String,
            required: true,
            unique: true,
        },
        userPassword: {
            type: String,
            required: true,
            //require: true,
        }
    }
);

const User = mongoose.model('User', userSchema);

module.exports = User;
