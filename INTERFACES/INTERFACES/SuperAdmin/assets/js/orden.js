window.onload= function () {
    const tabla = document.getElementById("tablaOR");

    let personas = [
        {
            codempresa: 1,
            codusuario: 32,
            direccionentregaorden:"villamontes",
            fechaenregaorden: 21/2/2023,
            fechapagoorden: 21/1/2023,
            cancelado: null,
            create:21/10/2023,
            update:21/9/2023,

    
        },
        
    ]

    personas.forEach(persona => {
        tabla.innerHTML += 
        `
        <tr>
            <td>${persona.orden}</td>
            <td><a href="#editEmployeeModal" class="edit" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Edit">&#xE254;</i></a></td>
            <td><a href="#deleteEmployeeModal" class="delete" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Delete">&#xE872;</i></a></td>
        </tr>
        `;
    });

}