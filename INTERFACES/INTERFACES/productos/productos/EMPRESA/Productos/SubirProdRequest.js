window.onload = cargarProductos();

function cargarProductos(){
    const table = document.getElementById("table-body");
    axios.get('http://localhost:5132/productos/index/EMP-001')
    .then(response => {
        console.log(response.data);

        table.innerHTML = "";
        response.data.forEach(producto => {
            table.innerHTML += `
            <tr>
                <td><img src="img2.jpg" ></td>
                <td>${producto.nombreProducto}</td>
                <td>${producto.precioProducto}Bs</td>
                <td>Categoria 2</td>
                <td>${producto.cantidadRestante}</td>
                <td>Tjvnskjdvnskjvnksj</td>
                    <td>
                    <button class="Modificar" type="button" onclick="modifyProduct(this)">Modificar</button>
                    <button class="Eliminar" type="button" onclick="deleteProduct(this)">Eliminar</button>
                </td>
            </tr>
            `
            
        });

    }).catch(error => {
        console.log(error);
    });
}



function subir(){
    let nombreProducto = document.getElementById("product-name").value;
    let precioProducto = document.getElementById("product-price").value;
    let cantidadRestante = document.getElementById("product-quantity").value;
    let descProducto = document.getElementById("product-description").value;

    axios.post('http://localhost:5132/productos/create/EMP-001',{
        'nombreProducto': nombreProducto,
        'precioProducto': precioProducto,
        'cantidadRestante': cantidadRestante,
        'descProducto': descProducto
    }).then(response => {
        console.log(response.data);
        cargarProductos();
    }).catch(error => {
        console.log(error);
    });
}