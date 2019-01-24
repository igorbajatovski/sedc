function setArray()
{
    let arr = [];
    for(let i = 0; i < 100; ++i)
    {
        if(Math.random() > 0.05)
            arr.push(i);
    }
    return arr;
}



function findMissingNumbersFromArray(array)
{
    let missingNumbersArray = [];
    for(let i = 0; i < 100; ++i)
    {
        let found = false;
        for(let j = 0; j <= i; ++j)
        {
            if(array[j] === i)
                found = true;
        }
        
        if(!found)
            missingNumbersArray.push(i);
    }
    return missingNumbersArray;
}

let arr = setArray();
console.log(arr.join());
console.log(`Missing number are: ${findMissingNumbersFromArray(arr).join()}`);