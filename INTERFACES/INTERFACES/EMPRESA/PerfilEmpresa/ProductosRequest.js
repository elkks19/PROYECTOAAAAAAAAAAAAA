
axios.get('http://localhost:5132/Productos/GetAll',
{
    headers: {
        // "Authorization": localStorage.getItem("token"),
        "Content-Type": "application/json"
    }
}).then(response => {
    console.log(response.data);
    const container = document.getElementById("contenedor-cards");
    response.data.forEach( producto => {
        axios.get('http://localhost:5132/Productos/getFoto/' + producto.codProducto ,{
            headers: {
                // "Authorization": localStorage.getItem("token"),
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
								<li><a onclick="verDetalles('${producto.codProducto}')">
									<i class='bx bxs-edit-alt'></i>
									<span>Editar detalles</span></a>
								</li>
							</ul>
						</div>
						<div class="contenido">
							<div class="producto-nombre">
								<h3>${producto.nombreProducto}</h3>
							</div>
							<div class="precio">
								<h2>${producto.precioProducto}Bs</h2>
								<div class="calificacion">
									<i class="fa fa-star" aria-hidden="true"></i>
									<i class="fa fa-star" aria-hidden="true"></i>
									<i class="fa fa-star" aria-hidden="true"></i>
									<i class="fa fa-star" aria-hidden="true"></i>
									<i class="fa grey fa-star " aria-hidden="true"></i>
								</div>
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


