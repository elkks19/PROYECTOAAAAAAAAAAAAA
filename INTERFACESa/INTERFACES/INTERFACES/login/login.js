function myFunction() {
    var x = document.getElementById("password");
    var y = document.getElementById("hide1");
    var z = document.getElementById("hide2");

    if (x.type === 'password') {
        x.type = "text";
        y.style.display = "block";
        z.style.display = "none";
    }
    else {
        x.type = "password";
        y.style.display = "none";
        z.style.display = "block";
    }
}


function prueba(){
    var errorUser = document.getElementById("errorUser");
    var errorPass = document.getElementById("errorPass");

    var userInput = document.getElementById("user").value;
    var passInput = document.getElementById("password").value;

    if (userInput.length === 0) {
        errorUser.style.visibility = "visible";
        errorUser.innerHTML = 'El campo usuario no puede estar vacío';
    }
    else{
        errorUser.style.visibility = "hidden";
    }

    if (passInput.length === 0) {
        errorPass.style.visibility = "visible";
        errorPass.innerHTML = 'El campo contraseña no puede estar vacío';
    }
    else{
        errorPass.style.visibility = "hidden";
    }

    axios.post("http://localhost:5132/auth/login",
    {
        userPersona: document.getElementById("user").value,
        passwordPersona: document.getElementById("password").value
    }
    ).then((response)=>{
        console.log(response);
        localStorage.setItem("token", response.data.token);
        localStorage.setItem("codUsuario", response.data.codUsu);
    }).catch((error)=>{
        console.log(error);
        if(error.response.status === 400){
            alert("Usuario o contraseña incorrectos");
        }
    });
}