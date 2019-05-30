$(
    () => {

        let body = $("body");
        
        let inputField = $("<input>");
        inputField.attr("id", "firstField")
        inputField.attr("type", "text");

        inputField.on("focus",  (event) => {
            $(event.target).after(`<span id="text1">Typing text ...</span>`);
        });

        inputField.on("blur",  () => {
            if($("#text1") !== null)
                $("#text1").remove();
        });

        body.append("<span>First Field&nbsp;&nbsp;&nbsp;&nbsp;</span>");
        body.append(inputField);

        body.append("<br>");
        body.append("<br>");

        inputField = $("<input>");
        inputField.attr("id", "secondField");
        inputField.attr("type", "text");

        inputField.on("focus",  (event) => {
            $(event.target).after(`<span id="text2">Typing text ...</span>`);
        });

        inputField.on("blur",  () => {
            if($("#text2") !== null)
                $("#text2").remove();
        });

        body.append("<span>Second Field&nbsp;&nbsp;&nbsp;&nbsp;</span>");
        body.append(inputField);


    }
)