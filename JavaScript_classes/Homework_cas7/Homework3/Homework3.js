let animal = 
{
    name: "Charlie",
    kind: "Pitbull",
    speak(line)
    {
        if(line !== undefined && line !== null && line !== "")
            console.log(`${this.kind} ${this.name} says: ${line}`);
        else
            console.log(`${this.kind} ${this.name} does not want to speak`);
    }
}


animal.speak("Hey bro!!!");
animal.speak();
animal.speak("Aff Aff Aff");

let text = prompt("Enter some text");
animal.speak(text);