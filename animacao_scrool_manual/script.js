const target = document.querySelectorAll('[data-anime]');
const animation_class = "animate";



function animeScrool(){
  const windowTop = window.pageYOffset;
  target.forEach(function(element){
    if(windowTop > element.offsetTop){
      element.classList.add(animation_class);
    }
  })
}


window.addEventListener('scroll', function(){
  animeScrool();
});