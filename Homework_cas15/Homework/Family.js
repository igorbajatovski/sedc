function Family(members)
{
    if( !(members instanceof Array) )
        throw new Error("Parameter members must be an Array of Persons");
    this.numberOfMembers = members.length;
    this.members = members;
}


Family.prototype.avarageAge = function()
{
    return this.sumAge()/this.members.length;
}

Family.prototype.sumAge = function()
{
    let sum = 0;
    for (const member of this.members)
        sum += member.calculateAge().ageYears;
    return sum;
}