function inputValidation(inputFields, inputFieldsValidation)
{   
    let fieldset = $("fieldset");
    let errorValidation = $("fieldset + p");
    if(errorValidation !== null)
        errorValidation.remove();

    errorValidation = $("<p>");
    errorValidation.css("color", "red");

    for(let i = 0; i < inputFieldsValidation.length; ++i)
    {
        let regExp = inputFieldsValidation[i].regularExpression;
        if(regExp !== "")
        {
            let inputField = inputFields[i];
            let inputValue = inputField.value;

            if(inputValue !== "" && !inputValue.match(regExp))
            {
                errorValidation.text(inputFieldsValidation[i].nonEmptyValidationText);
                fieldset.after(errorValidation);
                return false;
            }
            else if(inputValue === "")
            {
                errorValidation.text(inputFieldsValidation[i].emtpyValidationText);
                fieldset.after(errorValidation);
                return false;
            }
        }
    }

    return true;
}