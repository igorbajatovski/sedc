// +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ Events +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

let starWarsPeople = null;
let starWarsPlanets = null;

function getData(dataURL, final = [])
{
    let promise = new Promise( (resolve, reject) => 
        {
            $.ajax(
                {
                    url: dataURL,
                    success: async function(result)
                    {
                        if(final.length === 0)
                        final.push(...result.results);

                        if(result.next !== null)
                        {
                            let data = await getData(result.next, final);
                            final.push(...data);
                            if(final.length < result.count)
                                resolve(result.results);
                            else
                            {
                                resolve(final);
                                final = [];
                            }
                        }
                        else
                        {
                            resolve(result.results);
                        }
                    },
                    error: function(result)
                    {
                        reject(result);
                    }
                }
            )// end of ajax
        } );//end of promise

    return promise;
}

function fetchData(url, finalResult = [])
{
    let promise = fetch(url).
        then(result => result.json()).
        then(result => {
            if(result.next !== null)
            {
                finalResult.push(...result.results);
                return fetchData(result.next, finalResult);
            }
            else
            {
                finalResult.push(...result.results);
                return finalResult;
            }
        });
    return promise;
}


//  ++++++++++++++++++++++ Get People +++++++++++++++++++++++++++++++++
$("#getPeople").on("click", function(event) {
    
    clearTableData();
    showPlanetsTable(false);
    noResultsFound(false);
    showLogo(false);

    if(starWarsPeople === null)
    {
        showProgess(true);
        
        let promise = getData("https://swapi.co/api/people/");

        promise.then( (result) => {
                                        showProgess(false);
                                        starWarsPeople = populatePeopleTable(result);
                                        showPeopleTable(true);
                                  }
                    );
    }
    else
    {
        populatePeopleTable(starWarsPeople);
        showPeopleTable(true);
    }

});

//  ++++++++++++++++++++++ Get Planets +++++++++++++++++++++++++++++++++
$("#getPlanets").on("click", function(event) {

    clearTableData();
    showPeopleTable(false);
    noResultsFound(false);
    showLogo(false);

    if(starWarsPlanets === null)
    {
        showProgess(true);

        // let promise = getData("https://swapi.co/api/planets/");
        let promise = fetchData("https://swapi.co/api/planets/");
        
        promise.then( (result) => {
                                    finalResult = [];
                                    showProgess(false);
                                    starWarsPlanets = populatePlanetsTable(result);
                                    showPlanetsTable(true);
                                  }   
                    );
    }
    else
    {
        populatePlanetsTable(starWarsPlanets);
        showPlanetsTable(true);
    }
    
});

//  ++++++++++++++++++++++++++ Home +++++++++++++++++++++++++++++++++
$("#goHome").on("click", function(event) {

    // Clear page
    clearTableData();
    showPlanetsTable(false);
    showPeopleTable(false);
    noResultsFound(false);
    showLogo(true);
});

//  ++++++++++++++++++++++ Search ++++++++++++++++++++++++++++++++++++
$("#search").on("click", async function(event) {

    // Clear page
    clearTableData();
    showPlanetsTable(false);
    showPeopleTable(false);
    showLogo(false);
    noResultsFound(false);

    showProgess(true);

    let search_text = $(".form-control").val();
    $(".form-control").val("");
    
    if(search_text === "")
    {
        showProgess(false);
        showLogo(true);
        return;
    }
    
    if(starWarsPeople === null)
        starWarsPeople = await getData("https://swapi.co/api/people/").then(result => result);

    if(starWarsPlanets === null)
        starWarsPlanets = await fetchData("https://swapi.co/api/planets/").then(result => result);
        // starWarsPlanets = await getData("https://swapi.co/api/planets/").then(result => result);

    let foundPeople = parsePeople(starWarsPeople).filter((elem) => {

        let  found = false;
        for (const key in elem) {
            if (elem.hasOwnProperty(key)) {
                const element = new String(elem[key]);
                if(element.indexOf(search_text) > -1)
                    found = true;
            }
        }
        return found;

    });

    let foundPlanets = parsePlanets(starWarsPlanets).filter((elem) => {

        let  found = false;
        for (const key in elem) {
            if (elem.hasOwnProperty(key)) {
                const element = new String(elem[key]);
                if(element.indexOf(search_text) > -1)
                    found = true;
            }
        }
        return found;

    });

    
    showProgess(false); 

    if(foundPeople.length > 0)
        populatePeopleTable(foundPeople);
    if(foundPlanets.length > 0)
        populatePlanetsTable(foundPlanets);
    
    if(foundPeople.length > 0)
        showPeopleTable(true);
    if(foundPlanets.length > 0)
        showPlanetsTable(true);

    if(foundPeople.length === 0 && foundPlanets.length === 0)
        noResultsFound(true);
})

//++++++++++++++++++++++++++++++++++++++ Sort people events ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
let asceding = true;
$("#people th:nth-child(1)").on("dblclick", (event) =>
{   
    let sort = [];
    if(asceding)
    {
        sort = parsePeople(starWarsPeople).sort( (e1,e2) => { 
                                                                if(e1.name <= e2.name) 
                                                                    return -1;
                                                                return 1;
                                                            } );
        asceding = !asceding;
    }
    else
    {
        sort = parsePeople(starWarsPeople).sort( (e1,e2) => { 
                                                                if(e1.name >= e2.name)
                                                                    return -1;
                                                                return 1;
                                                            } );
        asceding = !asceding;
    }

    clearTableData();
    populatePeopleTable(sort);
});

let sortGender = false;
$("#people th:nth-child(2)").on("dblclick", (event) =>
{
    let sort = [];
    if(sortGender)
    {
        sort = parsePeople(starWarsPeople).sort( (e1,e2) => { 
                                                                if(e1.gender >= e2.gender) 
                                                                    return -1;
                                                                return 1;
                                                            } );
        sortGender = !sortGender;
    }
    else
    {
        sort = parsePeople(starWarsPeople).sort( (e1,e2) => { 
                                                                if(e1.gender <= e2.gender) 
                                                                    return -1;
                                                                return 1;
                                                            } );
        sortGender = !sortGender;
    }

    clearTableData();
    populatePeopleTable(sort);
});

let sortDobAsc = true;
$("#people th:nth-child(3)").on("dblclick", (event) =>
{
    let sort = [];
    if(sortDobAsc)
    {
        sort = parsePeople(starWarsPeople).sort( (e1,e2) => { 
                                                                if(e1.birth_year >= e2.birth_year) 
                                                                    return -1;
                                                                return 1;
                                                            } );
        sortDobAsc = !sortDobAsc;
    }
    else
    {
        sort = parsePeople(starWarsPeople).sort( (e1,e2) => { 
                                                                if(e1.birth_year <= e2.birth_year) 
                                                                    return -1;
                                                                return 1;
                                                            } );
        sortDobAsc = !sortDobAsc;
    }

    clearTableData();
    populatePeopleTable(sort);
});

let sortHeightAsc = true;
$("#people th:nth-child(4)").on("dblclick", (event) =>
{
    let sort = [];
    if(sortHeightAsc)
    {
        sort = parsePeople(starWarsPeople).sort( (e1,e2) => { 
                                                                let n1 = Number(e1.height);
                                                                let n2 = Number(e2.height);

                                                                if(Number.isNaN(n1) && !isNaN(n2))
                                                                    return 1;

                                                                if(!isNaN(n1) && Number.isNaN(n2))
                                                                    return -1;

                                                                if(n1 >= n2) 
                                                                    return -1;
                                                                return 1;
                                                            } );
        sortHeightAsc = !sortHeightAsc;
    }
    else
    {
        sort = parsePeople(starWarsPeople).sort( (e1,e2) => { 
                                                                let n1 = Number(e1.height);
                                                                let n2 = Number(e2.height);

                                                                if(Number.isNaN(n1) && !isNaN(n2))
                                                                    return 1;

                                                                if(!isNaN(n1) && Number.isNaN(n2))
                                                                    return -1;

                                                                if(n1 <= n2) 
                                                                    return -1;
                                                                return 1;
                                                            } );
        sortHeightAsc = !sortHeightAsc;
    }

    clearTableData();
    populatePeopleTable(sort);
});

let sortMassAsc = true;
$("#people th:nth-child(5)").on("dblclick", (event) =>
{
    let sort = [];
    if(sortMassAsc)
    {
        sort = parsePeople(starWarsPeople).sort( (e1,e2) => { 
                                                                let n1 = Number(e1.mass);
                                                                let n2 = Number(e2.mass);

                                                                if(Number.isNaN(n1) && !isNaN(n2))
                                                                    return 1;

                                                                if(!isNaN(n1) && Number.isNaN(n2))
                                                                    return -1;

                                                                if(n1 >= n2) 
                                                                    return -1;
                                                                return 1;
                                                            } );
        sortMassAsc = !sortMassAsc;
    }
    else
    {
        sort = parsePeople(starWarsPeople).sort( (e1,e2) => { 
                                                                let n1 = Number(e1.mass);
                                                                let n2 = Number(e2.mass);

                                                                if(Number.isNaN(n1) && !isNaN(n2))
                                                                    return 1;

                                                                if(!isNaN(n1) && Number.isNaN(n2))
                                                                    return -1;

                                                                if(n1 <= n2) 
                                                                    return -1;
                                                                return 1;
                                                            } );
        sortMassAsc = !sortMassAsc;
    }

    clearTableData();
    populatePeopleTable(sort);
});

//++++++++++++++++++++++++++++++++++++++ Sort planets events ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
let sortPlanetNameAsc = true;
$("#planets th:nth-child(1)").on("dblclick", (event) =>
{
    let sort = [];
    if(sortPlanetNameAsc)
    {
        sort = parsePlanets(starWarsPlanets).sort( (e1,e2) => { 
                                                                if(e1.name <= e2.name) 
                                                                    return -1;
                                                                return 1;
                                                            } );
        sortPlanetNameAsc = !sortPlanetNameAsc;
    }
    else
    {
        sort = parsePlanets(starWarsPlanets).sort( (e1,e2) => { 
                                                                if(e1.name >= e2.name)
                                                                    return -1;
                                                                return 1;
                                                            } );
        sortPlanetNameAsc = !sortPlanetNameAsc;
    }

    clearTableData();
    populatePlanetsTable(sort);
});

let sortPlanetDiameterAsc = true;
$("#planets th:nth-child(2)").on("dblclick", (event) =>
{
    let sort = [];
    if(sortPlanetDiameterAsc)
    {
        sort = parsePlanets(starWarsPlanets).sort( (e1,e2) => { 
                                                                let n1 = Number(e1.diameter);
                                                                let n2 = Number(e2.diameter);

                                                                if(Number.isNaN(n1) && !isNaN(n2))
                                                                    return 1;

                                                                if(!isNaN(n1) && Number.isNaN(n2))
                                                                    return -1;

                                                                if(n1 <= n2) 
                                                                    return -1;
                                                                return 1;
                                                            } );
        sortPlanetDiameterAsc = !sortPlanetDiameterAsc;
    }
    else
    {
        sort = parsePlanets(starWarsPlanets).sort( (e1,e2) => { 
                                                                let n1 = Number(e1.diameter);
                                                                let n2 = Number(e2.diameter);

                                                                if(Number.isNaN(n1) && !isNaN(n2))
                                                                    return 1;

                                                                if(!isNaN(n1) && Number.isNaN(n2))
                                                                    return -1;

                                                                if(n1 >= n2)
                                                                    return -1;
                                                                return 1;
                                                            } );
        sortPlanetDiameterAsc = !sortPlanetDiameterAsc;
    }

    clearTableData();
    populatePlanetsTable(sort);
});

let sortPlanetClimateAsc = true;
$("#planets th:nth-child(3)").on("dblclick", (event) =>
{
    let sort = [];
    if(sortPlanetClimateAsc)
    {
        sort = parsePlanets(starWarsPlanets).sort( (e1,e2) => { 
                                                                if(e1.climate <= e2.climate) 
                                                                    return -1;
                                                                return 1;
                                                            } );
        sortPlanetClimateAsc = !sortPlanetClimateAsc;
    }
    else
    {
        sort = parsePlanets(starWarsPlanets).sort( (e1,e2) => { 
                                                                if(e1.climate >= e2.climate)
                                                                    return -1;
                                                                return 1;
                                                            } );
        sortPlanetClimateAsc = !sortPlanetClimateAsc;
    }

    clearTableData();
    populatePlanetsTable(sort);
});

let sortPlanetTerrainAsc = true;
$("#planets th:nth-child(4)").on("dblclick", (event) =>
{
    let sort = [];
    if(sortPlanetTerrainAsc)
    {
        sort = parsePlanets(starWarsPlanets).sort( (e1,e2) => { 
                                                                if(e1.terrain <= e2.terrain) 
                                                                    return -1;
                                                                return 1;
                                                            } );
        sortPlanetTerrainAsc = !sortPlanetTerrainAsc;
    }
    else
    {
        sort = parsePlanets(starWarsPlanets).sort( (e1,e2) => { 
                                                                if(e1.terrain >= e2.terrain)
                                                                    return -1;
                                                                return 1;
                                                            } );
        sortPlanetTerrainAsc = !sortPlanetTerrainAsc;
    }

    clearTableData();
    populatePlanetsTable(sort);
});

let sortPlanetRotationPeriodAsc = true;
$("#planets th:nth-child(5)").on("dblclick", (event) =>
{
    let sort = [];
    if(sortPlanetRotationPeriodAsc)
    {
        sort = parsePlanets(starWarsPlanets).sort( (e1,e2) => { 
                                                                let n1 = Number(e1.rotation_period);
                                                                let n2 = Number(e2.rotation_period);

                                                                if(Number.isNaN(n1) && !isNaN(n2))
                                                                    return 1;

                                                                if(!isNaN(n1) && Number.isNaN(n2))
                                                                    return -1;

                                                                if(n1 >= n2) 
                                                                    return -1;
                                                                return 1;
                                                            } );
        sortPlanetRotationPeriodAsc = !sortPlanetRotationPeriodAsc;
    }
    else
    {
        sort = parsePlanets(starWarsPlanets).sort( (e1,e2) => { 
                                                                let n1 = Number(e1.rotation_period);
                                                                let n2 = Number(e2.rotation_period);

                                                                if(Number.isNaN(n1) && !isNaN(n2))
                                                                    return 1;

                                                                if(!isNaN(n1) && Number.isNaN(n2))
                                                                    return -1;

                                                                if(n1 <= n2)
                                                                    return -1;
                                                                return 1;
                                                            } );
        sortPlanetRotationPeriodAsc = !sortPlanetRotationPeriodAsc;
    }

    clearTableData();
    populatePlanetsTable(sort);
});

let sortPlanetPopulationeAsc = true;
$("#planets th:nth-child(6)").on("dblclick", (event) =>
{
    let sort = [];
    if(sortPlanetPopulationeAsc)
    {
        sort = parsePlanets(starWarsPlanets).sort( (e1,e2) => { 
                                                                let n1 = Number(e1.population);
                                                                let n2 = Number(e2.population);

                                                                if(Number.isNaN(n1) && !isNaN(n2))
                                                                    return 1;

                                                                if(!isNaN(n1) && Number.isNaN(n2))
                                                                    return -1;

                                                                if(n1 >= n2) 
                                                                    return -1;
                                                                return 1;
                                                            } );
        sortPlanetPopulationeAsc = !sortPlanetPopulationeAsc;
    }
    else
    {
        sort = parsePlanets(starWarsPlanets).sort( (e1,e2) => { 
                                                                let n1 = Number(e1.population);
                                                                let n2 = Number(e2.population);

                                                                if(Number.isNaN(n1) && !isNaN(n2))
                                                                    return 1;

                                                                if(!isNaN(n1) && Number.isNaN(n2))
                                                                    return -1;

                                                                if(n1 <= n2)
                                                                    return -1;
                                                                return 1;
                                                            } );
        sortPlanetPopulationeAsc = !sortPlanetPopulationeAsc;
    }

    clearTableData();
    populatePlanetsTable(sort);
});

// ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++