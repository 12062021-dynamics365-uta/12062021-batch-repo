
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
// let myPara = document.createElement('p');

fiveJokeButton.onclick = () => {
  fetch(`https://api.icndb.com/jokes/random/5`)
    .then(response => {
      //chuck only sends OK as the response!
      // if(!response.ok){
      //   console.log(`There was an error in the request ${err}`)
      // }
      return response.json();//parse the response so you can access it in the next .then()
    })
  .then(response => {
    //code to render the joke only to the browser.
    document.body.appendChild(myDiv);
    myDiv.innerHTML = '';//delete whatever is int he <div> currently.
    //loop over the jokes to append each new <p> to the <div>
    for (let i = 0; i < response.value.length;i++){
      let myPara = document.createElement('p');
      myPara.innerText += response.value[i].joke;
      myDiv.appendChild(myPara);
    }
    })
    /**because icndb only sends OK as the value of response.ok, you have to keep your catch
    * here at the bottom to catch error caused by reading undefined values 
    * in the response object
    * I assume this is an inside joke...because Chuck Norris is NEVER !response.ok.
    */
    .catch(err => console.log(`THIS IS THE .CATCH()`));
}