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
  cargarProductos();
}

function verDetalles(cod){
  localStorage.setItem("codProducto", cod);
  window.location.href = "../Productos/detalles productos/detalles.html";
}

function logout(){
  axios.post('http://localhost:5132/auth/logout', {}, {
    headers: {
      "Content-Type": "application/json",
      "Authorization": localStorage.getItem("token")
    }
  }).then((response) => {
    console.log(response.data);
    localStorage.removeItem("token");
    window.location.href = "../../INICIO.html";
  }).catch((error) => { 
    console.log(error); 
  });
}
