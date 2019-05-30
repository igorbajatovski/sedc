const familyTree = [
{
    name: "Oliver",
    lastname: "Stones",
    childrens: [
        {
            name: "Viktor",
            lastname: "Stones",
            childrens: []
        },
        {
            name: "Suzan",
            lastname: "Sloun",
            childrens: [
                {
                    name: "Oliver jr",
                    lastname: "Sloun",
                    childrens: [
                        {
                            name: "Alexandar",
                            lastname: "Sloun",
                            childrens: [
                                {
                                    name: "Suzie",
                                    lastname: "Sloun",
                                    childrens: []
                                }
                            ]
                        }
                    ]
                },
                {
                    name: "Alex",
                    lastname: "Sloun",
                    childrens: [
                        {
                            name: "Gabriel",
                            lastname: "Sloun",
                            childrens: [
                                {
                                    name: "Gabriela",
                                    lastname: "Sloun",
                                    childrens: []
                                }
                            ]
                        }
                    ]
                }
            ]
        }
    ]
}
];

function getDescedents(descendants)
{
    // debugger;
    let desc = [];
    for (const descendant of descendants)
    {
        desc.push({name: descendant.name, lastname: descendant.lastname});
        if(descendant.childrens.length > 0)
            desc.push(...getDescedents(descendant.childrens));
    }

    return desc;
}

function findAllDescedents(member, familyTree)
{
    // debugger;
    let descendants = null;
    for (const memb of familyTree) 
    {
        if( member.name === memb.name && member.lastname === memb.lastname )
        {
            // When parent member is found get his descendants
            if(memb.childrens.length > 0)
                descendants = getDescedents(memb.childrens);
        }
        else
        {   // if parent member is not found, continue with the search
            if(memb.childrens.length > 0)
            {
                // if descendants (!== null) are found do not search for other parent member
                if(descendants === null)
                    descendants = findAllDescedents(member, memb.childrens);
            }
        }
    }

    return descendants;
}

console.log(findAllDescedents({name:"Oliver", lastname: "Stones"},familyTree));
console.log(findAllDescedents({name:"Alex", lastname: "Sloun"},familyTree));
console.log(findAllDescedents({name:"Alexandar", lastname: "Sloun"},familyTree));
console.log(findAllDescedents({name:"Oliver jr", lastname: "Sloun"},familyTree));
console.log(findAllDescedents({name:"Suzan", lastname: "Sloun"},familyTree));