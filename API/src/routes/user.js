const userController = require("../controllers/userController");

const router = require("express").Router();

// GET ALL USERS
router.get("/", userController.getAllUsers);

// GET USER BY ID
router.get("/:id", userController.getUserById);

// CREATE A NEW USER
router.post("/create", userController.createUser);

// UPDATE A USER
router.put("/:id", userController.updateUser);

// DELETE A USER
router.delete("/:id", userController.deleteUser);

module.exports = router;