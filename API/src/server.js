const express = require("express");
const cors = require("cors");
const bodyParser = require("body-parser");
const dotenv = require("dotenv");

const productRoute = require("./routes/product");
const orderRoute = require("./routes/order");
const userRoute = require("./routes/user");
const authRoute = require("./routes/auth");
const revenueRoute = require("./routes/revenue");

const conecctToDB = require('./configs/db');

const app = express();
dotenv.config();

//CONNECT DATABASE
conecctToDB();

app.use(bodyParser.json({ limit: "50mb" }));
app.use(cors());

//ROUTES
app.use("/api/product", productRoute);
app.use("/api/order", orderRoute);
app.use("/api/auth", authRoute);
app.use("/api/user", userRoute);
app.use("/api/revenue", revenueRoute);


app.listen(process.env.PORT || 8000, () => {
    console.log("Server is running...");
});