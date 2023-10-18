let methodNumber = "account";
localStorage.setItem("codUsuario", "USU-004");

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
    axios.get('http://localhost:5132/Usuarios/Details/' + localStorage.getItem("codUsuario"),
    {
        headers:{
            "Content-Type": "application/json"
        }
    }).then((response)=>{
        document.getElementById("user").value = response.data.userPersona;
        document.getElementById("nombres").value = response.data.nombrePersona;
        document.getElementById("apellidos").value = response.data.apellidosPersona;
        document.getElementById("mail").value = response.data.mailPersona;
        document.getElementById("fechaNac").value = response.data.fechaNacPersona;
        localStorage.setItem("direccion", response.data.direccionPersona);
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


function actualizarCuenta(){
    axios.patch('http://localhost:5132/Usuarios/Edit/' + localStorage.getItem("codUsuario"),
    {
        userPersona: document.getElementById("user").value,
        nombrePersona: document.getElementById("nombres").value,
        apPaternoPersona: document.getElementById("apellidos").value.split(" ")[0],
        apMaternoPersona: document.getElementById("apellidos").value.split(" ")[1],
        fechaNacPersona: document.getElementById("fechaNac").value,
        mailPersona: document.getElementById("mail").value
    },
    {
        headers:{
            "Content-Type": "application/json"
        }
    }).then((response)=>{
        console.log(response.data);
        alert("Datos actualizados");
    }).catch((error)=>{
        console.log(error);
    });
}

function actualizarContrasena(){
    let oldPass = document.getElementById("oldPassword").value;
    let newPass = document.getElementById("newPassword").value;
    let newConfirmation = document.getElementById("newPassword2").value;
    if (newPass != newConfirmation){
        alert("Las contraseñas no coinciden");
        return;
    }
    else{
        axios.patch('http://localhost:5132/Usuarios/ChangePassword/' + localStorage.getItem("codUsuario"),
        {
            codPersona: localStorage.getItem("codUsuario"),
            oldPassword: oldPass,
            newPassword: newPass,
        },
        {
            headers:{
                "Content-Type": "application/json"
            }
        }).then((response)=>{
            console.log(response.data);
            alert("Contraseña actualizada");
        }).catch((error)=>{
            console.log(error);
        });
    }
}


window.onload = cargarDatosUsuario;