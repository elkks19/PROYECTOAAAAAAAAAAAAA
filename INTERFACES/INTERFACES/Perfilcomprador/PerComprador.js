let methodNumber = "account";
window.onload = cargarDatosUsuario;

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

function cargarDatosUsuario(){
    document.getElementById("nombreArchivo").innerHTML = ""
    //descarga la foto
    axios.get('http://localhost:5132/Usuarios/GetFoto', {
        headers:{
            "Authorization": localStorage.getItem("token"),
            "Content-Type": "application/json",
        } ,
        responseType: 'blob',
    },
    ).then((response)=>{
        document.getElementById("foto").setAttribute("src", window.URL.createObjectURL(response.data));
    }).catch((error)=>{
        console.log(error);
    });

    //descarga el resto de datos y los pone en sus respectivos cuadritos
    axios.get('http://localhost:5132/Usuarios/Details',
    {
        headers:{
            "Authorization": localStorage.getItem("token"),
            "Content-Type": "application/json",
        }
    }).then((response)=>{
        localStorage.setItem("celular", response.data.celularPersona);
        localStorage.setItem("direccion", response.data.direccionPersona);
        document.getElementById("user").value = response.data.userPersona;
        document.getElementById("nombres").value = response.data.nombrePersona;
        document.getElementById("mail").value = response.data.mailPersona;
        document.getElementById("fechaNac").value = response.data.fechaNacPersona;
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
    }
}

function actualizarRecibo(){
    axios.patch('http://localhost:5132/Usuarios/Edit',
    {
        userPersona: document.getElementById("user").value,
        nombrePersona: document.getElementById("nombres").value,
        fechaNacPersona: document.getElementById("fechaNac").value,
        mailPersona: document.getElementById("mail").value,
        direccionPersona: document.getElementById("direccion").value,
        celularPersona: document.getElementById("celular").value
    },
    {
        headers:{
            'Content-Type': 'application/json',
            'Authorization': localStorage.getItem("token"),
        }
    }).then((response)=>{
        console.log(response.data);
            cargarDatosUsuario();
    }).catch((error)=>{
        console.log(error);
    });
}

function sleep(ms) {
  return new Promise(resolve => setTimeout(resolve, ms));
}


function actualizarCuenta(){
    let imgs = document.getElementById("imagen").files.length;
    if (imgs > 0){
        let img = document.getElementById("imagen").files[0];
        axios.patch('http://localhost:5132/Usuarios/ChangeFoto',
        {
            data: img
        },
        {
            headers:{
                "Content-Type": "multipart/form-data",
                "Authorization": localStorage.getItem("token"),
            }
        }).then((response)=>{
            console.log(response.data);
            cargarDatosUsuario();
        }).catch((error)=>{
            console.log(error);
        });
    }

    axios.patch('http://localhost:5132/Usuarios/Edit',
    {
        userPersona: document.getElementById("user").value,
        nombrePersona: document.getElementById("nombres").value,
        fechaNacPersona: document.getElementById("fechaNac").value,
        mailPersona: document.getElementById("mail").value,
        direccionPersona: document.getElementById("direccion").value,
        celularPersona: document.getElementById("celular").value
    },
    {
        headers:{
            "Authorization": localStorage.getItem("token"),
            "Content-Type": "application/json"
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
        axios.patch('http://localhost:5132/Usuarios/ChangePassword',
        {
            oldPassword: oldPass,
            newPassword: newPass,
        },
        {
            headers:{
                "Content-Type": "application/json",
                "Authorization": localStorage.getItem("token"),
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



