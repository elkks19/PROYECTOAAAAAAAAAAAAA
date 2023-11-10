axios.get('http://localhost:5132/lista_espera_empresa/index/ADM-001')
.then((response) => {
    const tablaEmpresas = document.getElementById('solicitudesEmpresas');
    var empresas = response.data;
    empresas.forEach(empresa => {
        tablaEmpresas.innerHTML = `
            <tr >
            	<td class="empresa"><a href="#">${empresa.nombreEmpresa}</a></td>
            	<td class="report" >1</td>
            	<td><button class="btn-revisar" data-modal-target="#modal">Revisar</button>
            		<div class="modal" id="modal">
            			<div class="modal-header">
            			<div class="empresa"><h1>"${empresa.nombreEmpresa}"</h1></div>
            			<button data-close-button class="close-button">&times;</button>
            			</div>
            			<div class="modal-body">
            				<!--AYUDA ACAAAAAA PARA REDIRECCIONAR A LA INTERFAZ DE COMENTARIOS-->
            				<form action="" class="caja-com">
            					<div class="usu">
                                    <div class="img"><img src="imagenes/limonagrio.jpg"></div>
            						<div class="nombre">${empresa.nombreAdmin}</div>
            					</div>
            					<textarea class="aaa" name="comentario"></textarea>
            					<button class="btn">Enviar</button>
            				</form>
            				<div class="baja">
            					<button class="btn-baja" onclick="eliminarEmpresa(${empresa.codEmpresa})">Dar de baja</button>
            					<button class="btn-baja" onclick="suspenderEmpresa(${empresa.codEmpresa})">Suspender</button>
            				</div>

                        
            			</div>
            		</div>
            		<div id="overlay"></div>
            	</td>
            </tr>
        `;
    });



}).catch((error) => {
    console.log(error);
});





