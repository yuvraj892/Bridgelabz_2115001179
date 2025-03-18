function findTriplets(arr) {
    let triplets = [];
    let len = arr.length;
    for (let i = 0; i < len - 2; i++) {
        for (let j = i + 1; j < len - 1; j++) {
            for (let k = j + 1; k < len; k++) {
                if (arr[i] + arr[j] + arr[k] === 0) {
                    triplets.push([arr[i], arr[j], arr[k]]);
                }
            }
        }
    }
    return triplets;
}

let sampleArray = [-1, 0, 1, 2, -2, -1];
console.log("Triplets summing to zero:", findTriplets(sampleArray));