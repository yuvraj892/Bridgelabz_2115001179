function isPrime(num) {
    if (num < 2) return false;
    for (let i = 2; i * i <= num; i++) {
        if (num % i === 0) return false;
    }
    return true;
}

function getPalindrome(num) {
    let reversed = 0, temp = num;
    while (temp > 0) {
        reversed = (reversed * 10) + (temp % 10);
        temp = Math.floor(temp / 10);
    }
    return reversed;
}

function checkPrimePalindrome(num) {
    if (isPrime(num)) {
        console.log(`${num} is a Prime Number.`);
        let palindromeNum = getPalindrome(num);
        console.log(`Palindrome of ${num} is ${palindromeNum}`);

        if (isPrime(palindromeNum)) {
            console.log(`The palindrome ${palindromeNum} is also a Prime Number.`);
        } else {
            console.log(`The palindrome ${palindromeNum} is NOT a Prime Number.`);
        }
    } else {
        console.log(`${num} is NOT a Prime Number.`);
    }
}

let args = process.argv.slice(2);
let num = parseInt(args[0]);

checkPrimePalindrome(num);
