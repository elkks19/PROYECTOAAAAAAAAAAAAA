function llenarReclamos(){
    axios.get('http://localhost:5132/administradores/reclamos', {
        headers: {
            "Content-Type": "application/json",
            "Authorization": localStorage.getItem("token")
        }
    }).then((response) => {
        console.log(response.data);
        let datos = response.data;
        const tabla = document.getElementById('reclamosEmpresas');
        datos.forEach(dato => {
            axios.get(`http://localhost:5132/empresas/getfoto/${dato.codEmpresa}`, {
                responseType: 'blob',
                headers: {
                    "Content-Type": "application/json",
                    "Authorization": localStorage.getItem("token")
                }
            }).then((response) => {
                let imagen = window.URL.createObjectURL(response.data);
                let estado = "";
                if (dato.isActiva == true) {
                    estado = "checked";
                }

                tabla.innerHTML += `
                    <tr class="row-empresa">
                        <td class="empresa"><img src="${imagen}"><a>${dato.nombreEmpresa}</a></td>
                        <td class="report">${dato.cantReportes}</td>
                        <td>
                            <label class="switch">
                            <input type="checkbox" id="myToggle" ${estado}>
                            <span class="slider round"></span>
                            </label>
                            <p id="status"></p>
                        </td>
                        <td><button class="btn-revisar" data-modal-target="#modal${dato.nombreEmpresa}">Revisar</button>
                            <div class="modal" id="modal${dato.nombreEmpresa}">
                                <div class="modal-header">
                                    <div class="empresa"><img src="${imagen}"><h1>${dato.nombreEmpresa}</h1></div>
                                    <button data-close-button class="close-button">&times;</button>
                                </div>
                                <div class="modal-body">
                                    <a>Ver Reportes de usuarios</a>
                                    <div class="baja">
                                        <button class="btn-baja">Dar de baja</button>
                                        <button class="btn-baja">Suspender</button>
                                    </div>
                                </div>
                            </div>
                            <div id="overlay"></div>
                        </td>
                    </tr>
                `;
                botones();
            }).catch((error) => {
                console.log(error);
            });
        });
    }).catch((error) => {
        console.log(error);
    });
}
