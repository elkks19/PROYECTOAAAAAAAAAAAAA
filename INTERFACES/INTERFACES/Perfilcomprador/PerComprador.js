let methodNumber = "account";
window.onload = cargarDatosUsuario;

function nombreArchivo(){
    document.getElementById("nombreArchivo").innerHTML = document.getElementById("imagen").files[0].name;
}
function setToAccount(){
    methodNumber = "account";
}
function setToPassword(){
    methodNumber = "password";
}
function setToRecibo(){
    methodNumber = "recibo";
    document.getElementById("direccion").value = localStorage.getItem("direccion");
    document.getElementById("celular").value = localStorage.getItem("celular");
}
function setToSocialMedia(){
    methodNumber = "socialMedia";
    document.getElementById("facebook").value = JSON.parse(localStorage.getItem("configUsuario")).facebook;
    document.getElementById("instagram").value = JSON.parse(localStorage.getItem("configUsuario")).instagram;
    document.getElementById("twitter").value = JSON.parse(localStorage.getItem("configUsuario")).twitter;
}
function setToNotifications(){
    methodNumber = "notifications";
    document.getElementById("notificaciones").checked = JSON.parse(localStorage.getItem("configUsuario")).notificaciones;
}

function cargarDatosUsuario(){
    document.getElementById("nombreArchivo").innerHTML = ""
    //descarga la foto
    axios.get('http://localhost:5132/Usuarios/GetFoto/' + localStorage.getItem("codUsuario"),
    {
        responseType: 'blob',
    }
    ).then((response)=>{
        document.getElementById("foto").setAttribute("src", window.URL.createObjectURL(response.data));
    }).catch((error)=>{
        console.log(error);
    });

    //descarga el resto de datos y los pone en sus respectivos cuadritos
    axios.get('http://localhost:5132/Usuarios/Details/' + localStorage.getItem("codUsuario"),
    {
        headers:{
            'Content-Type': 'multipart/form-data'
        }
    }).then((response)=>{
        document.getElementById("user").value = response.data.userPersona;
        document.getElementById("nombres").value = response.data.nombrePersona;
        document.getElementById("mail").value = response.data.mailPersona;
        document.getElementById("fechaNac").value = response.data.fechaNacPersona;
        localStorage.setItem("direccion", response.data.direccionPersona);
        localStorage.setItem("celular", response.data.celularPersona);
        localStorage.setItem("configUsuario", JSON.parse(response.data.configUsuario));
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
            actualizarSocialMedia();
            break;
    }
}

function actualizarRecibo(){
    axios.patch('http://localhost:5132/Usuarios/Edit/' + localStorage.getItem("codUsuario"),
    {
        direccionPersona: document.getElementById("direccion").value,
        celularPersona: document.getElementById("celular").value
    },
    {
        headers:{
            'Accept': 'application/json',
            'Content-Type': 'multipart/form-data'
        }
    }).then((response)=>{
        console.log(response.data);
        cargarDatosUsuario();
    }).catch((error)=>{
        console.log(error);
    });
}


function actualizarCuenta(){
    axios.patch('http://localhost:5132/Usuarios/Edit/' + localStorage.getItem("codUsuario"),
    {
        userPersona: document.getElementById("user").value,
        nombrePersona: document.getElementById("nombres").value,
        fechaNacPersona: document.getElementById("fechaNac").value,
        mailPersona: document.getElementById("mail").value,
        img: document.getElementById("imagen").files[0]
    },
    {
        headers:{
            "Accept": "application/json",
            "Content-Type": "multipart/form-data"
        }
    }).then((response)=>{
        console.log(response.data);
        cargarDatosUsuario();
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
            oldPassword: oldPass,
            newPassword: newPass,
        },
        {
            headers:{
                "Content-Type": "application/json"
            }
        }).then((response)=>{
            console.log(response.data);
            cargarDatosUsuario();
        }).catch((error)=>{
            console.log(error);
        });
    }
}


function actualizarSocialMedia(){
    localStorage.setItem("configUsuario", JSON.stringify({
        facebook: document.getElementById("facebook").value,
        instagram: document.getElementById("instagram").value,
        twitter: document.getElementById("twitter").value,
        notificaciones: document.getElementById("notificaciones").checked ? 1 : 0
    }));

    axios.patch('http://localhost:5132/Usuarios/Edit/' + localStorage.getItem("codUsuario"),
    {
        configUsuario : JSON.stringify(localStorage.getItem("configUsuario")),
    },
    {
        headers:{
            'Accept': 'application/json',
            'Content-Type': 'multipart/form-data'
        }
    }).then((response)=>{
        console.log(response.data);
        cargarDatosUsuario();
    }).catch((error)=>{
        console.log(error);
    });
}



