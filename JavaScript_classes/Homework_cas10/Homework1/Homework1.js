$(

() => {

   let starWarsPersons = [];

    function max(collection, propertyOfItem)
    {
        let max = collection[0];
        for (const item of collection) {
            if(parseInt(item[propertyOfItem]) > parseInt(max[propertyOfItem]))
                max = item;
        }
        return max;
    }

   function printStarWarsPersons()
   {
        body = $("body");
        let ul = $("<ul>");
        
        for (const person of starWarsPersons) {
            let li = $("<li>");
            li.text(person.name);
            ul.append(li);
        }

        body.append(ul);

        body.append(`<div>The person "${max(starWarsPersons, "height").name}" is the highest!<div>`)
        body.append(`<div>The person "${max(starWarsPersons, "mass").name}" is the heaviest!<div>`)
   }


   function getStartWarsPersons(starWarsPersons, numOfPersons, callBackFunction)
   {
        if(numOfPersons > 0)
        {
            $.ajax(
                {
                    url: `https://swapi.co/api/people/${numOfPersons}/`,

                    success: function(response)
                    {
                        starWarsPersons.push(response);
                        getStartWarsPersons(starWarsPersons, numOfPersons - 1, callBackFunction);
                        
                        if(numOfPersons === 1)
                            callBackFunction();
                    },

                    error: function(response)
                    {
                        
                    }
                }
            );
        }
   }

   getStartWarsPersons(starWarsPersons, 3, printStarWarsPersons);
}

)