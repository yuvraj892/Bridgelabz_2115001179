let money = 100;
const goal = 200;
let wins = 0, bets = 0;

while (money > 0 && money < goal) {
    bets++;
    let betResult = Math.random() < 0.5;

    if (betResult) {
        money++; 
        wins++;
    } else {
        money--; 
    }

    console.log(`Bet ${bets}: ${betResult ? "Won" : "Lost"} | Money: Rs ${money}`);
}

console.log(`Game Over! Total Bets: ${bets}, Wins: ${wins}`);
if (money >= goal) {
    console.log("You reached the goal of Rs 200!");
} else {
    console.log("You went broke!");
}
