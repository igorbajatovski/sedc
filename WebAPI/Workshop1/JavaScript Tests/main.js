let FirstNames = 
[
"James",
"Christopher",
"Ronald",
"Mary",
"Lisa",
"Michelle",
"John",
"Daniel",
"Anthony",
"Patricia",
"Nancy",
"Laura",
"Robert",
"Paul",
"Kevin",
"Linda",
"Karen",
"Sarah",
"Michael",
"Mark",
"Jason",
"Barbara",
"Betty",
"Kimberly",
"William",
"Donald",
"Jeff",
"Elizabeth",
"Helen",
"Deborah",
"David",
"George",
"Jennifer",
"Sandra",
"Richard",
"Kenneth",
"Maria",
"Donna",
"Charles",
"Steven",
"Susan",
"Carol",
"Joseph",
"Edward",
"Margaret",
"Ruth",
"Thomas",
"Brian",
"Dorothy",
"Sharon"
]

let LastNames = 
[
"Anderson",
"Clark",
"Wright",
"Mitchell",
"Johnson",
"Thomas",
"Rodriguez",
"Lopez",
"Perez",
"Williams",
"Jackson",
"Lewis",
"Hill",
"Roberts",
"Jones",
"White",
"Lee",
"Scott",
"Turner",
"Brown",
"Harris",
"Walker",
"Green",
"Phillips",
"Davis",
"Martin",
"Hall",
"Adams",
"Campbell",
"Miller",
"Thompson",
"Allen",
"Baker",
"Parker",
"Wilson",
"Garcia",
"Young",
"Gonzalez",
"Evans",
"Moore",
"Martinez",
"Hernandez",
"Nelson",
"Edwards",
"Taylor",
"Robinson",
"King",
"Carter",
"Collins"
]

function callWebApiFunction(url, method, bodyMessage, time)
{
    let xmlhttp = new XMLHttpRequest();
                
    xmlhttp.onreadystatechange = function() {
        if (xmlhttp.readyState == XMLHttpRequest.DONE) {   // XMLHttpRequest.DONE == 4
            if (xmlhttp.status == 200) {
                console.log(`User ${bodyMessage.Username} is registered`);
            }
            else if (xmlhttp.status == 400) {
                console.log(`User ${bodyMessage.Username} is not registered. Reason ${xmlhttp.status},${xmlhttp.responseText}.`);
            }
            else {
                console.log(`User ${bodyMessage.Username} is not registered. Reason ${xmlhttp.status},${xmlhttp.responseText}.`);
            }
        }
    }; // end of onreadystatechange
    
    setTimeout(() => 
    {  
        xmlhttp.open(method, url, true);
        xmlhttp.setRequestHeader("Content-Type", "application/json");
        try
        {
            xmlhttp.send(bodyMessage);
        }catch(e)
        {
            console.log(e);
        }
    }, time);
}


function enterLotoUsers(separator, startFirstName, startLastName)
{
        let time = 0;
        for(let i = startFirstName; i < FirstNames.length; ++i)
        {
            for(let j = startLastName; j < LastNames.length; ++j)
            {      
                let xmlhttp = new XMLHttpRequest();
                
                xmlhttp.onreadystatechange = function() {
                    if (xmlhttp.readyState == XMLHttpRequest.DONE) {   // XMLHttpRequest.DONE == 4
                        if (xmlhttp.status == 200) {
                            console.log(`User[${i}][${j}] ${FirstNames[i]}${separator}${LastNames[j]} is registered`);
                        }
                        else if (xmlhttp.status == 400) {
                            console.log(`User[${i}][${j}] ${FirstNames[i]}${separator}${LastNames[j]} is not registered. Reason ${xmlhttp.status},${xmlhttp.responseText}.`);
                        }
                        else {
                            console.log(`User[${i}][${j}] ${FirstNames[i]}${separator}${LastNames[j]} is not registered. Reason ${xmlhttp.status},${xmlhttp.responseText}.`);
                        }
                    }
                }; // end of onreadystatechange
                
                setTimeout(() => 
                {  
                    xmlhttp.open("POST", "https://localhost:5001/api/users/Register",true);
                    xmlhttp.setRequestHeader("Content-Type", "application/json");
                    try
                    {
                        xmlhttp.send(
                            `{  
                                "Username":"${FirstNames[i]}${separator}${LastNames[j]}",
                                "Password":"Password${i}${j}",
                                "Firstname":"${FirstNames[i]}",
                                "Lastname":"${LastNames[j]}"
                            }`
                        );
                    }catch(e)
                    {
                        console.log(e);
                    }
                }, time+= 200 );
            }

            j = 0;

        }//end of for
}

function enterLotoUsers(userJSon)
{
    callWebApiFunction("https://localhost:5001/api/users/Register", "POST", userJSon, 200);
}

let userjSon = 
    `{  
        "Username":"",
        "Password":"Password",
        "Firstname":"Igor",
        "Lastname":"Bajatovski"
    }`
enterLotoUsers(userjSon);

userjSon = 
    `{  
        "Username":"igor.bajatovski",
        "Password":"",
        "Firstname":"Igor",
        "Lastname":"Bajatovski"
    }`
enterLotoUsers(userjSon);

userjSon = 
    `{  
        "Username":"igor.bajatovski",
        "Password":"Password",
        "Firstname":"",
        "Lastname":"Bajatovski"
    }`
enterLotoUsers(userjSon);

userjSon = 
    `{  
        "Username":"igor.bajatovski",
        "Password":"Password",
        "Firstname":"Igor",
        "Lastname":""
    }`
enterLotoUsers(userjSon);

userjSon = 
    `{  
        "Username":"igor.bajatovskiiiiiiiiiiiiiiiiiiiiiiiii",
        "Password":"Password",
        "Firstname":"Igor",
        "Lastname":"Bajatovski"
    }`
enterLotoUsers(userjSon);

userjSon = 
    `{  
        "Username":"igor.bajatovski",
        "Password":"Passworddddddddddddddddddddddddddddddddddddddd",
        "Firstname":"Igor",
        "Lastname":"Bajatovski"
    }`
enterLotoUsers(userjSon);

userjSon = 
    `{  
        "Username":"igor.bajatovski",
        "Password":"Password",
        "Firstname":"Igorrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr",
        "Lastname":"Bajatovski"
    }`
enterLotoUsers(userjSon);

userjSon = 
    `{  
        "Username":"igor.bajatovski",
        "Password":"Password",
        "Firstname":"Igor",
        "Lastname":"Bajatovskiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii"
    }`
enterLotoUsers(userjSon);

let separator = "@";
//enterLotoUsers(separator, 0, 0);