
let oneJokeButton = document.createElement('button');
document.body.appendChild(oneJokeButton);
oneJokeButton.innerText = `Click to get 1 Chuck Norris joke`;

let xhr = new XMLHttpRequest();

// oneJokeButton.addEventListener('click', () => {

// });

//if the arrow function body has more than 1 line, use {} to bound the body
oneJokeButton.onclick = () => {
  console.log(`This is .onclick() and the value is ${oneJokeButton.innerText}`);
  
  xhr.onreadystatechange = () => {
    console.log(`The readystate is ${xhr.readyState} and the status is ${xhr.status}.`);

    if (xhr.readyState == 4) {
      console.log(`the respons is ${xhr.responseText}`);
      //code to render the joke only to the browser.
      let myDiv = document.createElement('div');
      document.body.appendChild(myDiv);
      let myPara = document.createElement('p');
      myDiv.appendChild(myPara);
      let response =  JSON.parse(xhr.responseText)
      myPara.innerText = response.value.joke;
      // console.log(JSON.parse(xhr.responseText));
    }
  }
  xhr.open('get',`http://api.icndb.com/jokes/random`);
  xhr.send();
}


let fiveJokeButton = document.createElement('button');
document.body.appendChild(fiveJokeButton);
fiveJokeButton.innerText = `Click to get 5 Chuck Norris jokes`;
let myDiv = document.createElement('div');
let myPara = document.createElement('p');

fiveJokeButton.onclick = () => {
  fetch(`http://api.icndb.com/joke/5`)
    .then((res, err) => {
      // if(err){
      //   console.log(`There was an error in the request ${err}`)
      // }
      // else {
      console.log(`the response is ${res.responseText}`);
      //code to render the joke only to the browser.
      document.body.appendChild(myDiv);
      myDiv.innerHTML = '';
      myDiv.appendChild(myPara);
      return res.json();
      //}
    })
    .then(res => myPara.innerText = res.value.joke)
    .catch(err => console.log(`THIS IS THE .CATCH()`));
}