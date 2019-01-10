$(
() => {
    
    $("#ShowContries").on("click", function(event)
    {
        let country = $("#contries").val();
        $.ajax(
            {   
                url: `https://restcountries.eu/rest/v2/region/${country}`,
                success: function(response){
                    populateTable(response)
                },
                error: function(response){
                    let tbody = $("#countriesTable tbody");
                    let row = $("<tr>");
                    row.append(`<td>Error geting data</td>
                                <td>Error geting data</td>
                                <td>Error geting data</td>`);
                    tbody.append(row);
                }
            }
        )
    })

    function showCountryInfo(country)
    {   
        let countryTable = $("#country");
        countryTable.remove();
        $("#deleteCountryInfo").remove();

        $("#info").append(`<table id="country">
                                <thead>
                                    <tr>
                                        <th colspan="2">Country Info</th>
                                    </tr>
                                </thead>

                                <tbody>
            
                                </tbody>

                            </table>`);
        
        countryTable = $("#country");
        let tbody = $("#country tbody");

        let countryProps = [{property: "name", display: "Name"}, 
                            {property: "alpha3Code", display: "Short code"}, 
                            {property: "capital", display: "Capital"}, 
                            {property: "languages", display: "Language/s"},
                            {property: "flag", display: "Flag"}];

        for (const countryProp of countryProps) 
        {  
            let row = $("<tr>"); 
            if(countryProp.property === "flag")
            {
                // Add flag
                let flag = `<td>${countryProp.display}</td>
                            <td><img src="${country[countryProp.property]}" width="50"></td>`;
                row.append(flag);
            }
            else if(countryProp.property === "languages")
            {
                // // Add languages
                let languages = country.languages;
                let langColumn = `<td>`;
                for (const lang of languages) 
                    langColumn += `${lang.name},`;
                langColumn = langColumn.substring(0, langColumn.length - 1);
                langColumn += `</td>`;
                row.append(`<td>${countryProp.display}</td>${langColumn}`);
            }
            else
            {
                row.append(`<td>${countryProp.display}</td>
                            <td>${country[countryProp.property]}</td>`);
            }

            // Add row to table
            tbody.append(row);
        }
        
        $("#info").append(`<button id="deleteCountryInfo">X</button>`);

        $("#deleteCountryInfo").on("click", function(event)
        {
            countryTable.remove();
            event.target.remove();
        });
    }

    function populateTable(contries)
    {   
        let tbody = $("#countriesTable tbody");
        let rows = $("#countriesTable tbody tr");

        if(rows.length > 0)
        {
            tbody.remove();
            $("#countriesTable").append("<tbody></tbody>");
            tbody = $("#countriesTable tbody");
        }

        let row = $("<tr>");
        for (const country of contries) 
        {   
            let row = $("<tr>");
            row.append(`<td id="${country.name}" class="click">${country.name}</td>
                        <td>${country.capital}</td>`);

            // Add currencies
            let currencies = country.currencies;
            let currColumn = `<td>`;
            for (const curr of currencies) 
                currColumn += `${curr.name},`;
            currColumn = currColumn.substring(0, currColumn.length - 1);
            currColumn += `</td>`;
            row.append(currColumn);

            // Add flag
            let flagColumn = `<td><img src="${country.flag}" width="50"></td>`;
            row.append(flagColumn);
            
            $(row).find("td:first").on("click", function(event)
            {   
                $.ajax(
                {   
                        url: `https://restcountries.eu/rest/v2/name/${$(event.target).attr("id")}`,

                        success: function(response){
                            showCountryInfo(response[0]);
                        },

                        error: function(response){
                            let tbody = $("#country tbody");
                            let row = $("<tr>");
                            row.append(`<td>Error geting data</td>
                                        <td>Error geting data</td>`);
                            tbody.append(row);
                        }
                })
            }
            )

            // Add row to table
            tbody.append(row);
        }
    }
})