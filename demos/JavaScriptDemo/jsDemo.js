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


