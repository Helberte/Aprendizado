const imgs = document.getElementById('img');
const img = document.querySelectorAll('#img img');
const seta = document.querySelectorAll('.seta .icon')[0];

let idx = 0;

function carrossel(){

  idx++;

  if(idx > img.length - 1){
    idx = 0;
  }

  imgs.style.transform = `translateX(${-idx * 500}px)`;
}

seta.addEventListener('click', carrossel);