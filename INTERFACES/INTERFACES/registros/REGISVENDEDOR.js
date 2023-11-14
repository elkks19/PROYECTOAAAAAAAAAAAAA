function registroEmpresas(){
    // console.log(document.getElementById("archivo").value.split('\\').pop());
    // console.log(document.getElementById("archivo").files[0]);
    axios.post  ('http://localhost:5132/Empresas/Create', {
        nombre: document.getElementById("nombre").value,
        direccion: document.getElementById("direccion").value,
        nombreArchivo: document.getElementById("archivo").value.split('\\').pop(),
        archivo: document.getElementById("archivo").files[0]
    },
    {
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'multipart/form-data'
        }
    })
    .then(function (response) {
        console.log(response);
    }).catch(function (error) {
        console.log(error);
    });

}