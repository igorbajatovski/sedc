function validateInputFields()
{
    let inputFields = $(`#shipInput input:visible`).not(`input[type="checkbox"]`);
    for (const inputField of inputFields) 
    {
        if(inputField.value === "")
            return false;
    }

    return true;
}

function clearInputFields(inputFields)
{
    for (const inputField of inputFields)
    {
        if(inputField.type !== "checkbox")
            inputField.value = "";
        else
            inputField.checked = false;
    }
}