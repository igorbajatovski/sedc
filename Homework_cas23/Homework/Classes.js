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
        return `Weapon ${this.weapons[0]} is fired`;
    }

    shootWeapon2()
    {
        return `Weapon ${this.weapons[1]} is fired`;
    }

    shootWeapon3()
    {
        return `Weapon ${this.weapons[2]} is fired`;
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
        return `The cargo with capacity ${this.cargoCapacity} is loaded`;
    }

    unload()
    {
        return `The cargo with capacity ${this.cargoCapacity} is unloaded`;
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
        return `Mining has started with ${this.miningTools.join()}`;   
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