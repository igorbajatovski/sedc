let person = new Person("Igor", "Bajatovski", "27/12/1983", "Negotino");
console.log(person.details());
console.log(person.calculateAge());

let person1 = new Person("Igor", "Bajatovski", "/12/1983", "Negotino");
console.log(person1.details());
console.log(person1.calculateAge());



let  members = 
[
    new Person("Dejan", "Jovanov", "22/01/1989",  "Skopje"),
    new Person("Vwkoslav", "Stefanovski", "9/5/1976",  "Kavadarci"),
    new Person("Blagoj", "Ristovski", "12/10/1980",  "Pehcevo"),
    new Person("Nikola", "Davchev", "06/7/1978",  "Skopje")
]


for (const member of members) {
    console.log(member.calculateAge());
}

let family = new Family(members);
console.log(`Avarage year of familiy is ${family.avarageAge()}`);
console.log(`Total years of family is ${family.sumAge()}`);