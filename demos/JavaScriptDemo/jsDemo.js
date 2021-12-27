"use strict"

console.log('Hello, world.. Nice to meet you.');
let five = 5;
console.log(five);

console.log(five);

var six = 6;
console.log(six);
var six = "six";
console.log(six);

//var is function (globally) scoped.....
// let is block scoped.
let num = 11;
function incrementing() {
  if (num%2 == 0) {
    var inc1 = ++num;
  }
  else {
    let inc2 = ++num;
    console.log(`The value of inc is ${inc2}`);// accessing inc2 is only allowed inside the block scope of the else{}
  }
  console.log(`The value of inc is ${inc1}`);
}

incrementing();
console.log(num);

// const doesn't allow reassignment.
const inc3 = 3;
//inc3 = 4;
// inc3 += 4;
let inc5 = inc3
console.log(`The value of inc5 is ${inc5}`);
console.log("The value of inc5 is " + inc5);
inc5 = 7;
console.log(`The value of inc5 is ${inc5}`);

// variable naming convention is...
// don't start a variable with a number.
// CONST variables are UPPERCASE
// all other variables are camelCase
//functions are camelCase but I like to do them in PascalCase

// don't use keywords.
let number1 = 5;
console.log(number1);

console.log(5 == 6);
console.log(true);
let undeclared;
console.log(undeclared);
let undeclared2 = null;
console.log(undeclared2);

let mark = { MyName:"Mark", age:42, street:"111 Main" };
console.log(mark.MyName);
console.log(mark);

console.log(typeof number1);

// an operand is the thing the operator acts on.
let operand1 = 5;
let operand2 = 6;
console.log(operand1 + operand2);

//10/(3+2)*4+5**2+6-9 = 
console.log(10 / (3 + 2) * 4 + 5 ** 2 + 6 - 9);

console.log(4 ** 3);

let inc7 = 7;
inc7 += 3;
console.log(inc7);

let inc8 = 7;
inc8 *= 3;
console.log(inc8);

let inc9 = 7;
inc9 **= 3;
// is equivalieant to
inc9 = inc9 ** 3;
console.log(Math.round(inc9));

// =(assignment) 
let inc10 = 10;
//== (coersed equality), 
console.log(inc10 == "10");
//=== (strict equality)
console.log(inc10 === "10");

//Truthy and Falsy
if (true) {
  console.log('This is true')
}

if (false == false) {
  console.log('This is false')
}

if (0 === 0) {
  console.log('This is true')
}

if ('' === '') {
  console.log('This is true')
}

let inc11; // inc11 is undefined to start with
console.log(String(inc11));// undefined?
console.log(Number(inc11));// NaN?
console.log(Boolean(inc11));// false?

let inc12 = "12";
console.log(Number(inc12));// 

let inc13 = 13;

console.log((Math.round(Math.random()*100)));

console.log(JSON.stringify(mark));
let stringyMark = JSON.stringify(mark);

console.log(stringyMark);
console.log(stringyMark.toUpperCase());

console.log(JSON.parse(stringyMark));


// Day 2 functions, classes, AJAX (XMLHttpRequest and Fetch())

// functions have a signature
// this is a funciton declaration
// no return type no type for on parameters.
function doubles() {
  return 5;
}

let result = doubles();
console.log(`The result of doubles is => ${result}`);


function doubles1(param1 = 10, ...arr) {
  return arr[2];
}

result = doubles1(11, 12, 13, 14);
console.log(`The result of doubles1 is => ${result}`);

//function expression
let doubles3 = function (param1) {
  return param1;
}

console.log(doubles3('Mark'));

//first-class function example
let doubles3Copy = doubles3;
console.log(doubles3Copy('Arely'));
console.log(doubles3('Maya'));

//callback function
let doubles4 = function (n, myFunc, param3, param4) {
  for (let m = 0; m <= n;m++){
    myFunc(param3, param4);
 } 
}
//console.log(doubles4);

//this will be sent to doubles4
function doubles5() {
  console.log("This is doubles 5");
}

// this is doubles 5 as an 'arrow function'
let doubles6 = () => console.log("This is doubles 6");
let doubles7 = (param1) => console.log(`This is doubles 7 and the args was ${arg1}`);
let doubles8 = (param1, param2) => console.log(`This is doubles 8 and the args were ${param1}, ${param2}`);

// this is a 'callback function'
doubles4(5, doubles8, "timey-wimey", 100);

//Immediately Invoked Funciton expressions!!!!!
// this iife returns a function after writing to the console.
let iifeFunc = (function(){
  console.log(`This is an IIFE`)
  return function (param1) {
    return param1 * param1;
  }
})();

//then we can envoke the returned function.,
console.log(iifeFunc(5));

// closure and scope
function doubles9() {
  let mySentence = '';
  return function (param1) {
    mySentence+= ' ' + param1
    return mySentence;
  }
}

let doubles10 = doubles9();
console.log(doubles10);
console.log(doubles10('This'));
console.log(doubles10('is'));
console.log(doubles10('an'));
console.log(doubles10('example'));
console.log(doubles10('of'));
console.log(doubles10('closure.'));

try {
  // throw new Error("This is an example of a try catch");
  throw new UserException('InvalidMonthNo');
}
catch (e){
  console.error(`This is the catch block ${e.message}`)
}

// function UserException(message) {
//   this.message = message;
//   this.name = 'UserException';
// }
// function getMonthName(mo) {
//   mo = mo - 1; // Adjust month number for array index (1 = Jan, 12 = Dec)
//   var months = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul',
//     'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];
//   if (months[mo] !== undefined) {
//     return months[mo];
//   } else {
//     throw new UserException('InvalidMonthNo');
//   }
// }

// try {
//   // statements to try
//   var myMonth = 15; // 15 is out of bound to raise the exception
//   var monthName = getMonthName(myMonth);
// } catch (e) {
//   monthName = 'unknown';
//   console.error(e.message, e.name); // pass exception object to err handler
// }
// finally {
//   console.log("this is the finally block")
// }


console.log("Still running....")
let userName = 'Mark';
localStorage.setItem("username", userName);
let retreivedUsername = localStorage.getItem('username');
console.log(`This is the username ${retreivedUsername}`)

let userName1 = 'moore';
sessionStorage.setItem("username", userName1);
let retreivedUsername1 = sessionStorage.getItem('username');
console.log(`This is the username ${retreivedUsername1}`)

let markGuy = {name:'Mark', lname:'Moore', age: 42}
sessionStorage.setItem('loggedInUser', JSON.stringify(markGuy));// you must json.stringify when storing an object
let retrievedUser = sessionStorage.getItem('loggedInUser');
console.log(JSON.parse(retrievedUser).age);// you must json.parse an object to me able to access it through dot notation.


//OBJECTS!!!!!!

let markGuy1 = { name: 'Mark', age: 42 }// object literal
console.log(markGuy1.age);

//use a function to return an object
function markGuyFunc(fname, age) {
  return {
    fname:fname,
    age:age
  }
}
//create multiples of the object as needed
let markGuy2 = markGuyFunc('Ethan', 16);
console.log(markGuy2);

markGuy1.lname = 'Moore';
console.log(markGuy1.lname);

// markGuy1.marksFuncy = () => "THis is the new function for markguy1"
markGuy1.marksFuncy = function(){
  return "This is the new function for markguy1"
} 
console.log(markGuy1.marksFuncy());

console.log('fullname' in markGuy1);// you can query to see if a property exists on an object

//CLASSES!!!!!
class childlessCouple{
  // you don't create properties in the class....
  // you do that in the constructor.
  constructor(dad, mom) {
    // you have to use the 'this' keyword to specify that you
    // are creating these props on THIS class.
    this.dad = dad;
    this.mom = mom;
  }

  sayItLoud() {
    return `${cc.mom} loves ${cc.dad}`
  }

  //getter and setter
  // use the 'get' keyword. this LOOKS like a function (and it is), 
  // but you access the contents like a property
  get listOfFamily() {
    return `the parents are ${this.dad} and ${this.mom}`;
  }

  set familyMotto(value) {
    this.motto = value;
  }
}

let cc = new childlessCouple('chachi', 'jonie');
console.log(`${cc.mom} loves ${cc.dad}`);
console.log(cc.sayItLoud())
console.log(cc.listOfFamily);// access the getter prop.
cc.familyMotto ='We are ffaaamily';
console.log(cc.motto);

class family extends childlessCouple{
  constructor(dad, mom, ...children) {
    super(dad, mom);// call the parent constructor
    this.children = children// store the children into the class array
  }

  get listOfChildren() {
    let listOfChildrenString = '';
    this.children.forEach((value, index) => listOfChildrenString += (`Child ${index+1} is ${value}.\n`));
    return listOfChildrenString
  }
}
let fam = new family('Robert','Darlene','Matthew','Libby','Mike','Mark','Bethany');

console.log(fam.listOfChildren);




