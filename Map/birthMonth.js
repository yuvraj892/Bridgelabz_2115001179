function generateBirthMonths(numIndividuals) {
    let birthMap = new Map();

    for (let i = 1; i <= 12; i++) {
        birthMap.set(i, []);
    }

    for (let i = 1; i <= numIndividuals; i++) {
        let month = Math.floor(Math.random() * 12) + 1;
        birthMap.get(month).push(`Person-${i}`);
    }

    console.log("Birth Month Distribution:");
    birthMap.forEach((people, month) => {
        console.log(`Month ${month}: ${people.length > 0 ? people.join(", ") : "No one"}`);
    });
}

generateBirthMonths(50);
