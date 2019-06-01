function initializeDataTable()
{
    let body = document.getElementsByTagName("body")[0];

    let table = document.createElement("table");
    table.setAttribute("id", "dataTable");
    table.setAttribute("border", "1px");
    table.setAttribute("cellpadding", "10px");
    table.setAttribute("style", "width:50%;");
    body.appendChild(table);
    let thead = document.createElement("thead");
    table.appendChild(thead);
    let headRow = document.createElement("tr");
    thead.appendChild(headRow);

    for (const header of tableDataColumns) {
        let rowHeader = document.createElement("th");
        rowHeader.textContent = header;
        thead.appendChild(rowHeader);
    }

    let tbody = document.createElement("tbody");
    table.appendChild(tbody);

    /* Set the table to global variable dataTable */
    dataTable = table;
}

function initializeInputFields()
{   
    let body = document.getElementsByTagName("body")[0];

    body.lastElementChild.after(document.createElement("br"));
    body.lastElementChild.after(document.createElement("br"));
    body.lastElementChild.after(document.createElement("br"));

    let fieldSet = document.createElement("fieldset");
    fieldSet.setAttribute("style", "font-size: 20px; font-weight: bold");
    body.lastElementChild.after(fieldSet);

    let legend = document.createElement("legend");
    legend.textContent = "Contact info";
    fieldSet.appendChild(legend);

    let table = document.createElement("table");
    // table.setAttribute("border", "1px");
    table.setAttribute("id", "inputTable");

    fieldSet.appendChild(table);

    let tbody = document.createElement("tbody");
    table.appendChild(tbody);

    for(let i = 1; i < tableDataColumns.length - 1; ++i)
    {
        // label
        let label = document.createElement("label");
        label.setAttribute("for", `${tableDataColumns[i]}`);
        label.textContent = `${tableDataColumns[i]}:`;
        // text field
        let textInput = document.createElement("input");
        textInput.setAttribute("type", "text");
        textInput.setAttribute("name", tableDataColumns[i]);
        textInput.setAttribute("id", `${tableDataColumns[i]}`);
        textInput.setAttribute("placeholder", tableDataColumns[i]);
        /* Add each input field to inputFields array */
        inputFields.push(textInput);

        let tableRow = document.createElement("tr");
        tableRow.setAttribute("style", "text-align: left;");
        tbody.appendChild(tableRow);

        let tableCell = document.createElement("td");
        tableCell.appendChild(label);
        tableRow.appendChild(tableCell);

        tableCell = document.createElement("td");
        tableCell.appendChild(textInput);
        tableRow.appendChild(tableCell);
    }

    let tableRow = document.createElement("tr");
    tableRow.setAttribute("style", "text-align: center;");
    tbody.appendChild(tableRow);

    let tableCell = document.createElement("td");
    tableCell.setAttribute("colspan", "2");
    tableRow.appendChild(tableCell);

    let discardButton = document.createElement("button");
    discardButton.setAttribute("type", "button");
    discardButton.textContent = "Discard";
    discardButton.addEventListener("click", function()
    {
        discard(inputFields);
    });

    let saveButton = document.createElement("button");
    saveButton.setAttribute("type", "button");
    saveButton.setAttribute("style", "background-color: blue");
    saveButton.textContent = "Save";
    saveButton.addEventListener("click", function()
    {   
        if(!inputValidation(inputFields))
            return;
        
        if(contactToEdit === null)
        {
            // If we want to save the contact
            contactID += 1;
            let contact = new Contact(contactID, inputFields);
            saveContact(dataTable, contact);
        }
        else
        {
            // If we want to edit the contact
            let newContact = new Contact(contactToEdit.contact.ID, inputFields);
            saveContact(dataTable, newContact, contactToEdit);
        }

        discard(inputFields);
    });

    tableCell.appendChild(discardButton);
    tableCell.appendChild(saveButton);
}


initializeDataTable();
initializeInputFields();