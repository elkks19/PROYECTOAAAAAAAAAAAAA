window.onload= function () {
    const tabla = document.getElementById("tablaRE");

    let personas = [
        {
            codproducto:5 ,
            codusuario:1 ,
            contenidoreclamo: "el tenis se encuentra roto",
            codadmin: 10,
            revisado: "si",
            fechacreacionreclamo: 21/5/2022,
            fecharevisionreclamo:25/5/2022,
            respuestareclamo: "se tomara acciones en contra de la empresa",
        },
        
    ]

    personas.forEach(persona => {
        tabla.innerHTML += 
        `
        <tr>
            <td>${persona.reclamos}</td>
            <td><a href="#editEmployeeModal" class="edit" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Edit">&#xE254;</i></a></td>
            <td><a href="#deleteEmployeeModal" class="delete" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Delete">&#xE872;</i></a></td>
        </tr>
        `;
    });

}