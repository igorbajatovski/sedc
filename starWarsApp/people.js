// +++++++++++++++++++++++++++++++++++++++++++++ People ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

function parsePeople(people)
{
    return people.map( (elem) => { 
                                    return {
                                                name: elem.name, 
                                                gender: elem.gender, 
                                                birth_year: elem.birth_year,
                                                height: elem.height,
                                                mass: elem.mass
                                            }
                                } );
}

function populatePeopleTable(starWarsPeople)
{   
    let tableBody = $("#table tbody");

    for (const people  of starWarsPeople) 
    {

        let newRow = $("<tr>");

        newRow.append(`<td>${people.name}</td>
                        <td>${people.gender}</td>
                        <td>${people.birth_year}</td>
                        <td>${people.height}</td>
                        <td>${people.mass}</td>`);

        tableBody.append(newRow);

    }

    return starWarsPeople;
}

// +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++