function recepie()
{
    let sRecepei = prompt("Enter the name of the recepie");
    if(sRecepei !== "")
    {
        let numOfIngredients = prompt("How many ingrediants does your recepie has");
        if(numOfIngredients !== ""  && !isNaN(numOfIngredients) && Number(numOfIngredients) > 0)
        {
            let ingrediants = [];
            for(let i = 0; i < numOfIngredients; ++i)
            {
                let ingrediant = prompt(`Enter ingrediant #${i + 1}`);
                if(ingrediant !== "" && isNaN(ingrediant))
                {
                    ingrediants.push(ingrediant);
                }
            }

            if(ingrediants.length !== Number(numOfIngredients))
            {
                let recepieElem = document.getElementById("recepie")
                let msgElem = recepieElem.innerHTML = "<h1>Your recepie could not be generated. You must enter all ingrediants!</h1>"
            }


            // Generate the recepie
            let recepieElem = document.getElementById("recepie")
            // Print the Recepie Name
            recepieElem.innerHTML = `<h1>${sRecepei}</h1>`;
            // Print ingrediatns
            let list = `<ul">`;
            for(let ingrediant of ingrediants)
            {
                list += `<li>${ingrediant}</li>`;
            }
            list += "</ul>";
            recepieElem.innerHTML += list;
            recepieElem.setAttribute("style", "text-align: center;");
        }
        else
        {
            let recepieElem = document.getElementById("recepie")
            let msgElem = recepieElem.innerHTML = "<h1>Your recepie could not be generated. Enter number of ingrediants!</h1>"    
        }
    }
    else
    {
        let recepieElem = document.getElementById("recepie")
        let msgElem = recepieElem.innerHTML = "<h1>Your recepie could not be generated. Enter name of recepie!</h1>"
    }

}


recepie();