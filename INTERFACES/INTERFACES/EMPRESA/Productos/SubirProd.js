function cargarProductos() {
    axios.get("http://localhost:5132/productos/index",
    {
        headers :{
            "Content-Type": "application/json",
            "Authorization": localStorage.getItem("token")
        }
    }).then(response => {
        const tabla = document.getElementById("tablaPRO");

        let datos = response.data;

        datos.forEach(dato => {
          axios.get("http://localhost:5132/productos/getfoto/" + dato.codProducto, {
            responseType: 'blob',
            headers: {
              "content-type": "application/json",
              "Authorization": localStorage.getItem("token"),
            }}).then(response => {
              let imagen = window.URL.createObjectURL(response.data);
              tabla.innerHTML +=
              `
                  <tr>
                      <td><img src="${imagen}" ></td>
                      <td>${dato.nombreProducto}</td>
                      <td>${dato.precioProducto}Bs</td>
                      <td>${dato.cantidadProducto}</td>
                      <td>${dato.descProducto}</td>
                      <td>
                          <a href="#editEmployeeModal" class="edit" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Edit">&#xE254;</i></a>
                          <a href="#deleteEmployeeModal" class="delete" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Delete">&#xE872;</i></a>
                      </td>
                  </tr>
              `;
            }).catch(error => {
              console.log(error);
            });
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
    let descripcionProducto = document.getElementById("descProductoCrear").value;
    let precioProducto = document.getElementById("precioProductoCrear").value;
    let precioEnvioProducto = document.getElementById("precioEnvioProductoCrear").value;
    let fotoProducto = document.getElementById("fotoProducto").files[0];

    axios.post("http://localhost:5132/productos/create/" + codEmpresa, {
        nombreProducto: nombreProducto,
        descProducto: descripcionProducto,
        precioProducto: precioProducto,
        precioEnvioProducto: precioEnvioProducto,
        fotoProducto: fotoProducto
    },{
        headers:{
            "Authorization": localStorage.getItem("token"),
            "Content-Type": "multipart/form-data",
            "Accept": "application/json"
        }
    }).then(response => {
        cargarProductos();
    }).catch(error => {
        console.log(error);
    });
}

function categorias(cod){
    axios.get("http://localhost:5132/productos/categorias/" + cod,{
        headers:{
            "Authorization": localStorage.getItem("token")
        }
    }).then(response => {
        let datos = response.data;
        let body = document.getElementById("categoriasBody");
        datos.forEach(dato => {
            body.innerHTML = body.innerHTML + `
                <input type="text" value="${dato.nombreCategoria}">
            `;
        });
    }).catch(error => {
        console.log(error);
    });
}
