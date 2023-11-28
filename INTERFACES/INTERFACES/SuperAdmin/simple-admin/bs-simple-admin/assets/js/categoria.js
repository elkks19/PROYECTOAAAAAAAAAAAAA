window.onload= function () {
    const tabla = document.getElementById("tablaCAT");
    let datos = [];
    axios.get('http://localhost:5132/categorias/index', {
        headers:{
            "Authorization": localStorage.getItem("token")
        }
    }).then(response => {
        datos = response.data;
    }).catch(error => {
        console.log(error);
    })


    datos.forEach(dato => {
        tabla.innerHTML += 
        `
        <tr>
            <td>${persona.categoria}</td>
            <td><a href="#editEmployeeModal" class="edit" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Edit">&#xE254;</i></a></td>
            <td><a href="#deleteEmployeeModal" class="delete" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Delete">&#xE872;</i></a></td>
        </tr>
        `;
    });
}
