
USE PruebasProyecto;

--Tablas independientes

CREATE TABLE Empresas(
	id INT IDENTITY(1, 1),
	codEmpresa VARCHAR(45) NOT NULL PRIMARY KEY,
	nombreEmpresa VARCHAR(150) NOT NULL,
	direccionEmpresa VARCHAR(50) NOT NULL,

	CreatedAt TIMESTAMP NOT NULL,
	LastUpdate TIMESTAMP NOT NULL,
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

	CreatedAt TIMESTAMP NOT NULL,
	LastUpdate TIMESTAMP NOT NULL,
);

--Tablas dependientes pero que son para cosas que se sienten como independientes
CREATE TABLE Usuarios(
	codPersona INT NOT NULL,
	codUsuario INT NOT NULL,

);

CREATE TABLE Personal_Empresas(
	codPersona INT NOT NULL,
	codEmpresa INT NOT NULL,
);

CREATE TABLE Administradores(
	codPersona INT NOT NULL,
	codAdmin INT NOT NULL
);


--Cosas que ya de por si suenan dependientes
CREATE TABLE Productos(
	id INT IDENTITY(1, 1),
	codProducto VARCHAR(45) NOT NULL PRIMARY KEY,
	nombreProducto VARCHAR(50) NOT NULL,
	descProducto VARCHAR(50) NOT NULL,
	precioProducto FLOAT NOT NULL,
	envioProducto FLOAT NOT NULL,

	pathFoto VARCHAR(45) NOT NULL,
	
	CreatedAt TIMESTAMP NOT NULL,
	LastUpdate TIMESTAMP NOT NULL
);

CREATE TABLE Categorias(
	id INT IDENTITY(1, 1),
	codTag VARCHAR(45) NOT NULL PRIMARY KEY,
	nombreTag VARCHAR(20) NOT NULL,
);

CREATE TABLE ProductoCategorias(
	codProducto VARCHAR(45) NOT NULL,
	codTag VARCHAR(45) NOT NULL
);

CREATE TABLE Comentarios(
	id INT IDENTITY(1, 1),
	codComentario VARCHAR(45) NOT NULL,
	codProducto VARCHAR(45) NOT NULL,
	codPersona VARCHAR(45) NOT NULL,
	contenidoComentario VARCHAR(120) NOT NULL,
	
	CreatedAt TIMESTAMP NOT NULL,
	LastUpdate TIMESTAMP NOT NULL
);

CREATE TABLE Ordenes(
	id INT IDENTITY(1, 1) NOT NULL,
	codOrden VARCHAR(45) NOT NULL PRIMARY KEY,
	codEmpresa VARCHAR(45) NOT NULL,
	codPersona VARCHAR(45) NOT NULL,
	fechaOrden DATETIME NOT NULL,
	fechaEntregaOrden DATETIME NOT NULL,
	fechaPagoOrden DATETIME NOT NULL,
);

CREATE TABLE OrdenProductos(
	id INT IDENTITY(1, 1),
	codOrdenProducto VARCHAR(45) NOT NULL PRIMARY KEY,
	codOrden
	codProducto VARCHAR(45),
	cantidadProducto INT NOT NULL,
	precioTotal FLOAT NOT NULL,
	
);