function changeHeadersAndParagraphs()
{
    let headers = document.querySelectorAll("h1,h2,h3,h4,h5,h6");
    for(let header of headers)
    {
        header.setAttribute("style", "color: red");
        if(!header.innerHTML.includes("*This text has been modifed"))
            header.innerHTML += "<sup style='font-size: 12px;'>*This text has been modifed</sup>";
    }

    let paragraphs = document.querySelectorAll("p");
    for(let paragraph of paragraphs)
    {
        paragraph.setAttribute("style", "font-style: italic; font-weight: bold");
    }
}


function reset()
{
    document.location.reload(false);
}