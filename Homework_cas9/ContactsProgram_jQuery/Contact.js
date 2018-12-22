
// contact constructor
function Contact(ID, inputFields)
{
    this.ID = ID;
    for (const inputField of inputFields) {
        this[inputField.id] = inputField.value;
    }
}