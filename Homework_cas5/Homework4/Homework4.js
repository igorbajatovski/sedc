function weightInChickens(weight)
{
    return (weight / 0.5).toFixed(2);
}

function showResult(result)
{
    let resultElem = document.getElementById("result");
    resultElem.innerHTML = result;
}

function enterWeight()
{
    let weight = prompt("Enter weight");
    if(weight !== "" && !isNaN(weight) && Number(weight) > 0)
    {
        weightChicken = weightInChickens(weight);
        showResult(`<p style="font-weight: bold">You weigh ${weightChicken} chickens</p>`);
    }
}


enterWeight();