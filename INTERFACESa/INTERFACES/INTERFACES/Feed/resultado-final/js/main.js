let productos = [];
document.onload = function(){
    localStorage.removeItem("productos-en-carrito");
}

axios.get("http://localhost:5132/productos/details/EMP-001",{}).then((response) => {

    response.data.forEach(p => {
        axios.get("http://localhost:5132/productos/getfoto/" + p.codProducto, {
            responseType: 'blob'
        })
        .then((response) => {
            let prod = {
                id : p.codProducto,
                nombre : p.nombreProducto,
                precio : p.precioProducto,
                imagen : response.data
            }
            productos.push(prod);
            console.log(prod);
        }).catch((error) => {
            console.log(error)
        });
    });

    cargarProductos(productos);
}).catch((error) => {
    console.log(error)
});


// fetch("./js/productos.json")
//     .then(response => response.json())
//     .then(data => {
//         productos = data;
//         cargarProductos(productos);
//     })


const contenedorProductos = document.querySelector("#contenedor-productos");
const botonesCategorias = document.querySelectorAll(".boton-categoria");
const tituloPrincipal = document.querySelector("#titulo-principal");
let botonesAgregar = document.querySelectorAll(".producto-agregar");
const numerito = document.querySelector("#numerito");


botonesCategorias.forEach(boton => boton.addEventListener("click", () => {
    aside.classList.remove("aside-visible");
}))

function logout(){
    axios.post("http://localhost:5132/auth/logout",{
        token: localStorage.getItem("token")
    },
    {
        headers: {
            "content-type": "application/json"
        }
    }).then((response) => {
        localStorage.removeItem("token");
        window.location.href = "../../INICIO.html";
    }).catch((error) => {
        console.log(error)
    });
        

}


function cargarProductos(productosElegidos) {
    contenedorProductos.innerHTML = "";

    productosElegidos.forEach(producto => {

        let img = window.URL.createObjectURL(producto.imagen);
        const div = document.createElement("div");
        div.classList.add("producto");
        div.innerHTML = `
            <img class="producto-imagen" src="${img}" alt="${producto.id}">
            <div class="producto-detalles">
                <h3 class="producto-titulo">${producto.nombre}</h3>
                <p class="producto-precio">${producto.precio} Bs</p>
                <button class="producto-agregar" id="${producto.id}">Agregar</button>
            </div>
        `;

        contenedorProductos.append(div);
    })

    actualizarBotonesAgregar();
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