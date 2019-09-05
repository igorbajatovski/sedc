
function callWebApiMethod(url, method, bodyMessage = null, timeDelay = 0, token = null)
{      
    let prom = new Promise( (resolve, reject) =>
    {
        setTimeout( () => 
        {  
            let xmlhttp = new XMLHttpRequest();
            xmlhttp.onreadystatechange = function(ev) {
                if (this.readyState == XMLHttpRequest.DONE) {   // XMLHttpRequest.DONE == 4
                    if (this.status == 200) {
                        resolve(this.responseText);
                    }
                    else if (this.status == 400) {
                        reject(`Request failed. Reason ${this.status},${this.responseText}`);
                    }
                    else {
                        reject(`Request failed. Reason ${this.status},${this.responseText}`);
                    }
                }
            }; // end of onreadystatechange
            
            xmlhttp.open(method, url, true);
            xmlhttp.setRequestHeader("Content-Type", "application/json");
            if(token !== null)
                xmlhttp.setRequestHeader("Authorization", `Bearer ${token}`);
            if(bodyMessage !== null)
                xmlhttp.send(bodyMessage);
            else
                xmlhttp.send();

        }, timeDelay);
    });

    return prom;
}

function loginUser(userJson, time)
{
    return callWebApiMethod("https://localhost:5001/api/users/login/", "POST", userJson, time);
}

async function enterTicket(ticketJSon, time, token)
{
    return callWebApiMethod("https://localhost:5001/api/tickets/Register/", "POST", ticketJSon, time, token);
}

async function enterTickets(separator)
{   
    //let userIds =  await callWebApiMethod("https://localhost:5001/api/users/GetUserIds/", "GET").then(value => JSON.parse(value)).catch(reason => reason);
    //console.log(userIds);

    let time1 = 0;
    let time2 = 0;
    for(let i = 0; i < FirstNames.length; ++i)
    {
        for(let j = 0; j < LastNames.length; ++j)
        {   
            let userJSon = 
                `{
                    "Username": "${FirstNames[i]}${separator}${LastNames[j]}",
                    "Password": "Password${i}${j}"
                }`
            
            loginUser(userJSon, time1 += 200).then(
                response => {

                    let user = JSON.parse(response);
                    console.log(`User ${user.username} is logged in.`);
                    let ticketCombination = generateTicketCombination(1,37);
                    let ticketJSon = 
                        `{  
                            "Combination":"${ticketCombination.join(',')}"
                        }`
                    
                    enterTicket(ticketJSon, time2 += 200, user.token).then(
                        value => console.log(value)
                    ).catch(error => console.log(error));

                }
            ).catch(error => console.log(error));
        }
    }
}

function generateTicketCombination(from, to)
{
    /* Generate random ticket with numbers between 1 and 37 */

    let randomNums = [];
    while(randomNums.length < 7)
    {
        let randNum = Math.random();
        randNum *= to;
        randNum = Math.round(randNum);

        if(randNum >= from && randNum <= to)
        {   
            if(randomNums.findIndex(e => e === randNum) == -1)
                randomNums.push(randNum);
        }
    }
    return randomNums;
}

/* ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ */

// let token = `eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IlBhdHJpY2lhIFdhbGtlciIsImVtYWlsIjoiUGF0cmljaWEuV2Fsa2VyIiwibmFtZWlkIjoiNTUxNiIsIm5iZiI6MTU2NzUzMjU4MSwiZXhwIjoxNTY4MTM3MzgxLCJpYXQiOjE1Njc1MzI1ODF9.hQBkzFghPQAmlrxExXgiUfXMD68dxB_I998vZUmvx4I`;

// let time = 200;

// let ticketJSon = 
//     `{  
//         "UserId":1,
//         "Combination":"1,2,3,4,5,6,7,8"
//     }`
// enterTicket(ticketJSon, time, token);

// ticketJSon = 
//     `{  
//         "UserId":1,
//         "Combination":"1,2,3,4,5,6"
//     }`
// enterTicket(ticketJSon, time =+ 200, token);

// ticketJSon = 
//     `{  
//         "UserId":1,
//         "Combination":"1,2,6,4,5,6,9"
//     }`
// enterTicket(ticketJSon, time =+ 200, token);

// ticketJSon = 
//     `{  
//         "UserId":1,
//         "Combination":"-1,2,3,4,5,6,9"
//     }`
// enterTicket(ticketJSon, time =+ 200, token);

// ticketJSon = 
//     `{  
//         "UserId":1,
//         "Combination":"1,2,3,4,38,6,9"
//     }`
// enterTicket(ticketJSon, time =+ 200, token);

// ticketJSon = 
//     `{  
//         "UserId":1,
//         "Combination":"1,2,b,4,5,6,9"
//     }`
// enterTicket(ticketJSon, time =+ 200, token);

// ticketJSon = 
//     `{  
//         "UserId":1,
//         "Combination":""
//     }`
// enterTicket(ticketJSon, time =+ 200, token);

// ticketJSon = 
//     `{  
//         "UserId":9999999,
//         "Combination":"1,2,3,4,5,6,9"
//     }`
// enterTicket(ticketJSon, time =+ 200, token);


// ticketJSon = 
//     `{  
//         "UserId":,,
//         "Combination":"1,2,3,4,5,6,9"
//     }`
// enterTicket(ticketJSon, time =+ 200, token);

// ticketJSon = 
//     `{  
//         "UserId":a,
//         "Combination":"1,2,3,4,5,6,9"
//     }`
// enterTicket(ticketJSon, time =+ 200);

// ticketJSon = 
//     `{  
//         "UserId":"a",
//         "Combination":"1,2,3,4,5,6,9"
//     }`
// enterTicket(ticketJSon, time =+ 200);

enterTickets("_");

/* ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ */