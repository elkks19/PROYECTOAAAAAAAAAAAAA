axios.get('http://localhost:5132/lista_espera_empresa/index/ADM-001')
.then((response) => {
    const tablaEmpresas = document.getElementById('solicitudesEmpresas');
    var empresas = response.data;
	const tabla= document.getElementById('reclamosEmpresas');
	var i = tabla.rows.length + 2;
	console.log(i);
    empresas.forEach(empresa => {
		if (empresa.isRevisado == true){
			checked = "checked";
		}
		else{
			checked = "";
		}
        tablaEmpresas.innerHTML += `
				<tr class="empresaRow">
					<td class="empresa"><a href="#">${empresa.nombreEmpresa}</a></td>
					<td>
						<label class="switch">
						<input type="checkbox" id="myToggle" ${checked}>
						<span class="slider round"></span>
						</label>
						<p id="status"></p>
					</td>
					<td><button class="btn-revisar" data-modal-target="#modal${i}">Revisar</button>
						<div class="modal" id="modal${i}">
							<div class="modal-header">
							<div class="empresa"><h1>${empresa.nombreEmpresa}</h1></div>
							<button data-close-button class="close-button">&times;</button>
							</div>
							<div class="modal-body">
								<a  href="../USUcomentarios/index.html">Ver Documentos</a>
								<form action="" class="caja-com">
									<div class="usu">
										<div class="img"><img src="imagenes/limonagrio.jpg"></div>
										<divc class="nombre">${empresa.nombreAdmin}</div>
									</div>
									<textarea class="aaa" name="comentario" placeholder="Añade retroalimentación"></textarea>
									<button class="btn">Enviar</button>
								</form>
								<div class="baja">
									<button class="btn-baja">Habilitar</button>
									<button class="btn-baja">Mantener en espera</button>
								</div>

							
							</div>
						</div>
						<div id="overlay"></div>
					</td>
				</tr>
        `;
		i++;
    });
}).catch((error) => {
    console.log(error);
});





