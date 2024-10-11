const orderController = require("../controllers/orderController");

const router = require("express").Router();

// GET ALL ORDERS
router.get("/", orderController.getAllOrders);

// GET ORDER BY ID
// router.get("/:id", orderController.getProductById);

// CREATE A NEW ORDER
router.post("/create", orderController.createOrder);

// UPDATE A ORDER
router.put("/:id", orderController.updateOrder);

// DELETE A ORDER
router.delete("/:id", orderController.deleteOrder);

module.exports = router;
