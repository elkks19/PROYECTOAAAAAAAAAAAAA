let methodNumber = "account";
function setToAccount(){
    methodNumber = "account";
}
function setToPassword(){
    methodNumber = "password";
}
function setToRecibo(){
    methodNumber = "recibo";
    document.getElementById("direccion").value = localStorage.getItem("direccion");
}
function setToSocialMedia(){
    methodNumber = "socialMedia";
}
function setToNotifications(){
    methodNumber = "notifications";
}

function cargarDatosUsuario(){
    localStorage.setItem("codPersona", "PER-001");
    console.log("Cargando datos de usuario");
    axios.get('http://localhost:5132/Personas/Details/' + localStorage.getItem("codPersona"),
    {
        headers:{
            "Content-Type": "application/json"
        }
    }).then((response)=>{
        document.getElementById("user").value = response.data.user;
        document.getElementById("nombres").value = response.data.nombres;
        document.getElementById("apellidos").value = response.data.apellidos;
        document.getElementById("mail").value = response.data.mail;
        document.getElementById("fechaNac").value = response.data.fechaNac;
        localStorage.setItem("direccion", response.data.direccion);
        console.log(response.data);
    }).catch((error)=>{
        console.log(error);
    });

}


function actualizarDatosUsuario(){
    switch(methodNumber){
        case "account":
            actualizarCuenta();
            break;
        case "password":
            actualizarContrasena();
            break;
        case "recibo":
            actualizarRecibo();
            break;
        case "socialMedia":
            actualizarSocialMedia();
            break;
        case "notifications":
            actualizarNotificaciones();
            break;
    }
}

window.onload = cargarDatosUsuario;