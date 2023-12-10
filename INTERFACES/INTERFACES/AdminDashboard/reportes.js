function descargarUsuarios(){
    axios.get('http://localhost:5132/empresas/usuarios', {
        responseType: 'blob'
    }).then((response) => {
        let a = document.createElement("a");
        document.body.appendChild(a);
        a.style = "display: none";

        let url = window.URL.createObjectURL(response.data);
        a.href = url;
        a.download = 'reporteUsuarios' + '.pdf';
        a.click();
        window.URL.revokeObjectURL(url);

    }).catch(error => console.log(error));
}

function descargarVentas(){
    axios.get('http://localhost:5132/empresas/ventas', {
        responseType: 'blob'
    }).then((response) => {
        let a = document.createElement("a");
        document.body.appendChild(a);
        a.style = "display: none";

        let url = window.URL.createObjectURL(response.data);
        a.href = url;
        a.download = 'reporteVentas' + '.pdf';
        a.click();
        window.URL.revokeObjectURL(url);

    }).catch(error => console.log(error));

}

function descargarEmpresas(){
    axios.get('http://localhost:5132/empresas/empresas', {
        responseType: 'blob'
    }).then((response) => {
        let a = document.createElement("a");
        document.body.appendChild(a);
        a.style = "display: none";

        let url = window.URL.createObjectURL(response.data);
        a.href = url;
        a.download = 'reporteEmpresas' + '.pdf';
        a.click();
        window.URL.revokeObjectURL(url);

    }).catch(error => console.log(error));
}

function descargarGuardados(){
    axios.get('http://localhost:5132/empresas/guardados', {
        responseType: 'blob'
    }).then((response) => {
        let a = document.createElement("a");
        document.body.appendChild(a);
        a.style = "display: none";

        let url = window.URL.createObjectURL(response.data);
        a.href = url;
        a.download = 'guardadosWishlist' + '.pdf';
        a.click();
        window.URL.revokeObjectURL(url);

    }).catch(error => console.log(error));
}
function descargarVisitas(){
    axios.get('http://localhost:5132/empresas/visitas', {
        responseType: 'blob'
    }).then((response) => {
        let a = document.createElement("a");
        document.body.appendChild(a);
        a.style = "display: none";

        let url = window.URL.createObjectURL(response.data);
        a.href = url;
        a.download = 'visitas' + '.pdf';
        a.click();
        window.URL.revokeObjectURL(url);

    }).catch(error => console.log(error));
}