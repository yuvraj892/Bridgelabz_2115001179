const start = parseInt(process.argv[2]);
const end = parseInt(process.argv[3]);

if (isNaN(start) || isNaN(end) || start < 2 || end < 2 || start > end) {
    console.log("Please enter a valid range (start and end must be >= 2, and start <= end).");
    process.exit(1);
}

console.log(`Prime numbers between ${start} and ${end}:`);
for (let num = start; num <= end; num++) {
    let isPrime = true;
    for (let i = 2; i * i <= num; i++) {
        if (num % i === 0) {
            isPrime = false;
            break;
        }
    }
    if (isPrime) {
        console.log(num);
    }
}