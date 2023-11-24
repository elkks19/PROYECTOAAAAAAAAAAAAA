window.onload = function(){
    localStorage.setItem("productos-en-carrito", "");
}

let productos = [];

axios.get("http://localhost:5132/productos/getall",{
    headers: {
        "Authorization": localStorage.getItem("token"),
        "content-type": "application/json",
    }
}).then((response) => {
    response.data.forEach(p => {
            let prod = {
                id : p.codProducto,
                nombre : p.nombreProducto,
                precio : p.precioProducto,
                codEmpresa : p.codEmpresa
            }
            productos.push(prod);
    });
    cargarProductos(productos);

}).catch((error) => {
    console.log(error)
});


const contenedorProductos = document.querySelector("#contenedor-productos");
const botonesCategorias = document.querySelectorAll(".boton-categoria");
const tituloPrincipal = document.querySelector("#titulo-principal");
let botonesAgregar = document.querySelectorAll(".producto-agregar");
const numerito = document.querySelector("#numerito");


botonesCategorias.forEach(boton => boton.addEventListener("click", () => {
    aside.classList.remove("aside-visible");
}))

function logout(){
    axios.post("http://localhost:5132/auth/logout", {},
    {
        headers: {
            "content-type": "application/json",
            "Authorization": localStorage.getItem("token"),
        }
    }).then((response) => {
        localStorage.removeItem("token");
        window.location.href = "../../INICIO.html";
    }).catch((error) => {
        console.log(error)
    });
        

}

function buscar(){
    const barraBusqueda = document.getElementById("barraBusqueda");
    axios.post("http://localhost:5132/productos/search", 
    {
        search: barraBusqueda.value,
    },
    {
        headers: {
            "content-type": "application/json",
            "Accept": "application/json",
            "Authorization": localStorage.getItem("token"),
        },
    }).then((response) => {
        productos = [];
        response.data.forEach(p => {
                let prod = {
                    id : p.codProducto,
                    nombre : p.nombreProducto,
                    precio : p.precioProducto,
                    codEmpresa : p.codEmpresa
                }
                productos.push(prod);
        });
        cargarProductos(productos);
    }).catch((error) => {
        console.log(error)
    });
}


function cargarProductos(productosElegidos) {

    contenedorProductos.innerHTML = "";

    productosElegidos.forEach(producto => {
            axios.get("http://localhost:5132/productos/getfoto/" + producto.id, 
            {
                responseType: 'blob',
                headers:{
                    "content-type": "application/json",
                }
            }).then((response) => {
                let img = window.URL.createObjectURL(response.data);
                const div = document.createElement("div");
                div.classList.add("producto");
                div.innerHTML = `
                   <div class="card">
                        <div class="imgBx">
                            <img class="producto-imagen" src="${producto.imagen}" alt="${producto.titulo}">
                            <ul class="action">
                                                <li><a href="#">
                                                    <i class='bx bxs-star'></i>
                                                    <span>Agregar a Wishlist</span></a>
                                                </li>

                                                <li>
                                                    <i class='bx bxs-analyse'></i>
                                                    <span>Ver detalles</span>
                                                </li>
                                                
                            </ul>
                        </div>
                            <div class="producto-detalles">
                                <h3 class="producto-titulo">${producto.titulo}</h3>
                                <p class="producto-precio">$${producto.precio}</p>
                                <button class="producto-agregar" id="${producto.id}">Agregar al carrito</button>
                            </div>
                    </div> 
                `;

                contenedorProductos.append(div);
                actualizarBotonesAgregar();
            }).catch((error) => {
                console.log(error)
            });
    });
}


botonesCategorias.forEach(boton => {
    boton.addEventListener("click", (e) => {

        botonesCategorias.forEach(boton => boton.classList.remove("active"));
        e.currentTarget.classList.add("active");

        if (e.currentTarget.id != "todos") {
            const productoCategoria = productos.find(producto => producto.categoria.id === e.currentTarget.id);
            tituloPrincipal.innerText = productoCategoria.categoria.nombre;
            const productosBoton = productos.filter(producto => producto.categoria.id === e.currentTarget.id);
            cargarProductos(productosBoton);
        } else {
            tituloPrincipal.innerText = "Todos los productos";
            cargarProductos(productos);
        }

    })
});

function actualizarBotonesAgregar() {
    botonesAgregar = document.querySelectorAll(".producto-agregar");

    botonesAgregar.forEach(boton => {
        boton.addEventListener("click", agregarAlCarrito);
    });
}

let productosEnCarrito;

let productosEnCarritoLS = localStorage.getItem("productos-en-carrito");

if (productosEnCarritoLS) {
    productosEnCarrito = JSON.parse(productosEnCarritoLS);
    actualizarNumerito();
} else {
    productosEnCarrito = [];
}

function agregarAlCarrito(e) {

    Toastify({
        text: "Producto agregado",
        duration: 3000,
        close: true,
        gravity: "top", // `top` or `bottom`
        position: "right", // `left`, `center` or `right`
        stopOnFocus: true, // Prevents dismissing of toast on hover
        style: {
        //   background: "linear-gradient(62deg, #FBAB7E 0%, #F7CE68 100%)",
          borderRadius: "2rem",
          textTransform: "uppercase",
          fontSize: ".75rem",
          background: "rgb(94,77,0)",
            background: "linear-gradient(90deg, rgba(94,77,0,0.665703781512605) 0%, rgba(237,156,9,1) 100%)"
        },
        offset: {
            x: '1.5rem', // horizontal axis - can be a number or a string indicating unity. eg: '2em'
            y: '1.5rem' // vertical axis - can be a number or a string indicating unity. eg: '2em'
          },
        onClick: function(){} // Callback after click
      }).showToast();

    const idBoton = e.currentTarget.id;
    const productoAgregado = productos.find(producto => producto.id === idBoton);

    axios.post("http://localhost:5132/Carrito/Create/" + productoAgregado.id, {},
    {
        headers:{
            "Authorization": localStorage.getItem("token"),
            "content-type": "application/json",
        }
    }).then((response) => {
        console.log(response.data);
    }).catch((error) => {
        console.log(error)
    });

    if(productosEnCarrito.some(producto => producto.id === idBoton)) {
        const index = productosEnCarrito.findIndex(producto => producto.id === idBoton);
        productosEnCarrito[index].cantidad++;
    } else {
        productoAgregado.cantidad = 1;
        productosEnCarrito.push(productoAgregado);
    }

    actualizarNumerito();

    localStorage.setItem("productos-en-carrito", JSON.stringify(productosEnCarrito));
}

function actualizarNumerito() {
    let nuevoNumerito = productosEnCarrito.reduce((acc, producto) => acc + producto.cantidad, 0);
    numerito.innerText = nuevoNumerito;
}