function registroEmpresas(){
    // console.log(document.getElementById("archivo").value.split('\\').pop());
    // console.log(document.getElementById("archivo").files[0]);
    axios.post  ('http://localhost:5132/Empresas/Registro', {
        nombreEmpresa: document.getElementById("nombre").value,
        direccionEmpresa: document.getElementById("direccion").value,
        archivo: document.getElementById("archivo").files[0]
    },
    {
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'multipart/form-data'
        }
    })
    .then(function (response) {
        console.log(response);
    }).catch(function (error) {
        console.log(error);
    });

}
//POPUP BIENVENIDA
  window.onload = function() {
      document.getElementById('welcomePopup').style.display = 'flex';
  }

  function closePopup() {
      document.getElementById('welcomePopup').style.display = 'none';
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

