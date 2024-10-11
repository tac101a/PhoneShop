const Product = require('../models/Product');

const productController = {
    getAllProducts: async (req, res) => {
        try {
            const products = await Product.find();

            res.status(200).json({
                success: true,
                message: 'Get all products successfully!',
                data: products
            });
        } catch (err) {
            res.status(500).json({
                success: false,
                message: err.message,
                data: []
            });
        }
    },

    getProductById: async (req, res) => {
        try {
            const id = req.params.id;

            const product = await Product.findById(id);

            res.status(200).json({
                success: true,
                message: 'Get product successfully!',
                data: product
            });
        } catch (err) {
            res.status(500).json({
                success: false,
                message: err.message,
                data: {}
            });
        }
    },

    createProduct: async (req, res) => {
        try {
            const newProduct = new Product(req.body);
            console.log(newProduct);
            const savedProduct = await newProduct.save();

            res.status(201).json({
                success: true,
                message: 'Product created successfully!',
                data: savedProduct
            });
        } catch (err) {
            res.status(500).json({
                success: false,
                message: err.message,
                data: {}
            });
        }
    },

    updateProduct: async (req, res) => {
        try {
            const id = req.params.id;

            const updateFields = req.body;
            delete updateFields._id;

            console.log(updateFields)

            const updatedProduct = await Product.findByIdAndUpdate(id, updateFields, { new: true });

            res.status(200).json({
                success: true,
                message: 'Product updated successfully!',
                data: updatedProduct
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

    deleteProduct: async (req, res) => {
        try {
            const id = req.params.id;
            const deletedProduct = await Product.findByIdAndDelete(id);

            res.status(200).json({
                success: true,
                message: 'Product deleted successfully!',
                data: deletedProduct
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

module.exports = productController;
