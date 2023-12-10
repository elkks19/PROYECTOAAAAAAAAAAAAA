window.onload = function () {
    localStorage.setItem("productos-en-wishlist", "");

    axios.get("http://localhost:5132/wishlists/index", {
        headers: {
            "content-type": "application/json",
            "Authorization": localStorage.getItem("token"),
        },
    }).then((response) => {
        const contenedorCarritoVacio = document.querySelector("#carrito-vacio");
        const contenedorCarritoProductos = document.querySelector("#carrito-productos");
        const contenedorCarritoAcciones = document.querySelector("#carrito-acciones");
        const contenedorCarritoComprado = document.querySelector("#carrito-comprado");
        contenedorCarritoVacio.classList.add("disabled");
        contenedorCarritoProductos.classList.remove("disabled");
        contenedorCarritoAcciones.classList.remove("disabled");
        contenedorCarritoComprado.classList.add("disabled");

        response.data.forEach(producto => {
            axios.get("http://localhost:5132/productos/getfoto/" + producto.codProducto, {
                responseType: 'blob',
                headers: {
                    "content-type": "application/json",
                }
            }).then((response) => {
                let div = document.getElementById("wishlist-productos");
                let imagen = window.URL.createObjectURL(response.data);
                div.innerHTML += `
                <div class="carrito-producto">
                    <img class="carrito-producto-imagen" src="${imagen}" alt="${producto.nombreProducto}">
                    <div class="carrito-producto-titulo">
                        <small>Nombre</small>
                        <h3>${producto.nombreProducto}</h3>
                    </div>
                    <div class="carrito-producto-precio">
                        <small>Precio</small>
                        <p>${producto.precioProducto} Bs</p>
                    </div>
                    <div class="carrito-producto-subtotal">
                        <small>Subtotal</small>
                        <p>${producto.precio * producto.cantidad} Bs</p>
                    </div>
                    <button class="carrito-producto-eliminar" id="${producto.codProducto}"><i class="bi bi-trash-fill"></i></button>
                </div>
                `;
            });
        });
    }).catch((error) => {
        console.log(error)
    });
}
