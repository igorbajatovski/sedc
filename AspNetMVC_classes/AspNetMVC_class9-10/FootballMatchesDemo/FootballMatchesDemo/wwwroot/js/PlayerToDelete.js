document.onload = function() {

    let playerToDelete = $("PlayerActions").find("button").on("click", (event) => {
        event.preventDefault();
        let playerToDelete = $(this).append('<input type="hidden">');
        let value = $(this).parent().parent().find(":first").text();
        playerToDelete.attr("name", "playerToDeleteID");
        playerToDelete.attr("value", value);
        console.log(`value=${value}`);
        //$(this).trigger("submit");
    });
};