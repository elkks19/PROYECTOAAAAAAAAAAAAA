window.onload = function() {

    const tabla = document.getElementById("tablaPRO");

    let datos = [];

    axios.get("http://localhost:5132/productos/index",
    {
        headers :{
            "Content-Type": "application/json",
            "Authorization": localStorage.getItem("token")
        }
    }).then(response => {
        datos = response.data;

        datos.forEach(dato => {
            tabla.innerHTML += 
            `
            <tr>
                <td>${dato.codEmpresa}</td>
                <td>${dato.nombreProducto}</td>
                <td>${dato.descProducto}</td>
                <td>${dato.precioProducto}</td>
                <td>${dato.precioEnvioProducto}</td>
                <td>${dato.createdAt}</td>
                <td>${dato.lastUpdate}</td>
                <td><a onclick=editar('${dato.codProducto}') href="#editEmployeeModal" class="edit" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Edit">&#xE254;</i></a></td>
                <td><a onclick=eliminar('${dato.codProducto}') href="#deleteEmployeeModal" class="delete" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Delete">&#xE872;</i></a></td>
            </tr>
           `;
        });
    }).catch(error => {
        console.log(error);
    });
}

function editar(cod){
    let codEmpresa = document.getElementById("codEmpresa");
    let nombreProducto = document.getElementById("nombreProducto");
    let descripcionProducto = document.getElementById("descripcionProducto");
    let precioProducto = document.getElementById("precioProducto");
    let precioEnvioProducto = document.getElementById("precioEnvioProducto");

    axios.get("http://localhost:5132/productos/details/" + cod,{
        headers: {
            "Authorization": localStorage.getItem("token")
        }
    }).then(response => {
        localStorage.setItem("productoEdicion", JSON.stringify(response.data));
        codEmpresa.value = response.data.codEmpresa;
        nombreProducto.value = response.data.nombreProducto;
        descripcionProducto.value = response.data.descProducto;
        precioProducto.value = response.data.precioProducto;
        precioEnvioProducto.value = response.data.precioEnvioProducto;
    }).catch(error =>{
        console.log(error);
    })
}


function guardar(){
    let codProducto = JSON.parse(localStorage.getItem("productoEdicion")).codProducto;
    let codEmpresa = document.getElementById("codEmpresa").value;
    let nombreProducto = document.getElementById("nombreProducto").value;
    let descripcionProducto = document.getElementById("descripcionProducto").value;
    let precioProducto = document.getElementById("precioProducto").value;
    let precioEnvioProducto = document.getElementById("precioEnvioProducto").value;

    axios.post("http://localhost:5132/productos/edit/" + codProducto, {
        codEmpresa : codEmpresa,
        nombreProducto: nombreProducto,
        descProducto: descripcionProducto,
        precioProducto: precioProducto,
        precioEnvioProducto: precioEnvioProducto
    },
    {
        headers: {
            "Authorization": localStorage.getItem("token")
        }
    }).catch(error => {
        console.log(error);
    })
}

function confirmarEliminar(){
    let codProducto = localStorage.getItem("codProducto");

    axios.post("http://localhost:5132/productos/delete/" + codProducto, {
        headers:{
            "Authorization": localStorage.getItem("token")
        }
    }).catch(error => {
        console.log(error);
    });
}

function eliminar(cod){
    localStorage.setItem("codProducto", cod);
}

function crear(){
    let codEmpresa = document.getElementById("codEmpresaCrear").value;
    let nombreProducto = document.getElementById("nombreProductoCrear").value;
    let descripcionProducto = document.getElementById("descripcionProductoCrear").value;
    let precioProducto = document.getElementById("precioProductoCrear").value;
    let precioEnvioProducto = document.getElementById("precioEnvioProductoCrear").value;
    axios.post("http://localhost:5132/productos/create", {
        codEmpresa : codEmpresa,
        nombreProducto: nombreProducto,
        descProducto: descripcionProducto,
        precioProducto: precioProducto,
        precioEnvioProducto: precioEnvioProducto
    });
}