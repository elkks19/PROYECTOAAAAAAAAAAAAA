

--CREATE DATABASE PruebasProyecto

USE PruebasProyecto;

--Tablas independientes

CREATE TABLE Empresas(
	id INT IDENTITY(1, 1),
	codEmpresa VARCHAR(45) NOT NULL PRIMARY KEY,
	nombreEmpresa VARCHAR(150) NOT NULL,
	direccionEmpresa VARCHAR(50) NOT NULL,

	createdAt DATETIME NOT NULL,
	lastUpdate DATETIME NOT NULL,
);

CREATE TABLE Personas(
	id INT IDENTITY(1, 1),
	codPersona VARCHAR(45) NOT NULL PRIMARY KEY,
	nombrePersona VARCHAR(70) NOT NULL,
	apPaternoPersona VARCHAR(70) NOT NULL,
	apMaternoPersona VARCHAR(70) NOT NULL,
	fechaNacPersona VARCHAR(70) NOT NULL,
	mailPersona VARCHAR(50) NOT NULL,
	ciPersona VARCHAR(10) NOT NULL,
	direccionPersona VARCHAR(50) NOT NULL,
	userPersona VARCHAR(20) NOT NULL,
	passwordPersona VARCHAR(20) NOT NULL,

	createdAt DATETIME NOT NULL,
	lastUpdate DATETIME NOT NULL,
);

--Tablas dependientes pero que son para cosas que se sienten como independientes
--Ver si es q las uso pq medio q no da y puedo al final poner una columna con su rol en personas y volverla usuarios
CREATE TABLE Usuarios(
	id INT IDENTITY(1, 1) NOT NULL,
	codUsuario VARCHAR(45) NOT NULL PRIMARY KEY,

	codPersona VARCHAR(45) NOT NULL 
	FOREIGN KEY REFERENCES Personas(codPersona),

	configuracionUsuario VARCHAR(200) NOT NULL --Esta parte es JSON pq es más fácil para el desarrollo
);

CREATE TABLE PersonalEmpresas(
	id INT IDENTITY(1, 1) NOT NULL,
	codPersonalEmpresa VARCHAR(45) NOT NULL PRIMARY KEY,

	codPersona VARCHAR(45) NOT NULL
	FOREIGN KEY REFERENCES Personas(codPersona),

	codEmpresa VARCHAR(45) NOT NULL
	FOREIGN KEY REFERENCES Empresas(codEmpresa)
);

CREATE TABLE Administradores(
	id INT IDENTITY(1, 1) NOT NULL,
	codAdmin VARCHAR(45) NOT NULL PRIMARY KEY,

	codPersona VARCHAR(45) NOT NULL 
	FOREIGN KEY REFERENCES Personas(codPersona)
);


--Cosas que ya de por si suenan dependientes
CREATE TABLE Productos(
	id INT IDENTITY(1, 1),
	codProducto VARCHAR(45) NOT NULL PRIMARY KEY,

	codEmpresa VARCHAR(45) NOT NULL
	FOREIGN KEY REFERENCES Empresas(codEmpresa),

	nombreProducto VARCHAR(50) NOT NULL,
	descProducto VARCHAR(50) NOT NULL,
	precioProducto FLOAT NOT NULL,
	envioProducto FLOAT NOT NULL,

	pathFoto VARCHAR(45) NOT NULL,
	
	createdAt DATETIME NOT NULL,
	lastUpdate DATETIME NOT NULL
);

CREATE TABLE Categorias(
	id INT IDENTITY(1, 1),
	codCategoria VARCHAR(45) NOT NULL PRIMARY KEY,
	nombreCategoria VARCHAR(20) NOT NULL,
);



-- PREGUNTAR SI ES QUE SE PUEDE USAR JSON PARA ALMACENAR ESTAS 2 COSAS PQ SE LLENARÁ LA TABLA DE COSAS XD
CREATE TABLE ProductoCategorias(
	codProducto VARCHAR(45) NOT NULL
	FOREIGN KEY REFERENCES Productos(codProducto),

	codCategoria VARCHAR(45) NOT NULL
	FOREIGN KEY REFERENCES Categorias(codCategoria)
);
CREATE TABLE PersonasLikeProductos(
	id INT IDENTITY(1, 1) NOT NULL,
	codLike VARCHAR(45) NOT NULL PRIMARY KEY,

	codPersona VARCHAR(45) NOT NULL
	FOREIGN KEY REFERENCES Personas(codPersona),

	codProducto VARCHAR(45) NOT NULL
	FOREIGN KEY REFERENCES Productos(codProducto),

	fechaLike DATETIME NOT NULL,
);
--esas

CREATE TABLE UsuarioWishlist(
	id INT IDENTITY(1, 1) NOT NULL,
	codWishlist VARCHAR(45) NOT NULL PRIMARY KEY,

	codUsuario VARCHAR(45) NOT NULL
	FOREIGN KEY REFERENCES Usuarios(codUsuario),
);

--VER SI ESTO TIENE ALGÚN SENTIDO GUARDADO COMO JSON CON CLAVES DE PRODUCTOS PARA QUE SEA MÁS ISI
--SACAR LA LISTA DE PRODUCTOS PQ IGUAL ANDA MEDIO PELE
CREATE TABLE WishlistProductos(
	codWishList VARCHAR(45) NOT NULL
	FOREIGN KEY REFERENCES UsuarioWishlist(codWishlist),

	codProducto VARCHAR(45) NOT NULL
	FOREIGN KEY REFERENCES Productos(codProducto),

	fechaAñadido DATETIME NOT NULL,

	estaCarrito BIT NOT NULL DEFAULT 0 --pa saber si la añadió al carrito
);

CREATE TABLE Comentarios(
	id INT IDENTITY(1, 1),
	codComentario VARCHAR(45) NOT NULL PRIMARY KEY,

	codProducto VARCHAR(45) NOT NULL 
	FOREIGN KEY REFERENCES Productos(codProducto),

	codPersona VARCHAR(45) NOT NULL
	FOREIGN KEY REFERENCES Personas(codPersona),

	contenidoComentario VARCHAR(120) NOT NULL,
	
	createdAt DATETIME NOT NULL,
	lastUpdate DATETIME NOT NULL
);

CREATE TABLE Ordenes(
	id INT IDENTITY(1, 1) NOT NULL,
	codOrden VARCHAR(45) NOT NULL PRIMARY KEY,
	
	codEmpresa VARCHAR(45) NOT NULL
	FOREIGN KEY REFERENCES Empresas(codEmpresa),
	
	codPersona VARCHAR(45) NOT NULL
	FOREIGN KEY REFERENCES Personas(codPersona),

	direccionEntregaOrden VARCHAR(50) NOT NULL,

	fechaEntregaOrden DATETIME NULL,
	fechaPagoOrden DATETIME NOT NULL,

	fechaCreacionOrden DATETIME NOT NULL,
	isCancelada BIT NOT NULL DEFAULT 0
);

--PREGUNTAR SI ES Q SE PUEDE HACER ESTA TABLA DE OTRA FORMA PQ IGUAL SE LLENARÁ DE INFO
CREATE TABLE OrdenProductos(
	id INT IDENTITY(1, 1),

	codOrden VARCHAR(45) NOT NULL
	FOREIGN KEY REFERENCES Ordenes(codOrden),

	codProducto VARCHAR(45) NOT NULL
	FOREIGN KEY REFERENCES Productos(codProducto),

	cantidadProducto INT NOT NULL,
	precioTotal FLOAT NOT NULL,
);

CREATE TABLE ReportesEmpresas(
	id INT IDENTITY(1, 1),
	codReporte VARCHAR(45) NOT NULL PRIMARY KEY,

	codEmpresa VARCHAR(45) NOT NULL
	FOREIGN KEY REFERENCES Empresas(codEmpresa),

	codProducto VARCHAR(45) NOT NULL
	FOREIGN KEY REFERENCES Productos(codProducto),

	contenidoReporte VARCHAR(200) NOT NULL,
	respuestaReporte VARCHAR(200) NOT NULL,

	codAdmin VARCHAR(45) NULL
	FOREIGN KEY REFERENCES Administradores(codAdmin),

	isRevisado BIT NOT NULL DEFAULT 0,

	fechaCreacionReporte DATETIME NOT NULL,
	fechaRevisiónReporte DATETIME NULL,
);

CREATE TABLE ListaEsperaEmpresas(
	id INT IDENTITY(1, 1),
	codListaEspera VARCHAR(45) NOT NULL PRIMARY KEY,

	codEmpresa VARCHAR(45) NOT NULL
	FOREIGN KEY REFERENCES Empresas(codEmpresa),

	codAdmin VARCHAR(45) NOT NULL
	FOREIGN KEY REFERENCES Administradores(codAdmin),

	isRevisado BIT NOT NULL DEFAULT 0,

	createdAt DATETIME NOT NULL,
	lastUpdate DATETIME NOT NULL,
);
