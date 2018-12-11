let bookShelf =
[
    ["Kniga1", "Avtor1", true],
    ["Kniga2", "Avtor2", false],
    ["Kniga3", "Avtor3", true],
    ["Kniga4", "Avtor4", false],
    ["Kniga5", "Avtor5", true]
]


function Book(name, author, readingStatus)
{
    this.name = name;
    this.author = author;
    this.readingStatus = readingStatus;
    this.isRead = function()
    {
        if(this.readingStatus)
            return `Already read '${this.name}' by ${this.author}.`;
        else
            return `You still need to read '${this.name}' by ${this.author}.`;
    }
}

let books = [];

for (const book of bookShelf) {
    books.push( new Book(book[0], book[1], book[2] ) );
}

for (const book of books) {
    console.log(book.isRead());
}