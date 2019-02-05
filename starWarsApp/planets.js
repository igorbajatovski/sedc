// +++++++++++++++++++++++++++++++++++++++++++++++++++++++ Planets +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

function parsePlanets(planets)
{
    return planets.map( (elem) => { 
                                        return {
                                                    id: elem.id,
                                                    name: elem.name, 
                                                    diameter: elem.diameter, 
                                                    climate: elem.climate,
                                                    terrain: elem.terrain,
                                                    rotation_period: elem.rotation_period,
                                                    population: elem.population
                                                }
                                    } );
}

// function populatePlanetsTable(starWarsPlanets)
// {   
//     let tableBody = $("#table tbody");

//     let count = 1;
//     for (const planet of starWarsPlanets) 
//     {   
//         let newRow = $(`<tr id="${count++}">`);

//         newRow.append(`<td>${planet.name}</td>
//                         <td>${planet.diameter}</td>
//                         <td>${planet.climate}</td>
//                         <td>${planet.terrain}</td>
//                         <td>${planet.rotation_period}</td>
//                         <td>${planet.population}</td>`);

//         tableBody.append(newRow);

//     }

//     $("#table tbody tr").on("click", showPlanetDetails);

//     return starWarsPlanets;
// }

// function fetchPlanetDetails(id)
// {
//     let planetDetails  = fetch(`https://swapi.co/api/planets/${id}/`)
//                                 .then( result => result.json() )
//                                     .then(json => json);
//     return planetDetails;
// }

// async function showPlanetDetails(event)
// {
//     let id = $(this).attr("id");
//     let planetDetails = await fetchPlanetDetails(id);

//     for (const key in planetDetails) {
//         if (planetDetails.hasOwnProperty(key)) {
//             const element = planetDetails[key];
//             console.log(`${key}, ${element}`);
//         }
//     }
// }

// +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++