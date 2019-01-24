
function cleanUp(array)
{
    let cleanedArray = [];
    for (const elem of array) 
    {
        if(elem instanceof Array)
        {
            // if elem is Array
            cleanedArray.push(cleanUp(elem));
        }
        else
        {
            // if elem is not falsie
            if(elem)
                cleanedArray.push(elem);
            else if(elem === 0)
                cleanedArray.push(elem);
        }
    }
    return cleanedArray;
}


let arr = [1, NaN, 2, [3, NaN, 5] ];
console.log(cleanUp(arr));
console.log(cleanUp(arr).join());

arr = [1, NaN, 2, undefined, 8, false, 11, 
        [ null, 21, undefined, "Vlatko",
            [null, 32, "", "sdfsd", 0], 26, 23, NaN,  ""], 456, "", 0, 
                [3, NaN, 5] ];

console.log(cleanUp(arr));
console.log(cleanUp(arr).join());