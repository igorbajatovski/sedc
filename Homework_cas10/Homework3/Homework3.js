$(


    /**
     * {"location":"MK0047A",
     * "parameter":"pm10",
     * "date":{"utc":"2018-12-20T22:00:00.000Z","local":"2018-12-20T23:00:00+01:00"},
     * "value":179.626,
     * "unit":"µg/m³",
     * "coordinates":{"latitude":41.991999999466,"longitude":21.423},
     * "country":"MK",
     * "city":"Centar Municipality"}
     */

    () => {

        function averagePolution(results)
        {
            let sum = 0;
            for (const elem of results) {
                sum += elem.value;
            }
            let average = sum/results.length;
            return average;
        }
        
        function showAveragePolution(results)
        {
            body = $("body");
            let h1 = $("<h1>");
            h1.text(averagePolution(results) + " µg/m³");
            body.append(h1);
        }

        $("#showAveragePolution").on("click", function()
        {
            $.ajax(
                {
                    url: "https://api.openaq.org/v1/measurements?country=MK&city=Centar+Municipality&parameter=pm10&date_from=2018-12-20&date_to=2018-12-21",

                    success: function(response)
                    {
                        showAveragePolution(response.results);
                    },

                    error: function(response)
                    {
                        console.log(response);
                    }
                }
            )
        })

    }

)