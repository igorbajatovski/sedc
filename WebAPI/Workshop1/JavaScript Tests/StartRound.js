
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

function Draw(time, token)
{
    return callWebApiMethod("https://localhost:5001/api/DrawRound/Draw/", "POST", null, time, token);
}

function GetWinningTicketsLastRound(time, token)
{
    return callWebApiMethod("https://localhost:5001/api/DrawRound/GetWinningTicketsLastRound/", "GET", null, time, token);
}

/* ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ */

let prom = null;

let adminUser = 
`
{
    "Username": "Admi",
    "Password": "Password00"
}
`;

//prom = loginUser(adminUser, 200);
// prom.then(

//     response => {
//         let user = JSON.parse(response);
//         console.log(user);
//         let prom1 = Draw(200, user.token);
//         prom1.then(
//             response => {
//                 console.log(response);
//                 let prom2 = GetWinningTicketsLastRound(200, user.token);
//                 prom2.then(
//                     response => {
//                         let winTickets = JSON.parse(response);
//                         console.log(winTickets);
//                     }
//                 )
//                 .catch(error => console.log(error));
//             }
//         ).catch(error => console.log(error));
//     }

// ).catch(error => console.log(error));


// adminUser = 
// `
// {
//     "Username": "Admin",
//     "Password": "Password00"
// }
// `;

// prom = loginUser(adminUser, 200);
// prom.then(

//     response => {
//         let user = JSON.parse(response);
//         console.log(user);
//         let prom1 = Draw(200, user.token.substr(0, user.token.length - 5));
//         prom1.then(
//             response => {
//                 console.log(response);
//                 let prom2 = GetWinningTicketsLastRound(200, user.token);
//                 prom2.then(
//                     response => {
//                         let winTickets = JSON.parse(response);
//                         console.log(winTickets);
//                     }
//                 )
//                 .catch(error => console.log(error));
//             }
//         ).catch(error => console.log(error));
//     }

// ).catch(error => console.log(error));

// adminUser = 
// `
// {
//     "Username": "James.Anderson",
//     "Password": "Password00"
// }
// `;

// prom = loginUser(adminUser, 200);
// prom.then(

//     response => {
//         let user = JSON.parse(response);
//         console.log(user);
//         let prom1 = Draw(200, user.token);
//         prom1.then(
//             response => {
//                 console.log(response);
//                 let prom2 = GetWinningTicketsLastRound(200, user.token);
//                 prom2.then(
//                     response => {
//                         let winTickets = JSON.parse(response);
//                         console.log(winTickets);
//                     }
//                 )
//                 .catch(error => console.log(error));
//             }
//         ).catch(error => console.log(error));
//     }

// ).catch(error => console.log(error));




adminUser = 
`
{
    "Username": "Admin",
    "Password": "Password00"
}
`;

prom = loginUser(adminUser, 200);
prom.then(

    response => {
        let user = JSON.parse(response);
        console.log(user);
        let prom1 = Draw(200, user.token);
        prom1.then(
            response => {
                console.log(response);
                let prom2 = GetWinningTicketsLastRound(200, user.token);
                prom2.then(
                    response => {
                        let winTickets = JSON.parse(response);
                        console.log(winTickets);
                    }
                )
                .catch(error => console.log(error));
            }
        ).catch(error => console.log(error));
    }

).catch(error => console.log(error));


// adminUser = 
// `
// {
//     "Username": "Admin",
//     "Password": "Password00"
// }
// `;


// prom = loginUser(adminUser, 200);
// prom.then(

//     response => {
//         let user = JSON.parse(response);
//         console.log(user);
        
//         let prom2 = GetWinningTicketsLastRound(200, user.token);
//         prom2.then(
//             response => {
//                 let winTickets = JSON.parse(response);
//                 console.log(winTickets);
//             }
//         )
//         .catch(error => console.log(error));
//     }
// ).catch(error => console.log(error));