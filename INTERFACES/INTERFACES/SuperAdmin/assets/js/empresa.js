window.onload= function () {
    const tabla = document.getElementById("tablaEMP");

    let personas = [
        {
            nombredeempresa: "Tieda de Dieguito",
            direcciomempresa:  "callepapas",
            archivodeverificación: "",
            social: "facebook",
                                    
        },
        {
            nombredeempresa: "Tieda de ale",
            direcciomempresa:  "calleTabla",
            archivodeverificación: "",
            social: "facebook",
        },
        
    ]

    personas.forEach(persona => {
        tabla.innerHTML += 
        `
        <tr>
            <td>${persona.empresa}</td>
            <td><a href="#editEmployeeModal" class="edit" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Edit">&#xE254;</i></a></td>
            <td><a href="#deleteEmployeeModal" class="delete" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Delete">&#xE872;</i></a></td>
        </tr>
        `;
    });

}