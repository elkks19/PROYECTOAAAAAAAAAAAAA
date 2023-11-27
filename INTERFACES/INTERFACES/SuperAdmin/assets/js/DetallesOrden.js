window.onload= function () {
    const tabla = document.getElementById("tablaDET");

    let personas = [
        {
            cantidadproducto: 10,
            preciototal: 500,
    
        },
        {
            cantidadproducto: 5,
            preciototal: 150,
        },
        {
            cantidadproducto: 2,
            preciototal: 100,

        },
    ]

    personas.forEach(persona => {
        tabla.innerHTML += 
        `
        <tr>
            <td>${persona.detalle}</td>
            <td><a href="#editEmployeeModal" class="edit" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Edit">&#xE254;</i></a></td>
            <td><a href="#deleteEmployeeModal" class="delete" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Delete">&#xE872;</i></a></td>
        </tr>
        `;
    });

}