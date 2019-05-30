$("#ships").on("click", function(event)
{
    let selected = $(this).val();

    if(selected === "fighterShip")
    {
        $(".displayCargoFields").hide();
        $(".displayMiningFields").hide();

        $(".displayShipFields").show();
        $(".displayFighterFields").show();
    }
    else if(selected === "cargoShip")
    {
        $(".displayFighterFields").hide();
        $(".displayMiningFields").hide();

        $(".displayShipFields").show();
        $(".displayCargoFields").show();
    }
    else if(selected === "miningShip")
    {
        $(".displayFighterFields").hide();
        $(".displayCargoFields").hide();
        
        $(".displayShipFields").show();
        $(".displayMiningFields").show();
    }

    if(selected !== null)
        $("#createShipBtn").removeAttr("disabled");

});

$("#createShipBtn").attr("disabled", "disabled");

$("#createShipBtn").on("click", function(event)
{
    if(validateInputFields())
    {
        let type = $("#ships").val();
        let inputFields = $("#shipInput input:visible");
        let ship = null;

        if(type === "fighterShip")
        {
            let wepons = [];
            let checkboxes = $(`#shipInput input[type="checkbox"]:visible`)
            for (const checkboxe of checkboxes)
            {
                if(checkboxe.checked)
                    wepons.push(checkboxe.value);
            }
            
            ship = new Fighter(inputFields[0].value, inputFields[1].value, inputFields[2].value, inputFields[3].value,
                                        inputFields[4].value, wepons, inputFields[8].value, inputFields[9].value);
        }
        else if(type === "cargoShip")
        {
            ship = new Cargoship(inputFields[0].value, inputFields[1].value, inputFields[2].value, inputFields[3].value,
                                        inputFields[4].value, inputFields[5].value, inputFields[6].value, inputFields[7].value);
        }
        else if(type === "miningShip")
        {
            let miningTools = [];
            let miningTypes = [];
            let checkboxes = $(`#shipInput input[type="checkbox"][name^="miningTool"]:visible`)
            for (const checkboxe of checkboxes)
            {
                if(checkboxe.checked)
                    miningTools.push(checkboxe.value);
            }

            checkboxes = $(`#shipInput input[type="checkbox"][name^="miningType"]:visible`);
            for (const checkboxe of checkboxes)
            {
                if(checkboxe.checked)
                    miningTypes.push(checkboxe.value);
            }
            
            ship = new Miningship(inputFields[0].value, inputFields[1].value, inputFields[2].value, inputFields[3].value,
                                        inputFields[4].value, miningTools, miningTypes, inputFields[11].value);
        }

        ships.push(ship);
        createShip(type, ships.length - 1);
        showShip(ship, type, ships.length - 1);
        clearInputFields(inputFields);
    }
});