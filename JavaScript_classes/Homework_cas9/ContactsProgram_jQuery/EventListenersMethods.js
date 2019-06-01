function addContact(dataTable, contact)
{   
    let tbody = $(`#${dataTable.id} tbody`);
    let newRow = $("<tr>");
    
    let contactRow = "";
    for (const nameProp in contact) {
        contactRow += `<td>${contact[nameProp]}</td>`;
    }

    newRow.append(contactRow);
    tbody.append(newRow);

    let editButton = $("<button>");
    editButton.attr("type", "button");
    editButton.text("Edit");
    editButton.on("click", (event) =>
    {   
        //  Set contact to edit
        setContactToEdit(event.target.parentElement.parentElement);
    });

    let deleteButton = $("<button>");
    deleteButton.attr("type", "button");
    deleteButton.text("Delete");
    deleteButton.on("click", (event) =>
    {
        // Delete contact from table and contacts array
        discard(inputFields)
        deleteContact(event.target.parentElement.parentElement);
        displayEvenOddRowsInColor(dataTable, "rgb(0, 102, 204)", "darkgray", "lightgray");
    });

    let newCell = $("<td>");
    newCell.css("text-align", "center");
    newCell.append(editButton);
    newCell.append("&nbsp;&nbsp;&nbsp;");
    newCell.append(deleteButton);
    newRow.append(newCell);

    contacts.push(contact);
}

function displayEvenOddRowsInColor(dataTable, headerColor, evenColor, oddColor)
{
    $(`#${dataTable.id} tr:even`).css("background-color", evenColor);
    $(`#${dataTable.id} tr:odd`).css("background-color", oddColor);
    $(`#${dataTable.id} tr:first`).css("background-color", headerColor);
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
    {
        addContact(dataTable, newContact);
        displayEvenOddRowsInColor(dataTable, "rgb(0, 102, 204)", "darkgray", "lightgray");
    }
    else
        editContact(dataTable, newContact, toEditContact);
}

/* Eventhandling on discard click */
function discard(inputFields)
{
    let errorValidation = $("fieldset + p");
    if(errorValidation !== null)
        errorValidation.remove();

    for (const inputField of inputFields) {
        inputField.value = "";
    }
    contactToEdit = null;
}