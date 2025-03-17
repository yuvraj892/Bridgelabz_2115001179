const choice = parseInt(process.argv[2]);
const value = parseFloat(process.argv[3]);

if (isNaN(value)) {
    console.log("Invalid input! Please enter a valid number.");
    process.exit(1);
}

switch (choice) {
    case 1: 
        console.log(`${value} Feet = ${value * 12} Inches`);
        break;
    case 2: 
        console.log(`${value} Feet = ${(value * 0.3048).toFixed(2)} Meters`);
        break;
    case 3: 
        console.log(`${value} Inches = ${(value / 12).toFixed(2)} Feet`);
        break;
    case 4: 
        console.log(`${value} Meters = ${(value * 3.28084).toFixed(2)} Feet`);
        break;
    default: 
        console.log("Invalid choice! Choose from:\n1. Feet to Inches\n2. Feet to Meters\n3. Inches to Feet\n4. Meters to Feet");
}
