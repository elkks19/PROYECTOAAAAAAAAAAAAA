function llenarSolicitudes(){
	axios.get('http://localhost:5132/administradores/revisionespendientes',{
		headers: {
			"Content-Type": "application/json",
			"Authorization": localStorage.getItem("token")
		}
	}).then((response) => {
		console.log(response.data);
		const tablaEmpresas = document.getElementById("solicitudesEmpresas");
		var empresas = response.data;
		tablaEmpresas.innerHTML = '';
		empresas.forEach(empresa => {
			tablaEmpresas.innerHTML += `
					<tr class="row-empresa">
						<td class="empresa"><a>${empresa.nombreEmpresa}</a></td>
						<td><button type="button" class="btn-revisar" data-modal-target="#modal${empresa.nombreEmpresa}Revision">Revisar</button>
							<div class="modal" id="modal${empresa.nombreEmpresa}Revision">
								<div class="modal-header">
									<div class="empresa"><h1>${empresa.nombreEmpresa}</h1></div>
									<button data-close-button class="close-button">&times;</button>
								</div>
								<div class="modal-body">
									<a onclick="archivoVerificacion('${empresa.codEmpresa}')">Descargar archivo de verificacion</a>
									<form action="" class="caja-com">
										<div class="usu">
											<div class="img"><img src="imagenes/limonagrio.jpg"></div>
											<div class="nombre">${empresa.nombreAdmin}</div>
										</div>
										<textarea id="razon${empresa.codEmpresa}" class="aaa" name="comentario" placeholder="Añade retroalimentación"></textarea>
									</form>
									<div class="baja">
										<button class="btn-baja" onclick="aceptarEmpresa('${empresa.codEmpresa}')">Habilitar</button>
										<button class="btn-baja" onclick="denegarEmpresa('${empresa.codEmpresa}')">Mantener en espera</button>
									</div>
								</div>
							</div>
							<div id="overlay"></div>
						</td>
					</tr>
			`;
			botones();
		});
	}).catch((error) => {
		console.log(error);
	});
}

function archivoVerificacion(cod){
	axios.get("http://localhost:5132/empresas/archivoVerificacion/" + cod, {
		responseType: 'blob',
		headers: {
			"Content-Type": "application/json",
			"Authorization": localStorage.getItem("token")
		}
	}).then((response) => {
        let a = document.createElement("a");
        document.body.appendChild(a);
        a.style = "display: none";

        let url = window.URL.createObjectURL(response.data);
        a.href = url;
        a.download = `${cod}-Verificacion.${response.data.type.split('/')[1]}`;
        a.click();
        window.URL.revokeObjectURL(url);
	}).catch((error) => {
		console.log(error);
	});
}

function aceptarEmpresa(cod){
	axios.post("http://localhost:5132/administradores/aceptarEmpresa/" + cod, {
		razon: document.getElementById("razon" + cod).value
	},{
		headers: {
			"Content-Type": "application/json",
			"Authorization": localStorage.getItem("token")
		}
	}).then((response) => {
		console.log(response.data);
		llenarSolicitudes();
	}).catch((error) => {
		console.log(error);
	});
}

function denegarEmpresa(cod){
	axios.post("http://localhost:5132/administradores/denegarEmpresa/" + cod, {
		razon: document.getElementById("razon" + cod).value
	}, {
		headers: {
			"Content-Type": "application/json",
			"Authorization": localStorage.getItem("token")
		}
	}).then((response) => {
		console.log(response.data);
		llenarSolicitudes();
	}).catch((error) => {
		console.log(error);
	});
}