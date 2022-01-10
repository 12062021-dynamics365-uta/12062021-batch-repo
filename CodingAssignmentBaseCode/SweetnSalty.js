var console = {};
console.log = function () { };
window.console = console;

// let GameProgression  = document.createElement('h1');
// document.body.appendChild(GameProgression);
// GameProgression.innerText = 'GAME PROGRESSION';

// let outputElement = document.createElement("input");
// document.body.appendChild(outputElement);



// let btn = document.createElement("button");
// document.body.appendChild(btn);
// btn.innerHTML = "CLICK ME";
// outputElement.type="submit";
// outputElement.name="PRESS ENTER";


var thirArr = new Array(1000);
var myVar = document.createElement('i');
document.body.appendChild(myVar);

var s = '';
var sweet = 'sweet';


var count = 0;
for (var i = 0; i <= thirArr.length; i++) {


  myVar.innerHTML += i + " ";


  if (i % 3 == 0) {
    myVar.innerHTML += 'salty';

  }
  if (i % 5 == 0) {

    myVar.innerHTML += sweet;


  }
  if (i % 3 == 0 && i % 3 == 0) {
    //myVar.style.color += 'red';
    myVar.innerHTML += 'sweetnSalty';

  }
  if (i % 40 == 0) {
    myVar.innerHTML += "<br>";
  }

}