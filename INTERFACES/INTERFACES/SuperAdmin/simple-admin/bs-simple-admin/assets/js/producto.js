window.onload= function () {
    const tabla = document.getElementById("tablaPRO");

    let personas = [
        {
            codempresa:5 ,
            nombreproducto: "tenis rojo",
            descproducto: 10,
            precioproducto: 50,
            precioenvioproducto: 5,
            foto: "img",
            create: 21/5/2022,
            last:2/2/2020,
        },
        
    ]

    personas.forEach(persona => {
        tabla.innerHTML += 
        `
        <tr>
            <td>${persona.productos}</td>
            <td><a href="#editEmployeeModal" class="edit" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Edit">&#xE254;</i></a></td>
            <td><a href="#deleteEmployeeModal" class="delete" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Delete">&#xE872;</i></a></td>
        </tr>
        `;
    });

}