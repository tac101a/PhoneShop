const Order = require('../models/Order ');

const orderController = {
    getAllOrders: async (req, res) => {
        try {
            const orders = await Order.find();

            res.status(200).json({
                success: true,
                message: 'Get all orders successfully!',
                data: orders
            });
        } catch (err) {
            res.status(500).json({
                success: false,
                message: err.message,
                data: []
            });
        }
    },

    getOrderById: async (req, res) => {
        try {
            const id = req.params.id;

            const order = await Product.findById(id);

            res.status(200).json({
                success: true,
                message: 'Get order successfully!',
                data: order
            });
        } catch (err) {
            res.status(500).json({
                success: false,
                message: err.message,
                data: {}
            });
        }
    },

    createOrder: async (req, res) => {
        try {
            const newOrder = new Order(req.body);
            delete newOrder._id;

            console.log("test: ", newOrder)
            const savedOrder = await newOrder.save();

            res.status(201).json({
                success: true,
                message: 'Order created successfully!',
                data: savedOrder
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

    updateOrder: async (req, res) => {
        try {
            const id = req.params.id;
            const updatedOrder = await Order.findByIdAndUpdate(id, req.body, { new: true });

            res.status(200).json({
                success: true,
                message: 'Order updated successfully!',
                data: updatedOrder
            });
        } catch (err) {
            res.status(500).json({
                success: false,
                message: err.message,
                data: {}
            });
        }
    },

    deleteOrder: async (req, res) => {
        try {
            const id = req.params.id;
            console.log(req.params);
            const deletedOrder = await Product.findByIdAndDelete(id);

            res.status(200).json({
                success: true,
                message: 'Order deleted successfully!',
                data: deletedOrder
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

module.exports = orderController;
