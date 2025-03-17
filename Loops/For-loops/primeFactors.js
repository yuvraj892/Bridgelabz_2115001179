let N = parseInt(process.argv[2]);

if (isNaN(N) || N <= 1) {
    console.log("Please enter a valid integer greater than 1.");
    process.exit(1);
}

console.log(`Prime factors of ${N}:`);
for (let i = 2; i * i <= N; i++) {
    while (N % i === 0) {
        console.log(i);
        N /= i;
    }
}
if (N > 1) {
    console.log(N);
}
