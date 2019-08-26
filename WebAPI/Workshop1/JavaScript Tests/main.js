let FirstNames = 
[
    "James","Christopher","Ronald","Mary","Lisa","Michelle",
 "John","Daniel","Anthony","Patricia","Nancy","Laura",
 "Robert","Paul","Kevin","Linda","Karen","Sarah",
 "Michael","Mark","Jason","Barbara","Betty","Kimberly",
 "William","Donald","Jeff","Elizabeth","Helen","Deborah",
 "David","George","Jennifer","Sandra",
 "Richard","Kenneth","Maria","Donna",
 "Charles","Steven","Susan","Carol",
 "Joseph","Edward","Margaret","Ruth",
 "Thomas","Brian","Dorothy","Sharon"
]

let LastNames = 
[
    "Anderson","Clark","Wright","Mitchell","Johnson","Thomas","Rodriguez","Lopez","Perez","Williams",
    "Jackson","Lewis","Hill","Roberts","Jones","White","Lee","Scott","Turner","Brown","Harris","Walker",
    "Green","Phillips","Davis","Martin","Hall","Adams","Campbell","Miller","Thompson","Allen","Baker",
    "Parker","Wilson","Garcia","Young","Gonzalez","Evans","Moore","Martinez","Hernandez","Nelson","Edwards",
    "Taylor","Robinson","King","Carter","Collins"
]


let separator = ".";


function enterLotoUsers(separator, startFirstName, startLastName)
{
    for(let i = startFirstName; i < FirstNames.length; ++i)
    {
        for(let j = startLastName; j < LastNames.length; ++j)
        {
            let xmlhttp = new XMLHttpRequest();
            
            xmlhttp.onreadystatechange = function() {
                if (xmlhttp.readyState == XMLHttpRequest.DONE) {   // XMLHttpRequest.DONE == 4
                    if (xmlhttp.status == 200) {
                        console.log(`User ${firstName}${separator}${lastName} is registered`);
                    }
                    else if (xmlhttp.status == 400) {
                        console.log(`User ${firstName}${separator}${lastName} is not registered. Reason ${xmlhttp.status}.`);
                    }
                    else {
                        console.log(`User ${firstName}${separator}${lastName} is not registered. Reason ${xmlhttp.status}.`);
                    }
                }
            };
            xmlhttp.setRequestHeader("Content-Type", "application/json");
            xmlhttp.open("POST", "https://localhost:5001/api/users",false);
            xmlhttp.send(
                "{" + 
                    `Username:${firstName}${separator}${lastName},
                    "Firstname:"${firstName},
                    "Lastname:"${lastName},
                    "Balance:"1000,
                    "Role:2"`
                + "}"
            );
        }
    }
}