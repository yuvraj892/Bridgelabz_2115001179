const num = parseInt(process.argv[2]);

if (isNaN(num) || num < 2) {
    console.log("Please enter a valid integer greater than or equal to 2.");
    process.exit(1);
}

let isPrime = true;
for (let i = 2; i * i <= num; i++) {
    if (num % i === 0) {
        isPrime = false;
        break;
    }
}

console.log(num + (isPrime ? " is a Prime Number" : " is NOT a Prime Number"));