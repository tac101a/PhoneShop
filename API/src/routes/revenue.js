const revenueController = require("../controllers/revenueController");

const router = require("express").Router();

// GET ALL REVENUE
// router.post("/", revenueController.getAllRevenue);

// GET REVENUE BY DATE
router.post("/date", revenueController.getRevenueByDate);

// GET REVENUE BY YEAR
router.post("/year", revenueController.getRevenueByYear);

router.post("/month", revenueController.getRevenueByMonth);
module.exports = router;
