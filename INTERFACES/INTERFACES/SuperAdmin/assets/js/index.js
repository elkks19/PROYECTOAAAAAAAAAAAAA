window.onload = categoria();

function categoria(){
  fetch("./Categorias.html")
  .then(function(response){
    cargarCategorias();
    return response.text();
  })
  .then(function(text){
    let container = document.getElementById("page-inner");
    container.innerHTML = text;
  });
}

function empresa(){
  fetch("./Empres.html")
  .then(function(response){
    return response.text();
  })
  .then(function(text){
    let container = document.getElementById("page-inner");
    container.innerHTML = text;
  });
  cargarEmpresas();
}

function orden(){
  fetch("./Orden.html")
  .then(function(response){
    return response.text();
  })
  .then(function(text){
    let container = document.getElementById("page-inner");
    container.innerHTML = text;
  });
  cargarOrdenes();
}

function persona(){
  fetch("./Persona.html")
  .then(function(response){
    return response.text();
  })
  .then(function(text){
    let container = document.getElementById("page-inner");
    container.innerHTML = text;
  });
}

function producto(){
  fetch("./Producto.html")
  .then(function(response){
    return response.text();
  })
  .then(function(text){
    let container = document.getElementById("page-inner");
    container.innerHTML = text;
  });
  cargarProductos();
}

function reclamo(){
  fetch("./ReclamosEmpresa.html")
  .then(function(response){
    return response.text();
  })
  .then(function(text){
    let container = document.getElementById("page-inner");
    container.innerHTML = text;
  });
}

function logout(){
  axios.post('http://localhost:5132/auth/logout', {},
  {
    headers: {
      'Authorization': localStorage.getItem('token')
    }
  }).then(response => {
    localStorage.removeItem('token');
    window.location.href = '../../INICIO.html';
  }).catch(function(error){
    console.log(error);
  });
}
