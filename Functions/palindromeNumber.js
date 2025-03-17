function getPalindrome(num) {
    let reversed = 0, temp = num;
    while (temp > 0) {
        reversed = (reversed * 10) + (temp % 10);
        temp = Math.floor(temp / 10);
    }
    return reversed;
}

function isPalindrome(num1, num2) {
    return getPalindrome(num1) === num1 && getPalindrome(num2) === num2;
}

let args = process.argv.slice(2);
let num1 = parseInt(args[0]);
let num2 = parseInt(args[1]);

if (isPalindrome(num1, num2)) {
    console.log(`Both ${num1} and ${num2} are palindromes.`);
} else {
    console.log(`One or both numbers are not palindromes.`);
}
