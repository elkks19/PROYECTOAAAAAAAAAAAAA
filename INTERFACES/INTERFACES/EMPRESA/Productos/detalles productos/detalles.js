let colorCircles = document.querySelectorAll(".color-circle");
colorCircles.forEach((circle) => {
 circle.addEventListener("click", selectColor, false);
});

function selectColor(event) {
 // Remove the 'selected' class from all circles
 colorCircles.forEach((circle) => {
   circle.classList.remove("selected");
 });

 // Add the 'selected' class to the clicked circle
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