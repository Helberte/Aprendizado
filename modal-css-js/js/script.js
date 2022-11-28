const btOpenModal = document.querySelector('#open-modal');
const closeModalBottom = document.querySelector('#close-modal');
const modal = document.querySelector('#modal');
const fade = document.querySelector('#fade');


const toggleModal = () => {
  [modal, fade].forEach((el) => el.classList.toggle('hide'));  
};


[btOpenModal, closeModalBottom, fade].forEach((el) =>{
  el.addEventListener('click', () => toggleModal());
});