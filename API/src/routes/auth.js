const router = require("express").Router();

const authController = require("../controllers/authController");
// const { verifyToken } = require("../controllers/verifyToken");

//REGISTER
router.post("/register", authController.registerUser);

//LOG IN
router.post("/login", authController.loginUser);

// //LOG OUT
// router.post("/logout", verifyToken, authController.logOut);

module.exports = router;