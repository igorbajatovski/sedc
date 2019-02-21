class SpaceEvent {
    //new SpaceEvent("Fuel Leak", "Due to low maintenance of the ship, the fuel tank leaked. The leak was patched, but we lost some fuel.", 
    //                0, -50, 0 ),
    constructor(name, description, crewModifier, fuelModifier, hullmodifier)
    {
        this.name = name;
        this.description = description;
        this.crewModifier = crewModifier;
        this.fuelModifier = fuelModifier;
        this.hullmodifier = hullmodifier;
    }

    startEvent(ship)
    {
        if( !(ship instanceof Ship) )
            throw Error("This is not a ship");

        
    }

    static generateEvents(time, events)
    {
        let generateRandom = (min, max) => { return (Math.random() * (max - min) + min) }
        
        let resultEvents = [];

        let numEvents = 1;
        if(time > 26000)
            numEvents = 4;
        else if(time > 18000)
            numEvents = 3;
        else if(time > 8000)
            numEvents = 2;

        for(let i = 0; i < numEvents; ++i) 
            resultEvents.push(events[generateRandom(0, events.length - 1)]);
    }
}