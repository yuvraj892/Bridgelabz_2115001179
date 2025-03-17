const day = parseInt(process.argv[2]);
const month = parseInt(process.argv[3]);

if ((month === 3 && day >= 20) || (month === 4) || (month === 5) || (month === 6 && day <= 20)) {
    console.log("true");
} else {
    console.log("false");
}