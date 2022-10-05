

function addClass(v, popap){ 
  v.classList.add('active');
  let teste = document.getElementsByClassName(popap)[0];
  teste.classList.add('active');  
  
}

function removeClass(v, popap){
  v.classList.remove('active');
  let outro = document.getElementsByClassName(popap)[0];
  outro.classList.remove('active');
}