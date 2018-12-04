//#####################################################################################################################
let userDataFields = ["First name", "Last name", "Username", "Password", "Address", "Email", "Date of birth"]
function initializeUserDataForm()
{
    let userData = document.getElementById("UserData");
    for(userDataField of userDataFields)
    {
        let label = document.createElement("label");
        label.setAttribute("for", `${userDataField}-ID`);
        label.innerHTML = userDataField + "&nbsp;&nbsp;&nbsp;&nbsp;";
        
        let inputField = document.createElement("input");
        if(userDataField.includes("Password"))
        {
            inputField.setAttribute("type", "password");
            inputField.setAttribute("placeholder", "*************");
        }
        else if(userDataField.includes("Email"))
        {
            inputField.setAttribute("type", "email");
            inputField.setAttribute("placeholder", "username@email.com");
        }
        else if(userDataField.includes("Date of birth"))
        {
            inputField.setAttribute("type", "date");
        }
        else
        {
            inputField.setAttribute("type", "text");
            inputField.setAttribute("placeholder", userDataField);
        }
        inputField.setAttribute("id", `${userDataField}-ID`);
        inputField.setAttribute("name", userDataField);

        userData.appendChild(label);
        userData.appendChild(inputField);
        userData.appendChild(document.createElement("br"));
        userData.appendChild(document.createElement("br"));
    }
    let registerBUtton = document.createElement("button");
    registerBUtton.setAttribute("id", "Register");
    registerBUtton.setAttribute("type", "button");
    registerBUtton.textContent = "Register";
    userData.appendChild(registerBUtton);
}

function initializeUserDataTable()
{
    let result = document.getElementById("result");
    let table = result.getElementsByTagName("table")[0];
    if(table === undefined)
    {
        table = document.createElement("table");
        table.setAttribute("border", "1px");
        result.appendChild(table);
        let thead = document.createElement("thead");
        table.appendChild(thead);
        let tbody = document.createElement("tbody")
        table.appendChild(tbody);
        for (const userDataField of userDataFields) 
        {
            let th = document.createElement("th");
            th.appendChild(document.createTextNode(userDataField));
            thead.appendChild(th)
        }
    }
}

initializeUserDataForm();
initializeUserDataTable()
//#####################################################################################################################
function printUserInfo(userInfo)
{
    for (const userData of userInfo) 
    {

    }
}

function getUserInfo()
{
    let userInfo = [];
    for(let userDataField of userDataFields)
    {
        let userField = document.getElementById(`${userDataField}-ID`);
        userInfo.push(userField.value);
    }
    return userInfo;
}

let button = document.getElementById("Register");

button.addEventListener("click", function()
{
    let userInfo = getUserInfo();
    printUserInfo(userInfo);
});
//#####################################################################################################################
