let d6 = document.querySelector('.q6thdiv');
let d5 = document.querySelector('.q5thdiv');
let d4 = document.querySelector('.q4thdiv');
let d3 = document.querySelector('.q3rddiv');
let d2 = document.querySelector('.q2ndbody');

d6.addEventListener('click', (e) => {
  d6.firstChild.innerText = 'I was clicked';
  console.log('d6 was clicked');
});

d5.addEventListener('click', (e) => {
  d5.firstChild.textContent = 'I was clicked';
  console.log('d5 waws clicked');
});

d4.addEventListener('click', (e) => {
  d4.firstChild.textContent = 'I was clicked';
  console.log('d4 was clicked');
});

d3.addEventListener('click', (e) => {
  d3.firstChild.textContent = 'I was clicked';
  console.log('d3 was clicked');
});

d2.addEventListener('click', (e) => {
  d2.firstChild.textContent = 'I was clicked';
  console.log(e.target);
  console.log('d2 was clicked');
  console.log(d6);
});

// console.log(document.body.innerHTML);