function addContact(dataTable, contact)
{   
    let newRow = document.createElement("tr");
    
    let contactRow = "";
    for (const nameProp in contact) {
        contactRow += `<td>${contact[nameProp]}</td>`;
    }

    newRow.innerHTML = contactRow;
    let tbody = dataTable.getElementsByTagName("tbody")[0];
    tbody.appendChild(newRow);

    let editButton = document.createElement("button");
    editButton.setAttribute("type", "button");
    editButton.textContent = "Edit";
    editButton.addEventListener("click", function(event)
    {   
        //  Set contact to edit
        setContactToEdit(event.target.parentElement.parentElement);
    });

    let deleteButton = document.createElement("button");
    deleteButton.setAttribute("type", "button");
    deleteButton.textContent = "Delete";
    deleteButton.addEventListener("click", function(event)
    {
        // Delete contact from table and contacts array
        deleteContact(event.target.parentElement.parentElement);
    });

    let newCell = document.createElement("td");
    newCell.setAttribute("style", "text-align: center;");
    newCell.appendChild(editButton);
    newCell.appendChild(deleteButton);
    newRow.appendChild(newCell);

    contacts.push(contact);

    displayEvenOddRowsInColor("darkgray", "lightgray");
}

function displayEvenOddRowsInColor(evenColor, oddColor)
{
    let rows = dataTable.querySelectorAll("tr");
    for (const row of rows) {
        if(row.rowIndex % 2 === 0)
            row.setAttribute("style", `background-color: ${evenColor}`);
        else
        row.setAttribute("style", `background-color: ${oddColor}`);
    }
}

function setContactToEdit(row)
{
    let rowIndex = row.rowIndex;
    contactToEdit = {contact: contacts[rowIndex - 1], index: rowIndex - 1};
    for (const inputField of inputFields) {
        inputField.value = contacts[rowIndex - 1][inputField.id];
    }
}

function deleteContact(row)
{
    contactToEdit = null;
    let contactID = parseInt(row.firstChild.textContent);
    row.remove();
    displayEvenOddRowsInColor("darkgray", "lightgray");
    contacts = contacts.filter( e => e.ID !== contactID );
}

function editContact(dataTable, newContact, toEditContact)
{   
    let editRow = dataTable.children[1].children[toEditContact.index];

    let i = 0;
    for (const propName in newContact) {
        editRow.children[i].textContent = newContact[propName];
        toEditContact.contact[propName] = newContact[propName];
        i += 1;
    }
    contactToEdit = null;
}

/* Eventhandling on save click */
function saveContact(dataTable, newContact, toEditContact = null)
{
    if(toEditContact === null)
        addContact(dataTable, newContact);
    else
        editContact(dataTable, newContact, toEditContact);
}

/* Eventhandling on discard click */
function discard(inputFields)
{
    let body = document.getElementsByTagName("body")[0];
    if(body.lastElementChild.tagName === "P")
        body.lastElementChild.remove();

    for (const inputField of inputFields) {
        inputField.value = "";
    }
    contactToEdit = null;
}