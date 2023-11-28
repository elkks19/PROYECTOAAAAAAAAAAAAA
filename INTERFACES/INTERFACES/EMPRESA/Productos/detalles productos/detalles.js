window.onload = function(){
  document.getElementById('reportLink').addEventListener('click', openModal);


  let codProducto = localStorage.getItem("codProducto");

  axios.get("http://localhost:5132/productos/details/" + codProducto, {
    headers:{
      "Content-Type": "application/json",
      "Authorization": localStorage.getItem("token")
    }
  }).then(response => {
    console.log(response.data);
    let div = document.getElementById("detalles-producto");
    let producto = response.data;
    div.innerHTML +=
    `
      <span class="product-category">Blusas</span>
      <h3>${producto.nombreProducto}</h3>
      <span class="product-price">${producto.precioProducto}Bs</span>
      <p>
        ${producto.descProducto}
      </p>
    `;
  }).catch(error => {
    console.log(error);
  })

}


let colorCircles = document.querySelectorAll(".color-circle");
colorCircles.forEach((circle) => {
 circle.addEventListener("click", selectColor, false);
});

function selectColor(event) {

 colorCircles.forEach((circle) => {
   circle.classList.remove("selected");
 });

 
 event.target.classList.add("selected");
}


function getDetalles(){
  const cod = localStorage.getItem("codProducto");
  const productInfo = document.getElementById("product-text");
  axios.get('http://localhost:5132/Productos/Details/' + cod, {
    headers: {
      "Content-Type": "application/json",
    }
  }).then(response => {
    console.log(response.data);
    var producto = response.data;
    productInfo.innerHTML =
    `
          <span class="product-category"></span>
          <h3>${producto.nombreProducto}</h3>
          <span class="product-price">${producto.precioProducto}Bs</span>
          <p>
            ${producto.descProducto}
          </p>
          <!--TALLAS-->
          <div class="product-size-container">
              <strong>Selecciona Talla:-</strong>
              <div class="product-size">
                  <!--xl-->
                  <input type="checkbox" class="s-checkbox" id="s-xl">
                  <label for="s-xl" class="s-label">XL</label>
                  <!--Small-->
                  <input type="checkbox" class="s-checkbox" id="s-s">
                  <label for="s-s" class="s-label">S</label>
                  <!--Medium-->
                  <input type="checkbox" class="s-checkbox" id="s-m">
                  <label for="s-m" class="s-label">M</label>
                  <!--Large-->
                  <input type="checkbox" class="s-checkbox" id="s-l">
                  <label for="s-l" class="s-label">L</label>
              </div>
                  <div class="product-color-container">
                  <strong>Selecciona Color:</strong>
                  <div class="product-color">
                      <!--Negro-->
                      <div class="color-circle negro"></div>
                      <!--Cafe-->
                      <div class="color-circle cafe"></div>
                      <!--Beige-->
                      <div class="color-circle beige"></div>
                      <!--Plomo-->
                      <div class="color-circle plomo"></div>
                  </div>
                  </div>
          </div>
          <div class="product-button">
              <a href="#" class="add-bag-btn">Añadir al carrito</a>
              <a href="#" class="add-wishlist-btn">Wishlist</a>
          </div>

      </div>
      `;
    }).catch(error => {
      console.log(error)
    })
}
//--------------- BOTON
// Crear elemento boton
var button = document.createElement("button");
button.className = "perfil";
var img = document.createElement("img");
img.src = "../../../AdminDashboard/imagenes/Damaroli.jpg";
button.appendChild(img);
var h1 = document.createElement("h1");
//nombre de la empresa
h1.textContent = "Damaroli";
button.appendChild(h1);


//mas opciones no me funca aca pero si en el html :c

function openModal() {
  document.getElementById('reportModal').style.display = 'block';
}

function closeModal() {
  document.getElementById('reportModal').style.display = 'none';
}

