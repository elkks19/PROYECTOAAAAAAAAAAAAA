﻿function myFunction() {
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

    var userValid = false;
    var passValid = false;

    if(userValid == false || passValid == false){
        if (userInput.length === 0) {
            errorUser.style.visibility = "visible";
            errorUser.innerHTML = 'El campo usuario no puede estar vacío';
            userValid = false;
        }
        else{
            errorUser.style.visibility = "hidden";
            userValid = true;
        }

        if (passInput.length === 0) {
            errorPass.style.visibility = "visible";
            errorPass.innerHTML = 'El campo contraseña no puede estar vacío';
            passValid = false;
        }
        else if(passInput.length < 8){
            errorPass.style.visibility = "visible";
            errorPass.innerHTML = 'La contraseña debe tener al menos 8 caracteres';
            passValid = false;
        }
        else{
            errorPass.style.visibility = "hidden";
            passValid = true;
        }
        if(userValid == true && passValid == true){
            console.log("Usuario: " + userInput + " Contraseña: " + passInput); 
            axios.post("http://localhost:5132/auth/login",
            {
                userPersona: document.getElementById("user").value,
                passwordPersona: document.getElementById("password").value
            }
            ).then((response)=>{
                localStorage.setItem("token", response.data.token);
                localStorage.setItem("codUsuario", response.data.codUsu);
                window.location.href = "../Feed/resultado-final/index.html";
            }).catch((error)=>{
                errorUser.style.visibility = "visible";
                errorUser.innerHTML = "Usuario o contraseña incorrectos";
            });
        }
    }
}