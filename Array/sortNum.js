function generateRandomNumbers() {
    let arr = [];
    for (let i = 0; i < 10; i++) {
        arr.push(Math.floor(Math.random() * 900) + 100);
    }
    return arr;
}


function findWithSorting(arr) {
    arr.sort((a, b) => a - b);
    return { secondSmallest: arr[1], secondLargest: arr[arr.length - 2] };
}

let numbers = generateRandomNumbers();
console.log("Sorted Numbers:", numbers);
let sortedResult = findWithSorting([...numbers]);
console.log("2nd Largest (Sorted):", sortedResult.secondLargest);
console.log("2nd Smallest (Sorted):", sortedResult.secondSmallest);