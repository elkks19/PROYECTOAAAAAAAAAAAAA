function getArchivo(codEmpresa){
    axios.get("http://localhost:5132/lista_espera_empresa/getarchivo/" + codEmpresa)
    .then((response) => {
        console.log(response.data);
    }).catch((error) => {
        console.log(error);
    });

}