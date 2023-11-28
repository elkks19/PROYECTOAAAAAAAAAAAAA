window.onload= function () {
    const tabla = document.getElementById("tablaLIS");

    let personas = [
        {
            aceptadodenegado: "aceptado",
            Fecharevision:21/11/23,
            razon: "cumple los requisitos",
            fechadesolicitud: 1/11/2023,
    
        },
        
    ]

    personas.forEach(persona => {
        tabla.innerHTML += 
        `
        <tr>
            <td>${persona.list}</td>
            <td><a href="#editEmployeeModal" class="edit" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Edit">&#xE254;</i></a></td>
            <td><a href="#deleteEmployeeModal" class="delete" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Delete">&#xE872;</i></a></td>
        </tr>
        `;
    });

}