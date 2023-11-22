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

//PRODUCTOS (ESTA PARTE NO FUNCIONA)
let data = 
[
 {
   "name": "Body Básico",
   "price": "84Bs",
   "rating": 4,
   "image": "../FotosRopa/Body84.jpg"
 },
 {
   "name": "Parachute",
   "price": "90Bs",
   "rating": 5,
   "image": "../FotosRopa/parachute90.jpg"
 },
 // .....
]

let products = JSON.parse(data);
console.log(products);

let container = document.querySelector(".contenedor-cards");

products.forEach(product => {
 // Crea card
 let card = document.createElement("div");
 card.className = "card";

 // Crea image box
 let imgBx = document.createElement("div");
 imgBx.className = "imgBx";
 let img = document.createElement("img");
 img.src = product.image;
 imgBx.appendChild(img);
 card.appendChild(imgBx);

 // Crea contenido
 let content = document.createElement("div");
 content.className = "contenido";

 // Crea nombre del producto
 let productName = document.createElement("div");
 productName.className = "producto-nombre";
 let h3 = document.createElement("h3");
 h3.textContent = product.name;
 productName.appendChild(h3);
 content.appendChild(productName);

 // Crea precio
 let price = document.createElement("div");
 price.className = "precio";
 let h2 = document.createElement("h2");
 h2.textContent = product.price;
 price.appendChild(h2);

 // Crea calificacion
 let rating = document.createElement("div");
 rating.className = "calificacion";
 for (let i = 0; i < product.rating; i++) {
   let star = document.createElement("i");
   star.className = "fa fa-star";
   rating.appendChild(star);
 }
 price.appendChild(rating);
 content.appendChild(price);


 card.appendChild(content);

 container.appendChild(card);
});











