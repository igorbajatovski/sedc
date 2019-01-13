function reversNumber(number)
{   
    let reversNumberArray = [];
    while(number !== 0)
    {
        let digit = number  % 10;
        reversNumberArray.push(digit);
        number = parseInt(number / 10);
    }
    return Number(reversNumberArray.join(""));
}


console.log(reversNumber(32243));

console.log(reversNumber(1000000000000000000));

console.log(reversNumber(100000000002));

console.log(reversNumber(10000000000000000002));