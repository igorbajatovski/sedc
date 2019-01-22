function getAgeInYears(dateOfBirth)
{
    if(dateOfBirth === undefined || dateOfBirth === null || Number.isNaN(dateOfBirth) || 
       !isNaN(dateOfBirth) || dateOfBirth instanceof Array )
            return "Incorrect date format (expected format dd/mm/yyyy)";
    
    let dateComponents = dateOfBirth.split("/");
    if(dateComponents.length !== 3)
        return "Incorrect date format (expected format dd/mm/yyyy)";
    
    let day = dateComponents[0];
    let month = dateComponents[1];
    let year = dateComponents[2];

    if( day === "" || isNaN(day) || month === "" || isNaN(month) || year === "" || isNaN(year) )
        return "Incorrect date format (expected format dd/mm/yyyy)";
    
    let nDay = Number(day);
    let nMonth = Number(month) - 1;
    let nYear = Number(year) - 1900;

    if( nDay < 1 || nDay > 31 || nMonth < 0 || nMonth > 11 )
        return "Incorrect date format (day should be between 1 and 31, month between 1 and 12)";

    let dob = new Date(nYear, nMonth, nDay);
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
}

function getAgeInDays(dateOfBirth)
{
    if(dateOfBirth === undefined || dateOfBirth === null || Number.isNaN(dateOfBirth) || 
       !isNaN(dateOfBirth) || dateOfBirth instanceof Array )
            return "Incorrect date format (expected format dd/mm/yyyy)";
    
    let dateComponents = dateOfBirth.split("/");
    if(dateComponents.length !== 3)
        return "Incorrect date format (expected format dd/mm/yyyy)";
    
    let day = dateComponents[0];
    let month = dateComponents[1];
    let year = dateComponents[2];

    if( day === "" || isNaN(day) || month === "" || isNaN(month) || year === "" || isNaN(year) )
        return "Incorrect date format (expected format dd/mm/yyyy)";
    
    let nDay = Number(day);
    let nMonth = Number(month) - 1;
    let nYear = Number(year) - 1900;

    if( nDay < 1 || nDay > 31 || nMonth < 0 || nMonth > 11 )
        return "Incorrect date format (day should be between 1 and 31, month between 1 and 12)";

    let dob = new Date(nYear, nMonth, nDay);
    let ageInDays = ( ( Date.now() - dob.valueOf() ) / 1000 ) / (24*60*60);
    return Math.trunc(Math.round(ageInDays));
}



console.log(getAgeInYears(454));
console.log(getAgeInYears(null));
console.log(getAgeInYears(undefined));
console.log(getAgeInYears(""));
console.log(getAgeInYears(NaN));
console.log(getAgeInYears([32,23]));
console.log(getAgeInYears([]));
console.log(getAgeInYears(["dfd", "dss"]));
console.log(getAgeInYears("///"));
console.log(getAgeInYears("27/12/"));
console.log(getAgeInYears("/12/1983"));
console.log(getAgeInYears("sfdf/12/1983"));
console.log(getAgeInYears("27/sdd/1983"));
console.log(getAgeInYears("27/13/1983"));
console.log(getAgeInYears("32/12/1983"));
console.log(getAgeInYears("-27/12/1983"));
console.log(getAgeInYears("27/12/1983") + " years old");
console.log(getAgeInDays("27/12/1983")  + " days old");