function generateTable(rows, columns)
{
    let divTable = document.getElementById("table");

    let table = divTable.getElementsByTagName("table");

    if(table.length > 0)
        table[0].remove();

    table = document.createElement("table");
    table.setAttribute("style", "border: solid 1px black; border-spacing: 5px;");
    divTable.appendChild(table);

    let tbody = document.createElement("tbody");
    table.appendChild(tbody);

    for(let i = 0; i < rows; ++i)
    {
        let row = document.createElement("tr");
        for(let j = 0; j < columns; ++j)
        {
            let cell = document.createElement("td");
            cell.innerHTML = `<b>Row-${i+1}, Column-${j+1}</b>`;
            if(j % 2 === 0)
                cell.setAttribute("style", "border: solid 1px black; padding: 10px; background-color: red;")
            else
                cell.setAttribute("style", "border: solid 1px black; padding: 10px; background-color: green;")
            row.appendChild(cell);
        }
        tbody.appendChild(row);
    }
}

function readColsRows()
{
    let rows = parseInt(document.getElementsByName("rowsNum")[0].value);
    let cols = parseInt(document.getElementsByName("colsNum")[0].value);
    return [rows, cols];
}

let generateTableButton = document.getElementById("generate");

generateTableButton.addEventListener("click", function()
{
    let tableSize = readColsRows();
    generateTable(...tableSize);
});