function initializeDataTable(tableDataColumns)
{
    let body = $("body");

    let table = $("<table>");
    table.attr("id", "dataTable");
    table.attr("border", "1px");
    table.attr("cellpadding", "10px");
    table.attr("style", "width:50%;");

    body.append(table);

    let thead = $("<thead>");
    table.append(thead);
    let headRow = $("<tr>");
    thead.append(headRow);

    for (const header of tableDataColumns) {
        let colHeader = $("<th>");
        colHeader.text(header);
        headRow.append(colHeader);
    }

    let tbody = $("<tbody>");
    table.append(tbody);

    return table[0];
}

function initializeInputFields(tableDataColumns)
{   
    let body = $("body");

    $("<br>").appendTo(body);
    $("<br>").appendTo(body);
    $("<br>").appendTo(body);

    let fieldSet = $("<fieldset>");
    fieldSet.appendTo(body)

    let legend = $("<legend>");
    legend.text("Contact info");
    legend.css({"font-size": "20px", "font-weight": "bold"});
    fieldSet.append(legend);

    let table = $("<table>");
    table.attr("id", "inputTable");

    fieldSet.append(table);

    let tbody = $("<tbody>");
    table.append(tbody);

    let inputFields = [];
    for(let i = 1; i < tableDataColumns.length - 1; ++i)
    {
        // label
        let label = $("<label>");
        label.attr("for", `${tableDataColumns[i]}`);
        label.text(`${tableDataColumns[i]}:`);
        // text field
        let textInput = $("<input>");
        textInput.attr("type", "text");
        textInput.attr("name", tableDataColumns[i]);
        textInput.attr("id", `${tableDataColumns[i]}`);
        textInput.attr("placeholder", tableDataColumns[i]);
        /* Add each input field to inputFields array */
        inputFields.push(textInput[0]);

        // create table row and add it to the table
        let tableRow = $("<tr>");
        tableRow.css("text-align", "left");
        tbody.append(tableRow);

        // create the row cell with label and add it to the table row
        let tableCell = $("<td>");
        tableCell.append(label);
        tableRow.append(tableCell);

        // create the row cell with inout field and add it to the table row
        tableCell = $("<td>");
        tableCell.append(textInput);
        tableRow.append(tableCell);
    }

    // Add the last row taht spans two columns
    let tableRow = $("<tr>");
    tableRow.css("text-align", "center");
    tbody.append(tableRow);

    let tableCell = $("<td>");
    tableCell.attr("colspan", "2");
    tableRow.append(tableCell);

    // Create the Discard button with onclick event handler
    let discardButton = $("<button>");
    discardButton.attr("type", "button");
    discardButton.css("font-size", "14px");
    discardButton.text("Discard");
    discardButton.on("click", () =>
    {
        discard(inputFields);
    });

    // Create the Save button with onclick event handler
    let saveButton = $("<button>");
    saveButton.attr("type", "button");
    saveButton.css("background-color", "lightblue");
    saveButton.css("font-size", "14px");
    saveButton.text("Save");
    saveButton.on("click", () =>
    {   
        if(!inputValidation(inputFields, inputFieldsValidation))
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

    // Add the buttons to the last row
    tableCell.append(discardButton);
    tableCell.append("&nbsp;&nbsp;&nbsp;");
    tableCell.append(saveButton);

    // Return the input fields
    return inputFields;
}


dataTable = initializeDataTable(tableDataColumns);
inputFields = initializeInputFields(tableDataColumns);
displayEvenOddRowsInColor(dataTable, "rgb(0, 102, 204)", "darkgray", "lightgray");