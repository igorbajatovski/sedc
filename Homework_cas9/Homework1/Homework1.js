$(
    () => {

        $("body").append(`<p id="mouseX"></p>`);
        $("#mouseX").text("X = Unknown position");
        $("body").append(`<p id="mouseY"></p>`);
        $("#mouseY").text("Y = Unknown position");

        $(document).mousemove( (event) => {

            $("#mouseX").text(`X = ${event.pageX}`);
            $("#mouseY").text(`Y = ${event.pageY}`);

        });

    }
)