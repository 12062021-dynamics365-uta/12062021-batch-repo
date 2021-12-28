//console.log('Hey, There, Tiger!');

// create the input element
let inputElem = document.createElement('input');
//add the element to the body
document.body.appendChild(inputElem);

// create the submit element
let submitTodo = document.createElement('button');
//add the element to the body
document.body.appendChild(submitTodo);
submitTodo.innerText = 'Submit A New Todo!';

// create the title element for the list
let title = document.createElement('h1');
//add the element to the body
document.body.appendChild(title);
//let markymark = 'markymark';
//title.innerText = `Your Todos! ${markymark}`;
title.innerText = `Your Todos!`;

let todoList = document.createElement('ul');
document.body.appendChild(todoList);// this is the same as .innerHTML.
let mar = "it's mark!"
todoList.innerHTML = `<li>This is the first ${mar} item</li>`;
todoList.innerHTML += `<li class="hoverDemo">This is the first second item</li>`;

// you can target the ordered list.
//let myUl = document.querySelector('ul');// this is getting another access to that <ul>.it is uneeded
todoList.classList.add('ulClass');

// create the eventlistener to do the things with the content of hte input box.
submitTodo.addEventListener('click', (e) => {
  let newTodo = inputElem.value;
  console.log(newTodo);
  let myLi = document.createElement('li');
  myLi.innerText = `${newTodo}`;
  todoList.appendChild(myLi);
  inputElem.value = '';
  inputElem.focus();

});

/**
 * still need to delete on click of hte todo item.
**/
document.body.addEventListener('click', (e) => {
  console.log("the body clicke event was triggered")
});

//put an event listener on the ul.
todoList.addEventListener('click', (event) => {
  //console.log(event.target);
  event.stopPropagation();// use this to stop the emission of the event up through the hierarchy
  event.target.parentNode.innerText = 'this is the parent of the element that the event happened on.'
});






