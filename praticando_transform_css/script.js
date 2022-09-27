const box = document.getElementsByClassName('box')[0];
const interna = document.getElementById('interna');

function addClass(){
  box.classList.add('active');
  interna.classList.add('active');
}
function removeClass(){
  box.classList.remove('active');
  interna.classList.remove('active');
}