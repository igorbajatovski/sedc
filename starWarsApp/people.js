// +++++++++++++++++++++++++++++++++++++++++++++ People ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

function parsePeople(people)
{
    return people.map( (elem) => { 
                                    return {
                                                id: elem.id,
                                                name: elem.name, 
                                                gender: elem.gender, 
                                                birth_year: elem.birth_year,
                                                height: elem.height,
                                                mass: elem.mass
                                            }
                                } );
}

// function populatePeopleTable(starWarsPeople)
// {   
//     let tableBody = $("#table tbody");

//     let count = 1;
//     for (const people of starWarsPeople) 
//     {

//         let newRow = $(`<tr id="${count++}">`);

//         newRow.append(`<td>${people.name}</td>
//                         <td>${people.gender}</td>
//                         <td>${people.birth_year}</td>
//                         <td>${people.height}</td>
//                         <td>${people.mass}</td>`);

//         tableBody.append(newRow);

//     }

//     $("#table tbody tr").on("click", showPeopleDetails);

//     return starWarsPeople;
// }

// function fetchPeopleDetails(id)
// {
//     let peopleDetails  = fetch(`https://swapi.co/api/people/${id}/`)
//                                 .then( result => result.json() )
//                                     .then(json => json);
//     return peopleDetails;
// }

// async function showPeopleDetails(event)
// {
//     let id = $(this).attr("id");
//     let peopleDetails = await fetchPeopleDetails(id);

//     for (const key in peopleDetails) {
//         if (peopleDetails.hasOwnProperty(key)) {
//             const element = peopleDetails[key];
//             console.log(`${key}, ${element}`);
//         }
//     }
// }

// +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++