    $(

        () => {

            function printMe(me)
            {
                body = $("body");
                let ul = $("<ul>");
                
                for (const prop in me) {
                    let li = $("<li>");
                    li.text(me[prop]);
                    ul.append(li);
                }

                body.append(ul);
            }


            $.ajax(
                {
                    url: "https://cors.io/?https://github.com/igorbajatovski/sedc/tree/master/Homework_cas10/Homework2/me.json",
                    
                    // dataType: "json",

                    success: function(response)
                    {
                        let me = JSON.parse(response);
                        printMe(me);
                    },

                    error: function(response)
                    {
                        console.log(response);
                    }
                }
            )



        }

    )