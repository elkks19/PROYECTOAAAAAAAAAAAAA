window.onload= function () {
    const tabla = document.getElementById("tablaCAT");

    let personas = [
        {
            categoria: 'tenis',
    
        },
        {
            categoria: 'Prenda',
   
        },
        {
            categoria: 'accesorio',

        },
    ]

    personas.forEach(persona => {
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