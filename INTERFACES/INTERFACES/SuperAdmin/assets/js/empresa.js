function cargarEmpresas(){
    axios.get('http://localhost:5132/Empresas/index', {
        headers: {
            'Content-Type': 'application/json',
            'Authorization': localStorage.getItem('token')
        }
    }).then(response => {
        console.log(response.data);
        let datos = response.data;
        let tabla = document.getElementById('tablaEMP');
        tabla.innerHTML = '';


        datos.forEach(dato => {
            let fechaRev = dato.listaEspera.fechaRevision == null ? "Sin revisar" : dato.listaEspera.fechaRevision;
            let code = dato.listaEspera.isRevisado ? "e5ca" : "e5cd";
            tabla.innerHTML +=`
            <tr>
                <td scope="col">${dato.nombreEmpresa}</td>
                <td scope="col">${dato.direccionEmpresa}</td>
                <td scope="col"><i class="material-icons">&#x${code}</i></td>
                <td scope="col">${fechaRev}</td>
                <td scope="col">${dato.listaEspera.fechaSolicitudRevision}</td>
                <td scope="col">${dato.createdAt}</td>
                <td scope="col">${dato.lastUpdate}</td>
                <td>
                    <a onclick="detailsCategoria('${dato.codCategoria}')" href="#editEmployeeModal" class="edit" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Edit">&#xE254;</i></a>
                    <a onclick="localStorage.setItem('codCategoria', '${dato.codCategoria}')" href="#deleteEmployeeModal" class="delete" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Delete">&#xE872;</i></a>
                </td>
            </tr>
            `;
        });

    }).catch(error => {
        console.log(error);
    })
}

function detailsCategoria(cod){
    axios.get('http://localhost:5132/Categorias/details/' + cod, {
        headers: {
            'Content-Type': 'application/json',
            'Authorization': localStorage.getItem('token')
        }
    }).then(response => {
        localStorage.setItem('codCategoria', cod)
        document.getElementById('nombreCategoriaEdit').value = response.data.nombreCategoria;
    });
}

function editarCategoria(){
    axios.patch('http://localhost:5132/Categorias/edit/' + localStorage.getItem("codCategoria"), 
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

function crearCategoria(){
    axios.post('http://localhost:5132/Categorias/create', {
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

function eliminarCategoria(){
    axios.delete('http://localhost:5132/Categorias/delete/' + localStorage.getItem("codCategoria")
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