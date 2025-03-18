function rollDice() {
    return Math.floor(Math.random() * 6) + 1;
}

function trackDiceRolls() {
    let diceMap = new Map();
    
    for (let i = 1; i <= 6; i++) {
        diceMap.set(i, 0);
    }

    let maxCount = 10;
    let reachedMax = false;

    while (!reachedMax) {
        let roll = rollDice();
        diceMap.set(roll, diceMap.get(roll) + 1);

        if (diceMap.get(roll) === maxCount) {
            reachedMax = true;
        }
    }

    console.log("Final Dice Roll Counts:", Object.fromEntries(diceMap));

    let maxNum = [...diceMap.entries()].reduce((a, b) => a[1] > b[1] ? a : b);
    let minNum = [...diceMap.entries()].reduce((a, b) => a[1] < b[1] ? a : b);

    console.log(`Number that reached max times: ${maxNum[0]} (${maxNum[1]} times)`);
    console.log(`Number that appeared least: ${minNum[0]} (${minNum[1]} times)`);
}

trackDiceRolls();
