let deleteBtns = $("table tr button");
if (deleteBtns.length > 0) {
    deleteBtns
        .on("click", function (event, data) {
            if (data === undefined) {
                event.preventDefault();
                //let table = $("table").after('<input type="hidden" />');
                $(this).after('<input type="hidden" />');
                //let playerToDelete = table.next();
                let playerToDelete = $(this).next();
                let value = $(this).parent().parent().find(":first").text().trim();
                playerToDelete.attr("name", "playerToDeleteID");
                playerToDelete.attr("value", value);
                $(this).trigger("click", {});
            }
        });
}