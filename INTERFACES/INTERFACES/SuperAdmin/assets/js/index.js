function detalleOrden(){
  fetch("./DetallesOrden.html")
  .then(function(response){
    return response.text();
  })
  .then(function(text){
    let container = document.getElementById("page-inner");
    container.innerHTML = text;
  });
}

function categoria(){
  fetch("./Categorias.html")
  .then(function(response){
    return response.text();
  })
  .then(function(text){
    let container = document.getElementById("page-inner");
    container.innerHTML = text;
  });
  cargarCategorias();
}

function detalleWishlist(){
  fetch("./Detallewishlist.html")
  .then(function(response){
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
}

function listaEspera(){
  fetch("./ListEmpre.html")
  .then(function(response){
    return response.text();
  })
  .then(function(text){
    let container = document.getElementById("page-inner");
    container.innerHTML = text;
  });
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

function wishlist(){
  fetch("./Wishlist.html")
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
