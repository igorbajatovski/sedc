/***************************  GLOBAL VARIABLES  *******************************/
// To add more fields/columns to the input form and table just add another element before "Actions" element
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

/* These are DOM elements not jQuery elements */
let inputFields = null;  // array of DOM input fields

let dataTable = null;  // DOM table
/**********************************************/

let contacts = [];    // array of added contacts

let contactToEdit = null;   // these variable is set when we select to edit some contact

let contactID = 0;  // intial value of contact IDs
/******************************************************************************/