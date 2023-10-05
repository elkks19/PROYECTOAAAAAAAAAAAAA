function myFunction() {
    var x = document.getElementById("password");
    // var x2 = document.getElementById("myInput2");
    var y = document.getElementById("hide1");
    var z = document.getElementById("hide2");

    if (x.type === 'password') {
        x.type = "text";
        // x2.type = "text";
        y.style.display = "block";
        z.style.display = "none";
    }
    else {
        x.type = "password";
        // x2.type = "password";
        y.style.display = "none";
        z.style.display = "block";
    }
}



const dropArea = document.getElementById("drop-area");

dropArea.addEventListener("dragenter", (e) => {
    e.preventDefault();
});
dropArea.addEventListener("dragover", (e) => {
    e.preventDefault();
});

dropArea.addEventListener("drop", (e) => {
    e.preventDefault();
    const files = e.dataTransfer.files;

});

var user;
var password;

function prueba(){
    user = document.getElementById("user").value
    password = document.getElementById("password").value
    axios.post("http://localhost:5132/auth/registroUsuarios",
    {
        nombrePersona: document.getElementById("nombre").value,
        apPaternoPersona: document.getElementById("apPaterno").value,
        apMaternoPersona: document.getElementById("apMaterno").value,
        fechaNacPersona: document.getElementById("fechaNac").value,
        mailPersona: document.getElementById("mail").value,
        ciPersona: document.getElementById("ci").value,
        direccionPersona: document.getElementById("direccion").value,
        userPersona: user,
        passwordPersona: password
    },{
        headers:{
            "Content-Type": "application/json"
        }
    }
    ).then((response)=>{
        login(user, password)
        console.log(response.data);
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
        localStorage.setItem("token", response.data);
        if(response.data != ""){
            window.location.href = "../Inicio.html";
        }
    }).catch((error)=>{
        console.log(error);
    });
}