const readline = require('readline-sync');

console.log("Think of a number between 1 and 100...");
let low = 1, high = 100;

while (low < high) {
    let mid = Math.floor((low + high) / 2);
    let response = readline.question(`Is your number less than or equal to ${mid}? (yes/no): `).toLowerCase();

    if (response === "yes") {
        high = mid;
    } else {
        low = mid + 1;
    }
}

console.log(`Your Magic Number is: ${low}`);
