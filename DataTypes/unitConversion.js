let inches = 42;
let feet = inches / 12;
console.log(`${inches} inches = ${feet.toFixed(2)} feet`);

let lengthInFeet = 60;
let widthInFeet = 40;
let feetToMeters = 0.3048; 

let lengthInMeters = lengthInFeet * feetToMeters;
let widthInMeters = widthInFeet * feetToMeters;

console.log(`Rectangular Plot: ${lengthInMeters.toFixed(2)}m x ${widthInMeters.toFixed(2)}m`);


let areaOfOnePlot = lengthInMeters * widthInMeters; 
let totalArea = areaOfOnePlot * 25;
let squareMetersToAcres = 0.000247105; 

let areaInAcres = totalArea * squareMetersToAcres;
console.log(`Total area of 25 plots: ${areaInAcres.toFixed(4)} acres`);
