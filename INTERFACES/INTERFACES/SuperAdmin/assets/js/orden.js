function cargarOrdenes(){
    axios.get('http://localhost:5132/Orden/index', {
        headers: {
            'Content-Type': 'application/json',
            'Authorization': localStorage.getItem('token')
        }
    }).then(response => {
        let datos = response.data;
        let tabla = document.getElementById('tablaOR');
        tabla.innerHTML = '';

        datos.forEach(dato => {
            tabla.innerHTML +=`
            <tr>
                <td scope="col">${dato.codEmpresa}</td>
                <td scope="col">${dato.codUsuario}</td>
                <td scope="col">${dato.direccionEntregaOrden}</td>
                <td scope="col">${dato.fechaEntregaOrden}</td>
                <td scope="col">${dato.fechaPagoOrden}</td>
                <td scope="col">${dato.isCancelada}</td>
                <td scope="col">${dato.createdAt}</td>
                <td scope="col">${dato.lastUpdate}</td>
                <td>
                    <a onclick="detailsOrden('${dato.codOrden}')" href="#editEmployeeModal" class="edit" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Edit">&#xE254;</i></a>
                    <a onclick="localStorage.setItem('codOrden', '${dato.codOrden}')" href="#deleteEmployeeModal" class="delete" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Delete">&#xE872;</i></a>
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
        document.getElementById('nombreCategoriaEdit').value = response.data.nombreCategoria;
    });
}

function editarOrden(){
    axios.patch('http://localhost:5132/Ordenes/edit/' + localStorage.getItem("codCategoria"), 
    {
        nombreCategoria: document.getElementById('nombreCategoriaEdit').value,
    },
    {
        headers: {
            'Content-Type': 'application/json',
            'Authorization': localStorage.getItem('token')
        }
    }).then(response => {
        cargarCategorias();
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
        cargarCategorias();
    }).catch(error => {
        console.log(error);
    })
}

function eliminarOrden(){
    axios.delete('http://localhost:5132/Ordenes/delete/' + localStorage.getItem("codCategoria")
    ,{
        headers: {
            'Content-Type': 'application/json',
            'Authorization': localStorage.getItem('token')
        }
    }).then(response => {
        cargarCategorias();
    }).catch(error => {
        console.log(error);
    });
}