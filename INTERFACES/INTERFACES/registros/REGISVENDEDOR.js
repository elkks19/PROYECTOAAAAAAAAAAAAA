function registroEmpresas(){
    if (document.getElementById("password").value != document.getElementById("password2").value) {
        alert("Las contraseñas no coinciden");
        return;
    }

    axios.post  ('http://localhost:5132/Empresas/Registro', {
        nombreEmpresa: document.getElementById("nombreE").value,
        direccionEmpresa: document.getElementById("direccionE").value,
        archivo: document.getElementById("archivo").files[0],
        nombrePersona: document.getElementById("nombre").value,
        fechaNacPersona: document.getElementById("fechaNac").value,
        mailPersona: document.getElementById("mail").value,
        userPersona: document.getElementById("user").value,
        passwordPersona: document.getElementById("password").value,
    },
    {
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'multipart/form-data'
        }
    })
    .then(function (response) {
        console.log(response);
        registrado();
    }).catch(function (error) {
        console.log(error);
    });

}
//POPUP BIENVENIDA
  window.onload = function() {
      document.getElementById('welcomePopup').style.display = 'none';
  }
  function registrado() {
      document.getElementById('welcomePopup').style.display = 'flex';
  }

  function closePopup() {
    window.location.href = "../INICIO.html";
  }
//ojito
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

