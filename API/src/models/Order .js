const mongoose = require('mongoose');

const orderSchema = new mongoose.Schema(
    {
        date: {
            type: String,
            required: true,
        },
        userName: {
            type: String,
            required: true,
        },
        productName: {
            type: String,
            required: true,
        },
        quantity: {
            type: Number,
            required: true,
        },
    }
);

const Order = mongoose.model('Order ', orderSchema);

module.exports = Order;
