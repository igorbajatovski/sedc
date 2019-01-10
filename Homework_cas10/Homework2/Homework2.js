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
                    url: "https://igorbajatovski.github.io/sedc/Homework_cas10/Homework2/me.json",

                    success: function(response)
                    {
                        printMe(response);
                    },

                    error: function(response)
                    {
                        console.log(response);
                    }
                }
            )



        }

    )