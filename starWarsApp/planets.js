// +++++++++++++++++++++++++++++++++++++++++++++++++++++++ Planets +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

function parsePlanets(planets)
{
    return planets.map( (elem) => { 
                                        return {
                                                    name: elem.name, 
                                                    diameter: elem.diameter, 
                                                    climate: elem.climate,
                                                    terrain: elem.terrain,
                                                    rotation_period: elem.rotation_period,
                                                    population: elem.population
                                                }
                                    } );
}

function populatePlanetsTable(starWarsPlanets)
{   
    let tableBody = $("#table tbody");

    for (const planet of starWarsPlanets) 
    {                

        let newRow = $("<tr>");

        newRow.append(`<td>${planet.name}</td>
                        <td>${planet.diameter}</td>
                        <td>${planet.climate}</td>
                        <td>${planet.terrain}</td>
                        <td>${planet.rotation_period}</td>
                        <td>${planet.population}</td>`);

        tableBody.append(newRow);

    }

    return starWarsPlanets;
}

// +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++