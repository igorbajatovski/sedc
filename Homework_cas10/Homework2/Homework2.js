    $(

        () => {

            ['Arguments', 'Function', 'String', 'Number', 'Date', 'RegExp', 'Array', 'Object'].forEach( 
                function(name) { 
                    window['is' + name] = function(obj) {
                        return Object.prototype.toString.call(obj) == '[object ' + name + ']';
                }; 
            });
            
            let s = "";
            console.log(s instanceof String ? "E String" : "Ne e String");
            console.log(s instanceof Object ? "E Object" : "Ne e Object");
            console.log(typeof s);
            console.log(Object.prototype.toString.call(s));
            s = [];
            console.log(s instanceof Array ? "E Array" : "Ne e Array");
            s = 5;
            console.log(typeof s);
            s = Number(5);
            console.log(Object.prototype.toString.call(s));
            console.log(typeof s);
            s = [];
            console.log(typeof s);
            console.log(typeof printMe);
            console.log(Object.prototype.toString.call(s));

            function printMe(me)
            {
                body = $("body");
                let ul = $("<ul>");
                
                for (const prop in me) {
                    let li = $("<li>");
                    ul.append(li);

                    if( !isObject(me[prop]) )
                        li.text(me[prop]);
                    else{
                        sObject = ``;
                        for (const key in me[prop]) {
                            if (me[prop].hasOwnProperty(key)) {
                                const element = me[prop][key];
                                sObject += `${element}, `
                            }
                        }
                        sObject = sObject.substring(0, sObject.length - 2);
                        li.text(sObject);
                    }

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