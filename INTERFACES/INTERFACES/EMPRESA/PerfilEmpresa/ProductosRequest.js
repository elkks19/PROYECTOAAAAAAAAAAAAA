function cargarProductos(){
	axios.get('http://localhost:5132/Empresas/Productos',
	{
		headers: {
			"Authorization": localStorage.getItem("token"),
			"Content-Type": "application/json"
		}
	}).then(response => {
		console.log(response.data);
		const container = document.getElementById("contenedor-cards");
		container.innerHTML = "";
		container.innerHTML += `
			<div id="addEmployeeModal" class="modal fade">
				<div class="modal-dialog">
					<div class="modal-content">
						<form>
							<div class="modal-header">						
								<h4 class="modal-title">Agregar Producto</h4>
								<button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
							</div>
							<div class="modal-body">	
								<div class="form-group">
									<label>Nombre Producto</label>
									<input type="text" class="form-control" required id="nombreProductoCrear">
								</div>
								<div class="form-group">
									<label>Desc Producto</label>
									<input type="text" class="form-control" required id="descProductoCrear">
								</div>
								<div class="form-group">
									<label>Precio Producto</label>
									<input type="number" class="form-control" required id="precioProductoCrear">
								</div>	
								<div class="form-group">
									<label>Precio Envio Producto</label>
									<input type="number" class="form-control" required id="precioEnvioProductoCrear">
								</div>	
								<div id="drop-area">
									<input type="file" id="fotoProductoCrear" accept="image/*">
									<label class="button" for="fileElem">Subir foto</label>
									<!--<img id="preview" width=200px height=200px />-->
									</div>				
							</div>
							<div class="modal-footer">
								<input type="button" class="btn btn-default" data-dismiss="modal" value="Cancel">
								<input type="button" class="btn btn-success" data-dismiss="modal" value="Agregar" onclick="crearProducto()">
							</div>
						</form>
					</div>
				</div>
			</div>

			<div id="editEmployeeModal" class="modal fade">
				<div class="modal-dialog">
					<div class="modal-content">
						<form>
							<div class="modal-header">						
								<h4 class="modal-title">Editar un Producto</h4>
								<button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
							</div>
							<div class="modal-body">					
								<div class="form-group">
									<label>Nombre Producto</label>
									<input type="text" class="form-control" id="nombreProductoEdit">
								</div>
								<div class="form-group">
									<label>Descripción Producto</label>
									<input type="text" class="form-control" id="descProductoEdit">
								</div>
								<div class="form-group">
									<label>Precio Producto</label>
									<input type="number" class="form-control" id="precioProductoEdit">
								</div>	
								<div class="form-group">
									<label>Precio Envio Producto</label>
									<input type="number" class="form-control" id="precioEnvioProductoEdit">
								</div>	
								<div id="drop-area">
									<input type="file" id="fotoProductoEdit">
									<label class="button" for="fileElem">Subir foto</label>
									</div>		
							</div>
							<div class="modal-footer">
								<input type="button" class="btn btn-default" data-dismiss="modal" value="Cancelar">
								<input type="button" class="btn btn-info" data-dismiss="modal" value="Guardar" onclick="guardarProducto()">
							</div>
						</form>
					</div>
				</div>
			</div>

			<div id="deleteEmployeeModal" class="modal fade">
				<div class="modal-dialog">
					<div class="modal-content">
						<form>
							<div class="modal-header">						
								<h4 class="modal-title">Eliminar Producto</h4>
								<button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
							</div>
							<div class="modal-body">					
								<p>Esta seguro que desea eliminar el Producto?</p>
								<p class="text-warning"><small>Esta acción no se podra Restaurar</small></p>
							</div>
							<div class="modal-footer">
								<input type="button" class="btn btn-default" data-dismiss="modal" value="Cancelar">
								<input type="button" class="btn btn-danger" value="Eliminar" onclick="confirmarEliminar()" data-dismiss="modal">
							</div>
						</form>
					</div>
				</div>
			</div>
		`;

	document.getElementById("nombreProductoCrear").value = "";
	document.getElementById("precioProductoCrear").value = "";
	document.getElementById("precioEnvioProductoCrear").value = "";
	document.getElementById("descProductoCrear").value = "";
	document.getElementById("fotoProductoCrear").value = "";
	document.getElementById("nombreProductoEdit").value = "";
	document.getElementById("precioProductoEdit").value = "";
	document.getElementById("precioEnvioProductoEdit").value = "";
	document.getElementById("descProductoEdit").value = "";
	document.getElementById("fotoProductoEdit").value = "";


		response.data.forEach( producto => {
			axios.get('http://localhost:5132/Productos/getFoto/' + producto.codProducto ,{
				headers: {
					"Content-Type": "application/json"
				},
				responseType: 'blob'
			}).then(response => {
				let img = window.URL.createObjectURL(response.data);
				container.innerHTML +=
				`
					<!--****************4Card prducto-->
						<div class="card">
							<div class="imgBx">
								<img src="${img}">
								<ul class="action">
									<li><a href="../Productos/Estadisticas-x-prod/e-x-producto.html">
										<i class='bx bxs-doughnut-chart'></i>
										<span>Estadísticas</span></a>
									</li>

									<li>
										<i class='bx bxs-analyse'></i>
										<span>Ver detalles</span>
									</li>
									<li type="button" data-toggle="modal" data-target="#editEmployeeModal" onclick="editarProd('${producto.codProducto}')">
										<i class='bx bxs-edit-alt'></i>
										<span>Editar detalles</span>
									</li>
								</ul>
							</div>
							<div class="contenido">
								<div class="producto-nombre">
									<h3>${producto.nombreProducto}</h3>
								</div>
								<div class="precio">
									<h2>${producto.precioProducto}Bs</h2>
								</div>
							</div>
						</div>
						<!--Crd 4-->
					`;
			}).catch(error => {
				console.log(error);
			});
		});
	}).catch(error => {
		console.log(error);
	});
}

function editarProd(cod){
	axios.get('http://localhost:5132/Productos/details/' + cod, {
		headers: {
			"Content-Type": "application/json",
			"Authorization": localStorage.getItem("token")
		}
	}).then(response => {
		localStorage.setItem("codProducto", cod);
		console.log(response.data);
		const producto = response.data;
		document.getElementById("nombreProductoEdit").value = producto.nombreProducto;
		document.getElementById("precioProductoEdit").value = producto.precioProducto;
		document.getElementById("precioEnvioProductoEdit").value = producto.precioEnvioProducto;
		document.getElementById("descProductoEdit").value = producto.descProducto;
	}).catch(error => {
		console.log(error);
	});
}


function guardarProducto(){
	let cod = localStorage.getItem("codProducto");
	axios.post('http://localhost:5132/Productos/edit/' + cod, {
		nombreProducto: document.getElementById("nombreProductoEdit").value,
		precioProducto: document.getElementById("precioProductoEdit").value,
		precioEnvioProducto: document.getElementById("precioEnvioProductoEdit").value,
		descProducto: document.getElementById("descProductoEdit").value
	}, {
		headers: {
			"Content-Type": "application/json",
			"Authorization": localStorage.getItem("token")
		}
	}).then(response => {
		console.log(response.data);
		if (document.getElementById("fotoProductoEdit").files.length != 0){
			cambiarFoto();
		}
		cargarProductos();
	}).catch(error => {
		console.log(error);
	});
}

function cambiarFoto(){
	let cod = localStorage.getItem("codProducto");
	axios.post('http://localhost:5132/Productos/changeFoto/' + cod, {
		fotoProducto: document.getElementById("fotoProductoEdit").files[0]
	},
	{
		headers: {
			"Content-Type": "multipart/form-data",
			"Authorization": localStorage.getItem("token")
		}
	}).then(response => {
		cargarProductos();
	}).catch(error => {
		console.log(error);
	});
}

function crearProducto(){
	axios.post('http://localhost:5132/Productos/create/' + localStorage.getItem("codEmpresa"), {
		nombreProducto: document.getElementById("nombreProductoCrear").value,
		precioProducto: document.getElementById("precioProductoCrear").value,
		precioEnvioProducto: document.getElementById("precioEnvioProductoCrear").value,
		descProducto: document.getElementById("descProductoCrear").value,
		fotoProducto: document.getElementById("fotoProductoCrear").files[0]
	}, {
		headers: {
			"Content-Type": "multipart/form-data",
			"Authorization": localStorage.getItem("token")
		}
	}).then(response => {
		console.log(response.data);
		cargarProductos();
	}).catch(error => {
		console.log(error);
	});
}