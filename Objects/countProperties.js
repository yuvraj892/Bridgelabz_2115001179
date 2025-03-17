function countProperties(obj) {
    return Object.keys(obj).length;
}

let car = {
    brand: "Tesla",
    model: "Model S",
    year: 2024
};

console.log("Number of properties:", countProperties(car));
