function inputValidation(inputFields)
{
    let body = document.getElementsByTagName("body")[0];
    if(body.lastElementChild.tagName === "P")
        body.lastElementChild.remove();

    
    let errorValidation = document.createElement("p");
    errorValidation.setAttribute("style", "color: red");

    for(let i = 0; i < inputFieldsValidation.length; ++i)
    {
        let regExp = inputFieldsValidation[i].regularExpression;
        if(regExp !== "")
        {
            let inputField = inputFields[i];
            let inputValue = inputField.value;

            if(inputValue !== "" && !inputValue.match(regExp))
            {
                errorValidation.textContent = inputFieldsValidation[i].nonEmptyValidationText;
                body.lastElementChild.after(errorValidation);
                return false;
            }
            else if(inputValue === "")
            {
                errorValidation.textContent = inputFieldsValidation[i].emtpyValidationText;
                body.lastElementChild.after(errorValidation);
                return false;
            }
        }
    }

    return true;
}