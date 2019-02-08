class Starships {
    constructor(name, pilot, fuelTankCapacity, currentLocation, typeOfStarship)
    {
        this.name = name;
        this.pilot = pilot;
        this.fuelTankCapacity = fuelTankCapacity;
        this.currentLocation = currentLocation;
        this.typeOfStarship = typeOfStarship;
    }

    startEngine()
    {
        return `Engine of ${this.typeOfStarship} is started`;
    }

    takeOff()
    {
        return `${this.typeOfStarship} has taken off`;
    }

    land()
    {
        return `${this.typeOfStarship} has landed`;
    }
}

class Fighter extends Starships {
    constructor(name, pilot, fuelTankCapacity, currentLocation, typeOfStarship, weapons, shield, numberOfKills)
    {
        super(name, pilot, fuelTankCapacity, currentLocation, typeOfStarship);
        this.weapons = weapons;
        this.shield = shield;
        this.numberOfKills = numberOfKills;
    }

    shootWeapon1()
    {

    }

    shootWeapon2()
    {
        
    }

    shootWeapon3()
    {
        
    }
}

class Cargoship extends Starships {
    constructor(name, pilot, fuelTankCapacity, currentLocation, typeOfStarship, cargoCapacity, tradingRoute, loadingCranes)
    {
        super(name, pilot, fuelTankCapacity, currentLocation, typeOfStarship);
        this.cargoCapacity = cargoCapacity;
        this.tradingRoute = tradingRoute;
        this.loadingCranes = loadingCranes;
    }

    load()
    {

    }

    unload()
    {

    }
}

class Miningship extends Starships {
    constructor(name, pilot, fuelTankCapacity, currentLocation, typeOfStarship, miningTools, miningTypes, miningStorageCapacity)
    {
        super(name, pilot, fuelTankCapacity, currentLocation, typeOfStarship);
        this.miningTools = miningTools;
        this.miningTypes = miningTypes;
        this.miningStorageCapacity = miningStorageCapacity;
        this._storageTemperature = 0;
    }

    mine()
    {

    }

    set storageTemperature(value)
    {
        this._storageTemperature = value;
    }

    get storageTemperature()
    {
        return this._storageTemperature;
    }
}



let fighter = new Fighter("X-wing", "Luke Skywalker", 1000, "Sweden", "T-65 X-wing", ["Rockets", "Machine Guns", "Bombs"], true, 150);
let cargoship = new Cargoship("Imperial shuttle", "Han Solo", 20000000, "In the garage", 
                              "Lambda-class T-4a shuttle", 80000, "Skopje - Frankfurt", 20);
let miningship = new Miningship("TIE Advanced x1", "Darth Vader", 3000000, "Germany", "Twin Ion Engine Advanced x1",
                                ["Mining Tool1", "Mining Tool1"], ["Mining Type1", "Mining Type2"], 8000000000);


