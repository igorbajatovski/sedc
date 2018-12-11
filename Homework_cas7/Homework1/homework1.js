function hasProperty(object, propertyName)
{
    let prop = new String(propertyName);
    if(prop in object)
        return true;
    return false;
}

let car =
{
    brand: "Toyota",
    model: "Corola",
    engine: "Petrol",
    year: 2006,
    horsePowers: 108,
    doors: 5,
    fuelConsumption: 7
}



console.log(hasProperty(car, "brand"));
console.log(hasProperty(car, 2));
console.log(hasProperty(car, "year"));
console.log(hasProperty(car, "doors"));
console.log(hasProperty(car, null));
console.log(hasProperty(car, undefined));
console.log(hasProperty(car, NaN));