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


//ESTITO ES PARA EL POP UP ME CAGOOOOOOOOOOOOOOOOO


function botones() {
    const openModalButtons = document.querySelectorAll('[data-modal-target]')
    const closeModalButtons = document.querySelectorAll('[data-close-button]')
    const overlay = document.getElementById('overlay')
    openModalButtons.forEach(button => {
      button.addEventListener('click', () => {
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
}

function openModal(modalId) {
    const overlay = document.getElementById('overlay')
    const modal = document.querySelector(modalId)
    if (modal == null) return
    modal.classList.add('active')
    overlay.classList.add('active')
}

function closeModal(modal) {
    const overlay = document.getElementById('overlay')
    if (modal == null) return
    modal.classList.remove('active')
    overlay.classList.remove('active')
}

//CARDS NUMERO


let imgElements = document.querySelectorAll('.img-usu img');
let nameElements = document.querySelectorAll('.nombre');
let typeElements = document.querySelectorAll('.tipo-usuario');



function logout(){
  axios.post('http://localhost:5132/auth/logout', {}, {
    headers: {
      "Content-Type": "application/json",
      "Authorization": localStorage.getItem("token")
    }
  }).then((response) => {
    console.log(response.data);
    localStorage.removeItem("token");
    window.location.href = "../INICIO.html";
  }).catch((error) => { 
    console.log(error); 
  });
}
