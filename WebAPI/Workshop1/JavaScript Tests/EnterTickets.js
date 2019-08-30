
function callWebApiMethod(url, method, bodyMessage = null, timeDelay = 0)
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
                        reject(`Request failed. Reason ${this.status},${this.responseText}.`);
                    }
                    else {
                        reject(`Request failed. Reason ${this.status},${this.responseText}.`);
                    }
                }
            }; // end of onreadystatechange
            
            xmlhttp.open(method, url, true);
            xmlhttp.setRequestHeader("Content-Type", "application/json");
            if(bodyMessage !== null)
                xmlhttp.send(bodyMessage);
            else
                xmlhttp.send();

        }, timeDelay);
    });

    return prom;
}

async function enterTicket(ticketJSon, time)
{
    let response =  await callWebApiMethod("https://localhost:5001/api/tickets/Register/", "POST", ticketJSon, time)
                                .then(value => value)
                                .catch(reason => reason);
    console.log(response);
}

async function enterTickets()
{
    /* Generate random ticket with numbers between 1 and 37 */

    /********************************************************/

    let userIds =  await callWebApiMethod("https://localhost:5001/api/users/GetUserIds/", "GET")
                                .then(value => value)
                                .catch(reason => reason);
    console.log(userIds);
}

/* ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ */

let time = 200;

let ticketJSon = 
    `{  
        "UserId":1,
        "Combination":"1,2,3,4,5,6,7,8",
    }`
enterTicket(ticketJSon, time);

ticketJSon = 
    `{  
        "UserId":1,
        "Combination":"1,2,3,4,5,6",
    }`
enterTicket(ticketJSon, time =+ 200);

ticketJSon = 
    `{  
        "UserId":1,
        "Combination":"1,2,6,4,5,6,9",
    }`
enterTicket(ticketJSon, time =+ 200);

ticketJSon = 
    `{  
        "UserId":1,
        "Combination":"-1,2,3,4,5,6,9",
    }`
enterTicket(ticketJSon, time =+ 200);

ticketJSon = 
    `{  
        "UserId":1,
        "Combination":"1,2,3,4,38,6,9",
    }`
enterTicket(ticketJSon, time =+ 200);

ticketJSon = 
    `{  
        "UserId":1,
        "Combination":"1,2,b,4,5,6,9",
    }`
enterTicket(ticketJSon, time =+ 200);

ticketJSon = 
    `{  
        "UserId":1,
        "Combination":"",
    }`
enterTicket(ticketJSon, time =+ 200);

ticketJSon = 
    `{  
        "UserId":9999999,
        "Combination":"1,2,3,4,5,6,9",
    }`
enterTicket(ticketJSon, time =+ 200);

enterTickets();

console.log("ZAVRSIV")
/* ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ */