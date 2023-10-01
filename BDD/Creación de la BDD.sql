

--CREATE DATABASE PruebasProyecto

USE PruebasProyecto;

--Tablas independientes

CREATE TABLE Empresas(
	codEmpresa VARCHAR(10) NOT NULL PRIMARY KEY,
	nombreEmpresa VARCHAR(50) NOT NULL,
	direccionEmpresa VARCHAR(50) NOT NULL,
	
	createdAt DATETIME NOT NULL,
	lastUpdate DATETIME NOT NULL,
);

CREATE TABLE Personas(
	codPersona VARCHAR(10) NOT NULL PRIMARY KEY,
	nombrePersona VARCHAR(20) NOT NULL,
	apPaternoPersona VARCHAR(20) NOT NULL,
	apMaternoPersona VARCHAR(20) NOT NULL,
	fechaNacPersona DATE NOT NULL,
	mailPersona VARCHAR(50) NOT NULL,
	ciPersona VARCHAR(10) NOT NULL,
	direccionPersona VARCHAR(50) NOT NULL,
	userPersona VARCHAR(50) NOT NULL,
	passwordPersona VARCHAR(50) NOT NULL,

	createdAt DATETIME NOT NULL,
	lastUpdate DATETIME NOT NULL,
);

--Tablas dependientes pero que son para cosas que se sienten como independientes
--Ver si es q las uso pq medio q no da y puedo al final poner una columna con su rol en personas y volverla usuarios
CREATE TABLE Usuarios(
	codUsuario VARCHAR(10) NOT NULL PRIMARY KEY,

	codPersona VARCHAR(10) NOT NULL 
	FOREIGN KEY REFERENCES Personas(codPersona),

	configUsuario VARCHAR(MAX) NOT NULL --Esta parte es JSON pq es m�s f�cil para el desarrollo
);

CREATE TABLE Personal_Empresas(
	codPersonalEmpresa VARCHAR(10) NOT NULL PRIMARY KEY,

	codPersona VARCHAR(10) NOT NULL
	FOREIGN KEY REFERENCES Personas(codPersona),

	codEmpresa VARCHAR(10) NOT NULL
	FOREIGN KEY REFERENCES Empresas(codEmpresa)
);

CREATE TABLE Administradores(
	codAdmin VARCHAR(10) NOT NULL PRIMARY KEY,

	codPersona VARCHAR(10) NOT NULL 
	FOREIGN KEY REFERENCES Personas(codPersona)
);


--Cosas que ya de por si suenan dependientes
CREATE TABLE Productos(
	codProducto VARCHAR(10) NOT NULL PRIMARY KEY,

	codEmpresa VARCHAR(10) NOT NULL
	FOREIGN KEY REFERENCES Empresas(codEmpresa),

	nombreProducto VARCHAR(50) NOT NULL,
	descProducto VARCHAR(100) NOT NULL,
	precioProducto FLOAT NOT NULL,
	envioProducto FLOAT NOT NULL,

	pathFotoProducto VARCHAR(10) NOT NULL,
	
	createdAt DATETIME NOT NULL,
	lastUpdate DATETIME NOT NULL
);

CREATE TABLE Categorias(
	codCategoria VARCHAR(10) NOT NULL PRIMARY KEY,
	nombreCategoria VARCHAR(30) NOT NULL,
);



-- PREGUNTAR SI ES QUE SE PUEDE USAR JSON PARA ALMACENAR ESTAS 2 COSAS PQ SE LLENAR� LA TABLA DE COSAS XD
CREATE TABLE Categorias_Por_Producto(
	codProducto VARCHAR(10) NOT NULL
	FOREIGN KEY REFERENCES Productos(codProducto),

	codCategoria VARCHAR(10) NOT NULL
	FOREIGN KEY REFERENCES Categorias(codCategoria)
);

CREATE TABLE Likes(
	codLike VARCHAR(10) NOT NULL PRIMARY KEY,

	codUsuario VARCHAR(10) NOT NULL
	FOREIGN KEY REFERENCES Usuarios(codUsuario),

	codProducto VARCHAR(10) NOT NULL
	FOREIGN KEY REFERENCES Productos(codProducto),

	fechaLike DATETIME NOT NULL,
);
--esas

CREATE TABLE Wishlists(
	codWishlist VARCHAR(10) NOT NULL PRIMARY KEY,

	codUsuario VARCHAR(10) NOT NULL
	FOREIGN KEY REFERENCES Usuarios(codUsuario),
);

--VER SI ESTO TIENE ALG�N SENTIDO GUARDADO COMO JSON CON CLAVES DE PRODUCTOS PARA QUE SEA M�S ISI
--SACAR LA LISTA DE PRODUCTOS PQ IGUAL ANDA MEDIO PELE
CREATE TABLE Detalle_Wishlist(
	codWishList VARCHAR(10) NOT NULL
	FOREIGN KEY REFERENCES Wishlists(codWishlist),

	codProducto VARCHAR(10) NOT NULL
	FOREIGN KEY REFERENCES Productos(codProducto),

	fechaAnadido DATETIME NOT NULL,

	isCarrito BIT NOT NULL DEFAULT 0 --pa saber si la a�adi� al carrito
);

CREATE TABLE Comentarios(
	codComentario VARCHAR(10) NOT NULL PRIMARY KEY,

	codProducto VARCHAR(10) NOT NULL 
	FOREIGN KEY REFERENCES Productos(codProducto),

	codPersona VARCHAR(10) NOT NULL
	FOREIGN KEY REFERENCES Personas(codPersona),

	contenidoComentario VARCHAR(MAX) NOT NULL,
	
	createdAt DATETIME NOT NULL,
	lastUpdate DATETIME NOT NULL
);

CREATE TABLE Ordenes(
	codOrden VARCHAR(10) NOT NULL PRIMARY KEY,
	
	codEmpresa VARCHAR(10) NOT NULL
	FOREIGN KEY REFERENCES Empresas(codEmpresa),
	
	codUsuario VARCHAR(10) NOT NULL
	FOREIGN KEY REFERENCES Usuarios(codUsuario),

	direccionEntregaOrden VARCHAR(50) NOT NULL,

	fechaEntregaOrden DATETIME NULL,
	fechaPagoOrden DATETIME NOT NULL,

	isCancelada BIT NOT NULL DEFAULT 0,
	
	createdAt DATETIME NOT NULL,
	lastUpdate DATETIME NOT NULL
);

--PREGUNTAR SI ES Q SE PUEDE HACER ESTA TABLA DE OTRA FORMA PQ IGUAL SE LLENAR� DE INFO
CREATE TABLE Detalle_Ordenes(
	codOrden VARCHAR(10) NOT NULL
	FOREIGN KEY REFERENCES Ordenes(codOrden),

	codProducto VARCHAR(10) NOT NULL
	FOREIGN KEY REFERENCES Productos(codProducto),

	cantidadProducto INT NOT NULL,
	precioTotal FLOAT NOT NULL,
);

CREATE TABLE Reclamos_Empresas(
	codReclamo VARCHAR(10) NOT NULL PRIMARY KEY,

	codProducto VARCHAR(10) NOT NULL
	FOREIGN KEY REFERENCES Productos(codProducto),

	contenidoReclamo VARCHAR(200) NOT NULL,
	respuestaReclamo VARCHAR(200) NOT NULL,

	codAdmin VARCHAR(10) NULL
	FOREIGN KEY REFERENCES Administradores(codAdmin),

	isRevisado BIT NOT NULL DEFAULT 0,

	fechaCreacionReclamo DATETIME NOT NULL,
	fechaRevisionReclamo DATETIME NULL,
);

CREATE TABLE Lista_Espera_Empresas(
	codEmpresa VARCHAR(10) NOT NULL
	FOREIGN KEY REFERENCES Empresas(codEmpresa),

	codAdmin VARCHAR(10) NULL
	FOREIGN KEY REFERENCES Administradores(codAdmin),

	isRevisado BIT NOT NULL DEFAULT 0,
	fechaSolicitudRevision DATETIME NOT NULL,
	fechaRevision DATETIME
);

