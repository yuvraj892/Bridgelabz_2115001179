function hasKey(obj, key) {
    return key in obj;
}

let person = {
    name: "John",
    age: 30,
    city: "New York"
};

console.log(hasKey(person, "age"));  
console.log(hasKey(person, "salary"));  
