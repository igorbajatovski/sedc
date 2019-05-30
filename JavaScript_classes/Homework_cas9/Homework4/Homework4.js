$(
    () => {

        let hidden = false;

        $("#HideShow").text("Hide divs");
        $("#HideShow").on("click", (event) => {
           
            if(!hidden)
            {
                event.target.disabled = "disabled";
                $("#div1").animate({opacity:0}, 500);
                $("#div2").animate({opacity:0}, 300);
                $("#div3").animate({opacity:0}, {duration: 800, complete: () => {
                    event.target.textContent = "Show divs";
                    hidden = !hidden;
                    event.target.disabled = "";
                }}); 
            }
            else if(hidden)
            {
                event.target.disabled = "disabled";
                $("#div1").animate({opacity:1}, 500);
                $("#div2").animate({opacity:1}, 300);
                $("#div3").animate({opacity:1}, {duration: 800, complete: () => {
                    event.target.textContent = "Hide divs";
                    hidden = !hidden;
                    event.target.disabled = "";
                }});
            }



        });



    }
)