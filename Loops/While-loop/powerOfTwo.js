const n = parseInt(process.argv[2]);

if (isNaN(n) || n < 0) {
    console.log("Please enter a valid non-negative integer.");
    process.exit(1);
}

console.log(`Powers of 2 up to 2^${n} (or until 256):`);

let i = 0;
while (i <= n && 2 ** i <= 256) {
    console.log(`2^${i} = ${2 ** i}`);
    i++;
}
