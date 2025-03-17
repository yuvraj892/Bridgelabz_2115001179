const a = parseFloat(process.argv[2]);
const b = parseFloat(process.argv[3]);
const c = parseFloat(process.argv[4]);

if (isNaN(a) || isNaN(b) || isNaN(c)) {
    console.log("Invalid input! Please enter three numbers.");
    process.exit(1);
}

let op1 = a + b * c;
let op2 = a % b + c;
let op3 = c + a / b;
let op4 = a * b + c;

let max = op1;
let min = op1;

if (op2 > max) max = op2;
if (op3 > max) max = op3;
if (op4 > max) max = op4;

if (op2 < min) min = op2;
if (op3 < min) min = op3;
if (op4 < min) min = op4;

console.log(`Results of operations:
1. a + b * c  = ${op1}
2. a % b + c  = ${op2}
3. c + a / b  = ${op3}
4. a * b + c  = ${op4}`);

console.log(`Maximum Value: ${max}`);
console.log(`Minimum Value: ${min}`);
