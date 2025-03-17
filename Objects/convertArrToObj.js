function objectToArray(obj) {
    return Object.entries(obj);
}

let user = {
    id: 101,
    username: "arihant_shukla",
    email: "arihant@example.com"
};

console.log(objectToArray(user));
