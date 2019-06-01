let car =
{
    brand: "Toyota",
    model: "Corola",
    engine: "Petrol",
    year: 2006,
    horsePowers: 108,
    doors: 5,
    fuelConsumption: 7,
    fuelPerDistance(distanceInKm) {
        return  Number((distanceInKm / 100) * this.fuelConsumption).toPrecision(3);
    }
}


console.log(car.fuelPerDistance(100));
console.log(car.fuelPerDistance(50));
console.log(car.fuelPerDistance(20));
console.log(car.fuelPerDistance(0));
console.log(car.fuelPerDistance(1));
console.log(car.fuelPerDistance(10));
console.log(car.fuelPerDistance(150));
console.log(car.fuelPerDistance(200));
console.log(car.fuelPerDistance(300));
console.log(car.fuelPerDistance(400));
console.log(car.fuelPerDistance(1000));