function myFunction() {
    var x = document.getElementById("password");
    var x2 = document.getElementById("password2");
    var y = document.getElementById("hide1");
    var z = document.getElementById("hide2");

    if (x.type === 'password') {
        x.type = "text";
        x2.type = "text";
        y.style.display = "block";
        z.style.display = "none";
    }
    else {
        x.type = "password";
        x2.type = "password";
        y.style.display = "none";
        z.style.display = "block";
    }
}



const dropArea = document.getElementById("drop-area");


var user;
var password;

function registroUsuarios(){
    user = document.getElementById("user").value;
    password = document.getElementById("password").value;
    axios.post("http://localhost:5132/usuarios/registro",
    {
        nombrePersona: document.getElementById("nombre").value,
        fechaNacPersona: document.getElementById("fechaNac").value,
        mailPersona: document.getElementById("mail").value,
        direccionPersona: document.getElementById("direccion").value,
        userPersona: user,
        passwordPersona: password,
    },{
        headers:{
            "Content-Type": "application/json"
        }
    }
    ).then((response)=>{
        login(user, password)
    }).catch((error)=>{
        console.log(error);
    });
}

function login(user, password){
    axios.post("http://localhost:5132/auth/login",
    {
        userPersona: user,
        passwordPersona: password
    }
    ).then((response)=>{
        localStorage.setItem("token", response.data.token);
        window.location.href = "../Feed/resultado-final/index.html";
    }).catch((error)=>{
        console.log(error);
    });
}

