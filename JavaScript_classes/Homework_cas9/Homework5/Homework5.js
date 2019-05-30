$(
    () => {

        $("#circle").on("mouseenter", (event) => {
           
            $("#circle").css("top", "20px");
            $("#circle").css("left", "20px");

        });

        $("#circle").on("mouseleave", (event) => {
           
            $("#circle").css("top", "0px");
            $("#circle").css("left", "0px");

        });

    }
)