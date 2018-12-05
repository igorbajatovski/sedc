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
    let table = result.getElementsByTagName("table");
    if(table.length === 0)
    {
        table = document.createElement("table");
        table.setAttribute("border", "1px");
        table.setAttribute("cellpadding", "10px");
        result.appendChild(table);
        let thead = document.createElement("thead");
        table.appendChild(thead);
        let tbody = document.createElement("tbody")
        table.appendChild(tbody);
        for (const userDataField of userDataFields) 
        {
            let th = document.createElement("th");
            th.appendChild(document.createTextNode(userDataField));
            thead.appendChild(th);
        }
    }
}

initializeUserDataForm();
initializeUserDataTable()
//#####################################################################################################################
function checkMissingFields(userInfo)
{
    let missingFields = userInfo.map((e,i) => { if(e === "") return userDataFields[i]; else return ""})
    missingFields = missingFields.filter(e => e !== "");

    if(missingFields.length > 0)
        return missingFields;
    return missingFields;
}


function printUserInfo(userInfo)
{   
    let result = document.getElementById("result");
    let table = result.getElementsByTagName("table")[0];
    let tbody = table.getElementsByTagName("tbody")[0];
    let newRow = document.createElement("tr");
    for (const userData of userInfo) 
    {
        let cell = document.createElement("td");
        cell.textContent = userData;
        newRow.appendChild(cell);
    }
    tbody.appendChild(newRow);

    return [];
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

//#####################################################################################################################

function displayErrorMissingFields(missingFields)
{
    missingFields = missingFields.map( (e) => e += "-ID" );
    let userData = document.getElementById("UserData");
    let inputFields = userData.getElementsByTagName("input");
    for(let inputField of inputFields)
    {
        if(missingFields.includes(inputField.getAttribute("id")))
        {
            let error = document.createElement("span");
            error.setAttribute("style", "color: red;")
            error.appendChild(document.createTextNode("*"))
            inputField.after(error);
        }
    }
}

function clearErrorMissingFields()
{
    let userData = document.getElementById("UserData");
    let errors = userData.getElementsByTagName("span");
    
    if(errors.length > 0)
    {
        while(errors.length > 0)
            errors[0].remove();
    }
}

//#####################################################################################################################

let button = document.getElementById("Register");

button.addEventListener("click", function()
{
    clearErrorMissingFields();
    let userInfo = getUserInfo();
    let missingFields = checkMissingFields(userInfo);
    if(missingFields.length > 0)
        displayErrorMissingFields(missingFields);
    else
        printUserInfo(userInfo);
});
//#####################################################################################################################
