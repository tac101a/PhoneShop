const mongoose = require('mongoose');

const productSchema = new mongoose.Schema(
    {
        name: {
            type: String,
            required: true,
        },
        manufacture: {
            type: Number,
            required: true,
        },
        price: {
            type: Number,
            required: true,
        },
        producer: {
            type: String,
            required: true,
        }
    }
);

const Product = mongoose.model('Product', productSchema);

module.exports = Product;
