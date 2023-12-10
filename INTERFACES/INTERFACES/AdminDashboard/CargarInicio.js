window.onload = function() {
    axios.get('http://localhost:5132/usuarios/getfoto', {
        responseType: 'blob',
        headers: {
        "Authorization": localStorage.getItem("token"),
        "Content-Type": "application/json",
        }
    }).then((response) => {
        let pfp = document.getElementById('pfpAdmin');
        pfp.src = window.URL.createObjectURL(response.data);
    }).catch(error => console.log(error));

    axios.get('http://localhost:5132/usuarios/details', {
        headers: {
            "Authorization": localStorage.getItem("token"),
            "Content-Type": "application/json",
        }
    }).then(response => {
        let nombre = document.getElementById('userName');
        nombre.innerHTML = response.data.nombrePersona;
    }).catch(error => console.log(error));

    ChangeContent('pag1');
    const numeroUsuarios = document.getElementById('numUsuarios');
    const numeroCompradores = document.getElementById('numCompradores');
    const numeroEmpresas = document.getElementById('numEmpresas'); 
    const ventasTotales = document.getElementById('ventasTotales'); 

    axios.get('http://localhost:5132/administradores/ultimomes',{
        headers: {
            "Content-Type": "application/json",
            "Authorization": localStorage.getItem("token")
        }
    }).then(response => {
        numeroUsuarios.innerHTML = response.data.usuarios.length;
        numeroCompradores.innerHTML = response.data.compradores.length;
        numeroEmpresas.innerHTML = response.data.empresas.length;
        ventasTotales.innerHTML = response.data.ventasTotales + "Bs";


        const cardUsuarios = document.getElementById('cardUsuarios');
        const cardCompradores = document.getElementById('cardCompradores');
        const cardEmpresas = document.getElementById('cardEmpresas');

        for (let i = 0; i < 3; i++) {
            if (i < response.data.usuarios.length ){
                var usuario = response.data.usuarios[i];
                if (usuario.rol == "empresaNoVerificada"){
                    usuario.rol = "Personal empresa"
                }
                cardUsuarios.innerHTML += `
                    <div class="nuevos-usuario">
                        <div class="img-usu">
                            <img src="../../RECURSOS/Patocuchillo.jpg">
                        </div>
                        <div class="nombreees">
                            <div class="nombre">${usuario.nombrePersona}</div>
                            <div class="tipo-usuario">${usuario.rol}</div>
                        </div>
                    </div>
                    <br>
                `;
            }
            if (i < response.data.compradores.length ){
                var comprador = response.data.compradores[i];
                cardCompradores.innerHTML += `
                    <div class="nuevos-usuario">
                        <div class="img-usu">
                            <img src="../../RECURSOS/Patocuchillo.jpg">
                        </div>
                        <div class="nombreees">
                            <div class="nombre">${comprador.nombrePersona}</div>
                        </div>	
                    </div>
                    <br>
                `;
            }
            if (i < response.data.empresas.length ){
                var empresa = response.data.empresas[i];
                cardEmpresas.innerHTML += `
                    <div class="nuevos-usuario">
                        <div class="img-usu">
                            <img src="../../RECURSOS/Patocuchillo.jpg">
                        </div>
                        <div class="nombreees">
                            <div class="nombre">${empresa.nombreEmpresa}</div>
                        </div>	
                    </div>
                    <br>
                `;
            }
        }
    }).catch(error => {
        console.log(error);
    });
}
