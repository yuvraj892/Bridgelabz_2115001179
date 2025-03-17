const num = parseInt(process.argv[2]);

if (isNaN(num) || num < 0) {
    console.log("Please enter a valid non-negative integer.");
    process.exit(1);
}

let factorial = 1;
for (let i = 1; i <= num; i++) {
    factorial *= i;
}

console.log(`${num}! = ${factorial}`);