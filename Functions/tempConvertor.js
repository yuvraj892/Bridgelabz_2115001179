function convertTemperature(choice, value) {
    switch (choice) {
        case "1":  
            let degC = parseFloat(value);
            if (degC < 0 || degC > 100) {
                console.log("Invalid Input! Temperature must be between 0°C and 100°C.");
                return;
            }
            let degF = (degC * 9 / 5) + 32;
            console.log(`${degC}°C is ${degF.toFixed(2)}°F`);
            break;

        case "2":  
            let degFInput = parseFloat(value);
            if (degFInput < 32 || degFInput > 212) {
                console.log("Invalid Input! Temperature must be between 32°F and 212°F.");
                return;
            }
            let degCConverted = (degFInput - 32) * 5 / 9;
            console.log(`${degFInput}°F is ${degCConverted.toFixed(2)}°C`);
            break;

        default:
            console.log("Invalid Choice! Use 1 for C to F, 2 for F to C.");
    }
}

let args = process.argv.slice(2);
convertTemperature(args[0], args[1]);
