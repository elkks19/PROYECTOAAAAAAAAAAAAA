window.onload = function(){
    const numUsuarios = document.getElementById("numUsuarios");
    const numEmpresas = document.getElementById("numEmpresas");
    const ventasTotales = document.getElementById("ventasTotales");

    axios.get("http://localhost:5132/personas/UltimoMes/", {
        Headers: {
            'Content-Type': 'application/json',
            'Authorization': localStorage.getItem("token"),
            'codPersona': 'PER-004'
        }
    }).then(response =>{
        console.log(response.data);
        const cantEmpresas = response.data.empresas.reduce(sum => sum + 1, 0);
        const cantUsuarios = response.data.usuarios.reduce(sum => sum + 1, 0);
        const ventasTotales = response.data.ventasTotales;
        numUsuarios.innerText = cantUsuarios;
        numEmpresas.innerText = cantEmpresas;
        ventasTotales.innerText = ventasTotales + "Bs";
    }).catch(error => {
        console.log(error);
    });
}