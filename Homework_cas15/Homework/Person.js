function Person(firstName, lastName, dateOfBirth, placeOfBirth)
{
    // debugger;
    this._dateOfBirth = null;
    this.firstName = firstName;
    this.lastName = lastName;
    this.dateOfBirth = dateOfBirth;
    this.placeOfBirth = placeOfBirth;
}

Object.defineProperties(Person.prototype,
    {    
        dateOfBirth:
        {
                get: function() 
                {
                    // debugger;
                    return this._dateOfBirth;
                },

                set: function(dob)
                {
                    // debugger;
                    if(dob === undefined || dob === null || Number.isNaN(dob) || 
                    !isNaN(dob) || dob instanceof Array )
                    {
                        this._dateOfBirth = "Incorrect date format (expected format dd/mm/yyyy)";
                        return;
                    }
                    
                    let dateComponents = dob.split("/");
                    if(dateComponents.length !== 3)
                    {
                        this._dateOfBirth = "Incorrect date format (expected format dd/mm/yyyy)";
                        return;
                    }
                    
                    let day = dateComponents[0];
                    let month = dateComponents[1];
                    let year = dateComponents[2];

                    if( day === "" || isNaN(day) || month === "" || isNaN(month) || year === "" || isNaN(year) )
                    {
                        this._dateOfBirth = "Incorrect date format (expected format dd/mm/yyyy)";
                        return;
                    }
                    
                    let nDay = Number(day);
                    let nMonth = Number(month) - 1;
                    let nYear = Number(year) - 1900;

                    if( nDay < 1 || nDay > 31 || nMonth < 0 || nMonth > 11 )
                    {
                        this._dateOfBirth = "Incorrect date format (day should be between 1 and 31, month between 1 and 12)";
                        return;
                    }

                    this._dateOfBirth = new Date(nYear, nMonth, nDay);
                }
            }// end of dateOfBirth
    });

Person.prototype.details = function()
{
    return `${this.firstName}, ${this.lastName} is born at ${this.placeOfBirth}`;
},

Person.prototype.calculateAge = function()
{
    // debugger;
    return { ageDays: this._getAgeInDays(),
             ageMonths: this._getAgeInMonths(),
             ageYears: this._getAgeInYears()
            };
}

Person.prototype._getAgeInYears = function ()
{
    if( !(this.dateOfBirth instanceof Date) )
        return this.dateOfBirth;
    
    let dob = this.dateOfBirth;
    let currentDate = new Date();

    let ageInYears = 0;
    if(currentDate.getMonth() >= dob.getMonth())
    {
        if(currentDate.getDate() >= dob.getDate())
            ageInYears = currentDate.getFullYear() - dob.getFullYear();
        else
            ageInYears = currentDate.getFullYear() - dob.getFullYear() - 1;
    }
    else
    {
        ageInYears = currentDate.getFullYear() - dob.getFullYear() - 1;
    }

    return ageInYears;
},

Person.prototype._getAgeInMonths = function()
{
    if( !(this.dateOfBirth instanceof Date) )
        return this.dateOfBirth;

    let dob = this.dateOfBirth;
    let currentDate = new Date();

    let counter = new Date(dob);
    let month = counter.getMonth();
    let ageMonths = 0;
    // debugger;
    while( !( counter.getFullYear() === currentDate.getFullYear() &&
           counter.getMonth() === currentDate.getMonth() )  )
           {
                ageMonths += 1;
                counter.setMonth(counter.getMonth() + 1);
           }

    return ageMonths;
},

Person.prototype._getAgeInDays = function ()
{
    if( !(this.dateOfBirth instanceof Date) )
        return this.dateOfBirth;

    let dob = this.dateOfBirth;
    let ageInDays = ( ( Date.now() - dob.valueOf() ) / 1000 ) / (24*60*60);
    return Math.trunc(Math.round(ageInDays));
}