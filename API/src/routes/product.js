const productController = require("../controllers/productController");

const router = require("express").Router();

// GET ALL PRODUCTS
router.get("/", productController.getAllProducts);

// GET PRODUCT BY ID
router.get("/:id", productController.getProductById);

// CREATE A NEW PRODUCT
router.post("/create", productController.createProduct);

// UPDATE A PRODUCT
router.put("/:id", productController.updateProduct);

// DELETE A PRODUCT
router.delete("/:id", productController.deleteProduct);

module.exports = router;
