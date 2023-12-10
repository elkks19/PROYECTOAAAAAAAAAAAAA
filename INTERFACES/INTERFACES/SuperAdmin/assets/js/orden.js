function cargarOrdenes(){
    axios.get('http://localhost:5132/Ordenes/index', {
        headers: {
            'Content-Type': 'application/json',
            'Authorization': localStorage.getItem('token')
        }
    }).then(response => {
        let datos = response.data;
        let tabla = document.getElementById('tablaOR');
        tabla.innerHTML = '';

        datos.forEach(dato => {
            let code = dato.isCancelada ? "e5ca" : "e5cd";
            tabla.innerHTML +=`
            <tr>
                <td scope="col">${dato.codEmpresa}</td>
                <td scope="col">${dato.codUsuario}</td>
                <td scope="col">${dato.direccionEntregaOrden}</td>
                <td scope="col">${dato.fechaEntregaOrden}</td>
                <td scope="col">${dato.fechaPagoOrden}</td>
                <td scope="col"><i class="material-icons">&#x${code}</i></td>
                <td scope="col">${dato.createdAt}</td>
                <td scope="col">${dato.lastUpdate}</td>
                <td>
                    <a onclick="detailsOrden('${dato.codOrden}')" href="#editEmployeeModal" class="edit" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Edit">&#xE254;</i></a>
                    <a onclick="localStorage.setItem('codOrden', '${dato.codOrden}')" href="#deleteEmployeeModal" class="delete" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Delete">&#xE872;</i></a>
                    <a onclick="cargarDetallesOrden('${dato.codOrden}')" href="#detalleOrdenModal" class="info" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Delete">&#xE88E;</i></a>
                </td>
            </tr>
            `;
        });

    }).catch(error => {
        console.log(error);
    })
}

function detailsOrden(cod){
    axios.get('http://localhost:5132/Ordenes/details/' + cod, {
        headers: {
            'Content-Type': 'application/json',
            'Authorization': localStorage.getItem('token')
        }
    }).then(response => {
        localStorage.setItem('codOrden', cod)
        document.getElementById('codUsuarioEdit').value = response.data.codUsuario;
        document.getElementById('direccionEntregaOrdenEdit').value = response.data.direccionEntregaOrden;
        document.getElementById('fechaPagoOrdenEdit').value = response.data.fechaPagoOrden;
        document.getElementById('isCanceladaEdit').checked = response.data.isCancelada;
    });
}

function editarOrden(){
    axios.patch('http://localhost:5132/Ordenes/edit/' + localStorage.getItem("codOrden"), 
    {
        codUsuario: document.getElementById('codUsuarioEdit').value,
        direccionEntregaOrden: document.getElementById('direccionEntregaOrdenEdit').value,
        fechaPagoOrden: document.getElementById('fechaPagoOrdenEdit').value,
        isCancelada: document.getElementById('isCanceladaEdit').checked ? true : false,
    },
    {
        headers: {
            'Content-Type': 'application/json',
            'Authorization': localStorage.getItem('token')
        }
    }).then(response => {
        cargarOrdenes();
    }).catch(error => {
        console.log(error);
    })
}

function crearOrden(){
    axios.post('http://localhost:5132/Ordenes/create', {

        nombreCategoria: document.getElementById('nombreCategoria').value,
    },
    {
        headers: {
            'Content-Type': 'application/json',
            'Authorization': localStorage.getItem('token')
        }
    }).then(response => {
        cargarOrdenes();
    }).catch(error => {
        console.log(error);
    })
}

function eliminarOrden(){
    axios.delete('http://localhost:5132/Ordenes/delete/' + localStorage.getItem("codOrden")
    ,{
        headers: {
            'Content-Type': 'application/json',
            'Authorization': localStorage.getItem('token')
        }
    }).then(response => {
        cargarOrdenes();
    }).catch(error => {
        console.log(error);
    });
}

function cargarDetallesOrden(cod){
    axios.get('http://localhost:5132/DetalleOrden/index/' + cod, {
        headers: {
            'Content-Type': 'application/json',
            'Authorization': localStorage.getItem('token')
        }
    }).then(response => {

        let datos = response.data;
        let tabla = document.getElementById('tablaDetallesOR');
        tabla.innerHTML = '';

        datos.forEach(dato => {
            tabla.innerHTML +=`
            <tr>
                <td scope="col">${dato.codProducto}</td>
                <td scope="col">${dato.cantidadProducto}</td>
                <td scope="col">${dato.precioUnitario}</td>
                <td scope="col">${dato.precioTotal}</td>
                <td scope="col">
                    <a onclick="editarDetalleOrden('${dato.codDetalleOrden}')" href="#editDetalleOrdenModal" class="edit" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Edit">&#xE254;</i></a>
                    <a onclick="localStorage.setItem('codDetalleOrden', '${dato.codDetalleOrden}')" href="#deleteDetalleOrdenModal" class="delete" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Delete">&#xE872;</i></a>
                </td>
            </tr>
            `;
        });

    }).catch(error => {
        console.log(error);
        let tabla = document.getElementById('tablaDetallesOR');
        tabla.innerHTML = '<tr><td colspan=4><h4>No hay detalles de ordenes</h3></td></tr>';
    })
}

function editarDetalleOrden(cod){
    axios.get('http://localhost:5132/DetalleOrden/details/' + cod,{
        headers: {
            'Content-Type': 'application/json',
            'Authorization': localStorage.getItem('token')
        }
    }).then(response => {
        localStorage.setItem('codDetalleOrden', cod)
        document.getElementById('codProductoEdit').value = response.data.codProducto;
        document.getElementById('cantidadEdit').value = response.data.cantidadProducto;
    });
}

function guardarDetalleOrden(){
    axios.patch('http://localhost:5132/DetalleOrden/edit/' + localStorage.getItem("codDetalleOrden"), 
    {
        codProducto: document.getElementById('codProductoEdit').value,
        cantidadProducto: document.getElementById('cantidadEdit').value,
    },
    {
        headers: {
            'Content-Type': 'application/json',
            'Authorization': localStorage.getItem('token')
        }
    }).then(response => {
        console.log(response.data);
    }).catch(error => {
        console.log(error);
    })
}

function eliminarDetalleOrden(){
    axios.delete('http://localhost:5132/DetalleOrden/delete/' + localStorage.getItem("codDetalleOrden"))
    .then(response => {
        console.log(response.data);
    }).catch(error => {
        console.log(error);
    });
    cargarDetallesOrden();
}