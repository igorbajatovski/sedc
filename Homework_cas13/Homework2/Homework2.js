function allStringCombinations(str)
{   
    let allCombinations = [];
    for(let i = 1; i <= str.length; ++i)
    {
        let allComb = combinations(i, str.length);
        for (const comb of allComb) {
            allCombinations.push(comb);
        }
    }

    let sComb = "";
    let allStringCombs = [];
    for (const comb of allCombinations) {
        for (const index of comb) {
            sComb += str[index-1];
        }
        allStringCombs.push(sComb);
        sComb = "";
    }

    return allStringCombs;
}


function copyArray(array)
{
    let newArray = [];
    for(let i = 0; i < array.length; ++i)
        newArray.push(array[i]);
    return newArray;
}

function combinations(combLength, length)
{
    // debugger;
    let allComb = [];
    let startComb = [];
    let endComb = [];
    let currComb = [];
    let l = length;
    for(let i = 1; i <= combLength; ++i)
    {
        startComb.push(i);
        currComb.push(i);
        endComb.unshift(l);
        l -= 1;
    }

    
    let end = false;
    while(true)
    {
        for(let i = startComb.length - 1; i >= 0; --i)
        {
            if(currComb[0] === endComb[0])
            {
                end = true;
                break;
            }
            
            if(currComb[i] === endComb[i])
            {
                allComb.push(copyArray(currComb));

                if( (i - 1) >= 0)
                    currComb[i-1] += 1;

                currComb[i] = currComb[i-1] + 1;

                if( (i + 1) < endComb.length)
                {
                    for(let j = i + 1; j < currComb.length; ++j)
                        currComb[j] = currComb[j-1] + 1;
                }
            }
        }

        allComb.push(copyArray(currComb));
        if(end) break;
        currComb[currComb.length- 1] += 1;
    }

    return allComb;
}

console.log(combinations(1, 5));
console.log(combinations(2, 5));
console.log(combinations(3, 5));
console.log(combinations(4, 6));
console.log(combinations(5, 6));
console.log(combinations(6, 6));
console.log(combinations(1, 3));
console.log(combinations(2, 3));
console.log(combinations(3, 3));

console.log("dog");
console.log(allStringCombinations("dog"));
console.log("doggy");
console.log(allStringCombinations("doggy"))