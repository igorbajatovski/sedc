let arrayOfNumbers = [4,8,7,9,56,45,12,23,7,12,45,26,65,1];

function printNumbers()
{
    let container = document.getElementById("container");

    if(document.getElementById("numbers") === null)
    {
        // add the ul tag to the container div
        let ulElem = document.createElement("ul");
        ulElem.setAttribute("id", "numbers");
        container.appendChild(ulElem);

        let sum = 0;
        let sumEquation = "";
        // Add the list items (li) to the ul tag
        for(let i = 0; i < arrayOfNumbers.length; i+=1)
        {
            // Create the list item
            let list_item = document.createElement("li");
            // Add text node to the list item
            list_item.appendChild(document.createTextNode(arrayOfNumbers[i]));
            // Create attribute to add to the list item
            let attribute = document.createAttribute('style');
            attribute.value = "font-weight: bold; color:  red";
            // Add the attribute to the list item
            list_item.setAttributeNode(attribute);
            // Add the list item to the ul tag
            ulElem.appendChild(list_item);
            // Add to the sum
            sum += arrayOfNumbers[i];
            // Make the sum equation
            if( i !== (arrayOfNumbers.length - 1 ) )
                sumEquation += `${arrayOfNumbers[i]} + `;
            else
                sumEquation += `${arrayOfNumbers[i]}`;
        }

        // Add the sum at the end of the ul list
        let sumParagraph = document.createElement("p");
        sumParagraph.textContent = `Sum of above list is ${sum}`;
        ulElem.after(sumParagraph);

        // Add the sum equation after the above paragraph
        let equationParagraph = document.createElement("p");
        equationParagraph.textContent = `${sumEquation} = ${sum}`;
        sumParagraph.after(equationParagraph);
    }
}