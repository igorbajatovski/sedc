/***************************  GLOBAL VARIABLES  *******************************/
// To add more fields/columns to the input form and table just add another element 
const tableDataColumns = ["ID", "First name", "Last name", "Email", "Telephone", "Actions"];

// If you add another field/column you need to add its validation
const inputFieldsValidation = [
    {
        // Validation for First name 
        emtpyValidationText: "* First name is mandatory",
        nonEmptyValidationText: "* First name must begin with upercase letter and must not contain numbers",
        regularExpression: "^[A-Z]\\w+$"
    },
    {
        // Validation for Last name 
        emtpyValidationText: "* Last name is mandatory",
        nonEmptyValidationText: "* Last name must begin with upercase letter and must not contain numbers",
        regularExpression: "^[A-Z]\\w+$"
    },
    {
        // Validation for email 
        emtpyValidationText: "* Email is mandatory",
        nonEmptyValidationText: "* Not a valid email address",
        regularExpression: "^[\\w.]+@[\\w.]+$"
    },
    {
        // Validation for telephone
        emtpyValidationText: "* Telephone number is mandatory",
        nonEmptyValidationText: "* Not a valid phone number (Format: NN[N]/NNN[N]-NNN)",
        regularExpression: "^\\d{2,3}\\/\\d{3,4}-\\d{3}$"
    }
];

const inputFields = [];

let dataTable = null;

let contacts = [];

let contactToEdit = null;

let contactID = 0;
/******************************************************************************/