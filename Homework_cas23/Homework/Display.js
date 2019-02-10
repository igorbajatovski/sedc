function createShip(type, index)
{
    switch(type)
    {
        case "fighterShip":
                            $("#viewShips").append(`<table id="${index}" class="Fighter">
                                    <thead>
                                        <tr>
                                            <th colspan="2">Fighter</th>
                                        </tr>
                                    </thead>
                        
                                    <tbody>
                        
                                        <tr> <td>Name</td> <td></td> </tr>
                                        <tr> <td>Pilot</td> <td></td> </tr>
                                        <tr> <td>Fuel tank capacity</td> <td></td> </tr>
                                        <tr> <td>Current location</td> <td></td> </tr>
                                        <tr> <td>Type of starship</td> <td></td> </tr>
                                        <tr> <td>Weapons</td> <td></td> </tr>
                                        <tr> <td>Shield</td> <td></td> </tr>
                                        <tr> <td>Number of kills</td> <td></td> </tr>
                        
                                        <tr>
                                            <td colspan="2" style="text-align: center;">
                                                <button id="startEngineBtn">Start engine</button>
                                                <button id="takeOffBtn">Take off</button>
                                                <button id="landBtn">Land</button>
                                            </td>
                                        </tr>
                                        
                                    </tbody>
                                </table>`);
                            break;
        
        case "cargoShip":   
                            $("#viewShips").append(`<table id=${index} class="CargoShip">
                                    <thead>
                                        <tr>
                                            <th colspan="2">Cargo Ship</th>
                                        </tr>
                                    </thead>
                        
                                    <tbody>
                        
                                        <tr> <td>Name</td> <td></td> </tr>
                                        <tr> <td>Pilot</td> <td></td> </tr>
                                        <tr> <td>Fuel tank capacity</td> <td></td> </tr>
                                        <tr> <td>Current location</td> <td></td> </tr>
                                        <tr> <td>Type of starship</td> <td></td> </tr>
                                        <tr> <td>Cargo capacity</td> <td></td> </tr>
                                        <tr> <td>Trading route</td> <td></td> </tr>
                                        <tr> <td>Loading cranes</td> <td></td> </tr>
                        
                                        <tr>
                                            <td colspan="2" style="text-align: center;">
                                                <button id="startEngineBtn">Start engine</button>
                                                <button id="takeOffBtn">Take off</button>
                                                <button id="landBtn">Land</button>
                                            </td>
                                        </tr>
                        
                                    </tbody>
                                </table>`);
                            break;

        case "miningShip":
                            $("#viewShips").append(`<table id="${index}" class="MiningShip">
                                    <thead>
                                        <tr>
                                            <th colspan="2">Mining Ship</th>
                                        </tr>
                                    </thead>
                        
                                    <tbody>
                        
                                        <tr> <td>Name</td> <td></td> </tr>
                                        <tr> <td>Pilot</td> <td></td> </tr>
                                        <tr> <td>Fuel tank capacity</td> <td></td> </tr>
                                        <tr> <td>Current location</td> <td></td> </tr>
                                        <tr> <td>Type of starship</td> <td></td> </tr>
                                        <tr> <td>Mining tools</td> <td></td> </tr>
                                        <tr> <td>Mining types</td> <td></td> </tr>
                                        <tr> <td>Mining storage capacity</td> <td></td> </tr>
                        
                                        <tr>
                                            <td colspan="2" style="text-align: center;">
                                                <button id="startEngineBtn">Start engine</button>
                                                <button id="takeOffBtn">Take off</button>
                                                <button id="landBtn">Land</button>
                                            </td>
                                        </tr> 
                        
                                    </tbody>
                        
                                </table>`);
                            break;
    }

    $("#viewShips table:last button").on("click", function(event)
    {
        
        let index = parseInt($(this).parents("table").attr("id"));
        let buttonID = $(this).attr("id");

        if(buttonID === "startEngineBtn")
        {
            alert(ships[index].startEngine());
        }
        else if(buttonID === "takeOffBtn")
        {
            alert(ships[index].takeOff());
        }
        else if(buttonID === "landBtn")
        {
            alert(ships[index].land());
        }

    });
}

function showShip(ship, type, index)
{
    i = 1;

    if(type === "fighterShip")
    {
        for (const prop in ship) 
        {
            if(!prop.startsWith("_"))
                $(`#viewShips #${index} tbody tr:nth-child(${i}) td:last`).text(ship[prop]);
            ++i;
        }
    }
    else if(type === "cargoShip")
    {
        for (const prop in ship) 
        {
            if(!prop.startsWith("_"))
                $(`#viewShips #${index} tbody tr:nth-child(${i}) td:last`).text(ship[prop]);
            ++i;
        }
    }
    else if(type === "miningShip")
    {
        for (const prop in ship) 
        {
            if(!prop.startsWith("_"))
                $(`#viewShips #${index} tbody tr:nth-child(${i}) td:last`).text(ship[prop]);
            ++i;
        }
    }
}