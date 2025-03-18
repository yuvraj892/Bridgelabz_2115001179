function findRepeatedDigits() {
    let repeatedNumbers = [];
    for (let i = 10; i <= 99; i++) {
        let str = i.toString();
        if (str[0] === str[1]) {
            repeatedNumbers.push(i);
        }
    }
    return repeatedNumbers;
}

console.log("Repeated digit numbers in range 0-100:", findRepeatedDigits());
