let str = `Web Development Tutorial`;
let str1 = `Lorem ipsum dolor, sit amet consectetur adipisicing elit. 
            Adipisci molestiae ipsam similique recusandae? Pariatur eligendi rem odio eius. 
            Rerum dolores omnis, assumenda necessitatibus repellat laudantium deserunt ut provident. Quas, dicta.`;

function findLongestWord(str)
{
    let splits = str.split(" ");
    let longestWord = "";
    splits.forEach( (elem) =>
    {
        if( elem.length > longestWord.length )
            longestWord = elem;
    } );

    return longestWord;
}


console.log(findLongestWord(str));
console.log(findLongestWord(str1    ));