const allSideMenu = document.querySelectorAll('#sidebar .side-menu.top li a');

allSideMenu.forEach(item=> {
	const li = item.parentElement;

	item.addEventListener('click', function () {
		allSideMenu.forEach(i=> {
			i.parentElement.classList.remove('active');
		})
		li.classList.add('active');
	})
});



function ChangeContent(pageId) {
  
  const mainContentDivs = document.querySelectorAll('.main-content > div');
  mainContentDivs.forEach(div => {
    div.style.display = 'none';
  });


  const selectedPage = document.getElementById(pageId);
  if (selectedPage) {
    selectedPage.style.display = 'block';
  }
}

window.onload = function() {
  ChangeContent('pag1');
}

//ESTITO ES PARA EL POP UP ME CAGOOOOOOOOOOOOOOOOO

const openModalButtons = document.querySelectorAll('[data-modal-target]')
const closeModalButtons = document.querySelectorAll('[data-close-button]')
const overlay = document.getElementById('overlay')

openModalButtons.forEach(button => {
  button.addEventListener('click', () => {
    //const modal = document.querySelector(button.dataset.modalTarget)
    openModal (button.dataset.modalTarget)//(modal)
  })
})

overlay.addEventListener('click', () => {
  const modals = document.querySelectorAll('.modal.active')
  modals.forEach(modal => {
    closeModal(modal)
  })
})

closeModalButtons.forEach(button => {
  button.addEventListener('click', () => {
    const modal = button.closest('.modal')
    closeModal(modal)
  })
})

function openModal(modalId) {
  const modal = document.querySelector(modalId)
  if (modal == null) return
  modal.classList.add('active')
  overlay.classList.add('active')
}

function closeModal(modal) {
  if (modal == null) return
  modal.classList.remove('active')
  overlay.classList.remove('active')
}

//CARDS NUMERO
let myObject = {
      nuevoUsuario: 50,
      nuevaEmpresa: 40,
      nuevoComprador: 10,
      ventasTotales: '1000Bs'  
  };

  let numeroElements = document.querySelectorAll('.numero');
  numeroElements.forEach((element, index) => {
    switch(index) {
      case 0:
        element.innerHTML = myObject.nuevoUsuario;
        break;
      case 1:
        element.innerHTML = myObject.nuevaEmpresa;
        break;
      case 2:
        element.innerHTML = myObject.nuevoComprador;
        break;
      case 3:
       element.innerHTML = myObject.ventasTotales;
       break;  
    }
  });

//NUEVOS USUARIOS EN GENERAL

let users = [
 {
   img: "../../RECURSOS/Patocuchillo.jpg",
   name: "Usuario1",
   type: "Empleado"
 },
 {
   img: "../../RECURSOS/Patocuchillo.jpg",
   name: "Rafael",
   type: "Comprador"
 },
 {
   img: "../../RECURSOS/Patocuchillo.jpg",
   name: "Damaroli",
   type: "Empresa"
 }
];

let imgElements = document.querySelectorAll('.img-usu img');
let nameElements = document.querySelectorAll('.nombre');
let typeElements = document.querySelectorAll('.tipo-usuario');

users.forEach((user, index) => {
 imgElements[index].src = user.img;
 nameElements[index].textContent = user.name;
 if (typeElements[index]) {
   typeElements[index].textContent = user.type;
 }
});


//categorias
let data = [
 {
  categoria: 'Ropa',
 categoryList: ['Category 1', 'Category 2', 'Category 3', 'Category 4',
  'Category 5', 'Category 6', 'Category 7', 'Category 8', 'Category 9', 'Category 10',
  'Category 11', 'Category 12', 'Category 13', 'Category 14', 'Category 15', 'Category 16', 
  'Category 17', 'Category 18', 'Category 19', 'Category 20']

 },
 {
 categoria: 'Zapatos',
 categoryList: ['Category 1', 'Category 2', 'Category 3', 'Category 4',
  'Category 5', 'Category 6', 'Category 7', 'Category 8', 'Category 9', 'Category 10',
  'Category 11', 'Category 12', 'Category 13', 'Category 14', 'Category 15', 'Category 16', 
  'Category 17', 'Category 18', 'Category 19', 'Category 20']
 },
  {
 categoria: 'Accesorios',
 categoryList: ['Category 1', 'Category 2', 'Category 3', 'Category 4',
  'Category 5', 'Category 6', 'Category 7', 'Category 8', 'Category 9', 'Category 10',
  'Category 11', 'Category 12', 'Category 13', 'Category 14', 'Category 15', 'Category 16', 
  'Category 17', 'Category 18', 'Category 19', 'Category 20']
 }
 
];

let categoriaDivs = document.querySelectorAll('.categoria');
let categoryLists = document.querySelectorAll('#category-list');

categoriaDivs.forEach((categoriaDiv, index) => {
 categoriaDiv.textContent = data[index].categoria;

 let categoryList = categoryLists[index];
 categoryList.innerHTML = ''; 

 data[index].categoryList.forEach(category => {
   let listItem = document.createElement('li');
   listItem.textContent = category;
   categoryList.appendChild(listItem);
 });
});















