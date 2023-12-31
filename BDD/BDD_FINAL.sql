USE [master]
GO
/****** Object:  Database [ProyectoFinal]    Script Date: 12/11/2023 21:46:32 ******/
CREATE DATABASE [ProyectoFinal]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProyectoFinal', FILENAME = N'F:\SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\ProyectoFinal.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ProyectoFinal_log', FILENAME = N'F:\SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\ProyectoFinal_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [ProyectoFinal] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProyectoFinal].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProyectoFinal] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProyectoFinal] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProyectoFinal] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProyectoFinal] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProyectoFinal] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProyectoFinal] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProyectoFinal] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProyectoFinal] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProyectoFinal] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProyectoFinal] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProyectoFinal] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProyectoFinal] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProyectoFinal] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProyectoFinal] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProyectoFinal] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ProyectoFinal] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProyectoFinal] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProyectoFinal] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProyectoFinal] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProyectoFinal] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProyectoFinal] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProyectoFinal] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProyectoFinal] SET RECOVERY FULL 
GO
ALTER DATABASE [ProyectoFinal] SET  MULTI_USER 
GO
ALTER DATABASE [ProyectoFinal] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProyectoFinal] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProyectoFinal] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProyectoFinal] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ProyectoFinal] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ProyectoFinal] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ProyectoFinal', N'ON'
GO
ALTER DATABASE [ProyectoFinal] SET QUERY_STORE = ON
GO
ALTER DATABASE [ProyectoFinal] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [ProyectoFinal]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 12/11/2023 21:46:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Administradores]    Script Date: 12/11/2023 21:46:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Administradores](
	[codAdmin] [nvarchar](10) NOT NULL,
	[codPersona] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Administradores] PRIMARY KEY CLUSTERED 
(
	[codAdmin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categorias]    Script Date: 12/11/2023 21:46:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorias](
	[codCategoria] [nvarchar](10) NOT NULL,
	[nombreCategoria] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Categorias] PRIMARY KEY CLUSTERED 
(
	[codCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CategoriasPorProducto]    Script Date: 12/11/2023 21:46:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoriasPorProducto](
	[codCategoria] [nvarchar](10) NOT NULL,
	[codProducto] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_CategoriasPorProducto] PRIMARY KEY CLUSTERED 
(
	[codCategoria] ASC,
	[codProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comentarios]    Script Date: 12/11/2023 21:46:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comentarios](
	[codComentario] [nvarchar](10) NOT NULL,
	[codPersona] [nvarchar](10) NOT NULL,
	[codProducto] [nvarchar](10) NOT NULL,
	[contenidoComentario] [nvarchar](max) NOT NULL,
	[createdAt] [datetime2](7) NOT NULL,
	[lastUpdate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Comentarios] PRIMARY KEY CLUSTERED 
(
	[codComentario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleOrden]    Script Date: 12/11/2023 21:46:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleOrden](
	[codOrden] [nvarchar](10) NOT NULL,
	[codProducto] [nvarchar](10) NOT NULL,
	[cantidadProducto] [int] NOT NULL,
	[precioTotal] [real] NOT NULL,
 CONSTRAINT [PK_DetalleOrden] PRIMARY KEY CLUSTERED 
(
	[codOrden] ASC,
	[codProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleWishlist]    Script Date: 12/11/2023 21:46:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleWishlist](
	[codWishlist] [nvarchar](10) NOT NULL,
	[codProducto] [nvarchar](10) NOT NULL,
	[fechaAnadido] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_DetalleWishlist] PRIMARY KEY CLUSTERED 
(
	[codWishlist] ASC,
	[codProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empresa]    Script Date: 12/11/2023 21:46:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empresa](
	[codEmpresa] [nvarchar](10) NOT NULL,
	[nombreEmpresa] [nvarchar](50) NOT NULL,
	[direccionEmpresa] [nvarchar](50) NOT NULL,
	[archivoVerificacionEmpresa] [nvarchar](max) NOT NULL,
	[socialMediaEmprsa] [nvarchar](max) NOT NULL,
	[createdAt] [datetime2](7) NOT NULL,
	[lastUpdate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Empresa] PRIMARY KEY CLUSTERED 
(
	[codEmpresa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GuardadoCarrito]    Script Date: 12/11/2023 21:46:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GuardadoCarrito](
	[codGuardadoCarrito] [nvarchar](10) NOT NULL,
	[codUsuario] [nvarchar](10) NOT NULL,
	[codProducto] [nvarchar](10) NOT NULL,
	[fechaGuardado] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_GuardadoCarrito] PRIMARY KEY CLUSTERED 
(
	[codGuardadoCarrito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GuardadoWishlist]    Script Date: 12/11/2023 21:46:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GuardadoWishlist](
	[codGuardadoWishlist] [nvarchar](10) NOT NULL,
	[codUsuario] [nvarchar](10) NOT NULL,
	[codProducto] [nvarchar](10) NOT NULL,
	[fechaGuardado] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_GuardadoWishlist] PRIMARY KEY CLUSTERED 
(
	[codGuardadoWishlist] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Like]    Script Date: 12/11/2023 21:46:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Like](
	[codLike] [nvarchar](10) NOT NULL,
	[codUsuario] [nvarchar](10) NOT NULL,
	[codProducto] [nvarchar](10) NOT NULL,
	[fechaLike] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Like] PRIMARY KEY CLUSTERED 
(
	[codLike] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ListaEsperaEmpresa]    Script Date: 12/11/2023 21:46:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ListaEsperaEmpresa](
	[codEmpresa] [nvarchar](10) NOT NULL,
	[codAdmin] [nvarchar](10) NOT NULL,
	[isAceptado] [bit] NOT NULL,
	[fechaRevision] [datetime2](7) NULL,
	[razonRevision] [nvarchar](max) NULL,
	[fechaSolicitudRevision] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_ListaEsperaEmpresa] PRIMARY KEY CLUSTERED 
(
	[codEmpresa] ASC,
	[codAdmin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LogsAuditoria]    Script Date: 12/11/2023 21:46:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LogsAuditoria](
	[codLog] [nvarchar](10) NOT NULL,
	[codPersona] [nvarchar](10) NOT NULL,
	[accionLog] [nvarchar](max) NOT NULL,
	[fechaLog] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_LogsAuditoria] PRIMARY KEY CLUSTERED 
(
	[codLog] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orden]    Script Date: 12/11/2023 21:46:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orden](
	[codOrden] [nvarchar](10) NOT NULL,
	[codEmpresa] [nvarchar](10) NOT NULL,
	[codUsuario] [nvarchar](10) NOT NULL,
	[direccionEntregaOrden] [nvarchar](max) NOT NULL,
	[fechaEntregaOrden] [datetime2](7) NOT NULL,
	[fechaPagoOrden] [datetime2](7) NOT NULL,
	[isCancelada] [bit] NOT NULL,
	[createdAt] [datetime2](7) NOT NULL,
	[lastUpdate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Orden] PRIMARY KEY CLUSTERED 
(
	[codOrden] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Persona]    Script Date: 12/11/2023 21:46:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persona](
	[codPersona] [nvarchar](10) NOT NULL,
	[userPersona] [nvarchar](450) NOT NULL,
	[passwordPersona] [nvarchar](max) NOT NULL,
	[nombrePersona] [nvarchar](70) NOT NULL,
	[fechaNacPersona] [datetime2](7) NOT NULL,
	[mailPersona] [nvarchar](450) NOT NULL,
	[direccionPersona] [nvarchar](70) NOT NULL,
	[celularPersona] [nvarchar](8) NOT NULL,
	[pathFotoPersona] [nvarchar](max) NOT NULL,
	[createdAt] [datetime2](7) NOT NULL,
	[lastUpdate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Persona] PRIMARY KEY CLUSTERED 
(
	[codPersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonalEmpresa]    Script Date: 12/11/2023 21:46:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonalEmpresa](
	[codPersonalEmpresa] [nvarchar](10) NOT NULL,
	[codEmpresa] [nvarchar](10) NOT NULL,
	[codPersona] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_PersonalEmpresa] PRIMARY KEY CLUSTERED 
(
	[codPersonalEmpresa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 12/11/2023 21:46:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[codProducto] [nvarchar](10) NOT NULL,
	[codEmpresa] [nvarchar](10) NOT NULL,
	[nombreProducto] [nvarchar](50) NOT NULL,
	[descProducto] [nvarchar](100) NOT NULL,
	[precioProducto] [real] NOT NULL,
	[precioEnvioProducto] [real] NOT NULL,
	[pathFotoProducto] [nvarchar](max) NOT NULL,
	[createdAt] [datetime2](7) NOT NULL,
	[lastUpdate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[codProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReclamosEmpresa]    Script Date: 12/11/2023 21:46:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReclamosEmpresa](
	[codReclamo] [nvarchar](10) NOT NULL,
	[codProducto] [nvarchar](10) NOT NULL,
	[codUsuario] [nvarchar](10) NOT NULL,
	[contenidoReclamo] [nvarchar](max) NOT NULL,
	[codAdmin] [nvarchar](10) NOT NULL,
	[isRevisado] [bit] NOT NULL,
	[fechaCreacionReclamo] [datetime2](7) NOT NULL,
	[fechaRevisionReclamo] [datetime2](7) NULL,
	[respuestaReclamo] [nvarchar](max) NULL,
 CONSTRAINT [PK_ReclamosEmpresa] PRIMARY KEY CLUSTERED 
(
	[codReclamo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TokenGuardado]    Script Date: 12/11/2023 21:46:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TokenGuardado](
	[codToken] [nvarchar](10) NOT NULL,
	[codPersona] [nvarchar](10) NOT NULL,
	[Token] [nvarchar](450) NOT NULL,
	[fechaCreacionToken] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_TokenGuardado] PRIMARY KEY CLUSTERED 
(
	[codToken] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 12/11/2023 21:46:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[codUsuario] [nvarchar](10) NOT NULL,
	[codPersona] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[codUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VisitasEmpresa]    Script Date: 12/11/2023 21:46:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VisitasEmpresa](
	[codVisita] [nvarchar](10) NOT NULL,
	[codUsuario] [nvarchar](10) NOT NULL,
	[codEmpresa] [nvarchar](10) NOT NULL,
	[fechaVisita] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_VisitasEmpresa] PRIMARY KEY CLUSTERED 
(
	[codVisita] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Wishlist]    Script Date: 12/11/2023 21:46:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wishlist](
	[codWishlist] [nvarchar](10) NOT NULL,
	[codUsuario] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Wishlist] PRIMARY KEY CLUSTERED 
(
	[codWishlist] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Administradores_codPersona]    Script Date: 12/11/2023 21:46:32 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Administradores_codPersona] ON [dbo].[Administradores]
(
	[codPersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Categorias_nombreCategoria]    Script Date: 12/11/2023 21:46:32 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Categorias_nombreCategoria] ON [dbo].[Categorias]
(
	[nombreCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_CategoriasPorProducto_codProducto]    Script Date: 12/11/2023 21:46:32 ******/
CREATE NONCLUSTERED INDEX [IX_CategoriasPorProducto_codProducto] ON [dbo].[CategoriasPorProducto]
(
	[codProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Comentarios_codPersona]    Script Date: 12/11/2023 21:46:32 ******/
CREATE NONCLUSTERED INDEX [IX_Comentarios_codPersona] ON [dbo].[Comentarios]
(
	[codPersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Comentarios_codProducto]    Script Date: 12/11/2023 21:46:32 ******/
CREATE NONCLUSTERED INDEX [IX_Comentarios_codProducto] ON [dbo].[Comentarios]
(
	[codProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_DetalleOrden_codProducto]    Script Date: 12/11/2023 21:46:32 ******/
CREATE NONCLUSTERED INDEX [IX_DetalleOrden_codProducto] ON [dbo].[DetalleOrden]
(
	[codProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_DetalleWishlist_codProducto]    Script Date: 12/11/2023 21:46:32 ******/
CREATE NONCLUSTERED INDEX [IX_DetalleWishlist_codProducto] ON [dbo].[DetalleWishlist]
(
	[codProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Empresa_nombreEmpresa]    Script Date: 12/11/2023 21:46:32 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Empresa_nombreEmpresa] ON [dbo].[Empresa]
(
	[nombreEmpresa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_GuardadoCarrito_codProducto]    Script Date: 12/11/2023 21:46:32 ******/
CREATE NONCLUSTERED INDEX [IX_GuardadoCarrito_codProducto] ON [dbo].[GuardadoCarrito]
(
	[codProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_GuardadoCarrito_codUsuario]    Script Date: 12/11/2023 21:46:32 ******/
CREATE NONCLUSTERED INDEX [IX_GuardadoCarrito_codUsuario] ON [dbo].[GuardadoCarrito]
(
	[codUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_GuardadoWishlist_codProducto]    Script Date: 12/11/2023 21:46:32 ******/
CREATE NONCLUSTERED INDEX [IX_GuardadoWishlist_codProducto] ON [dbo].[GuardadoWishlist]
(
	[codProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_GuardadoWishlist_codUsuario]    Script Date: 12/11/2023 21:46:32 ******/
CREATE NONCLUSTERED INDEX [IX_GuardadoWishlist_codUsuario] ON [dbo].[GuardadoWishlist]
(
	[codUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Like_codProducto]    Script Date: 12/11/2023 21:46:32 ******/
CREATE NONCLUSTERED INDEX [IX_Like_codProducto] ON [dbo].[Like]
(
	[codProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Like_codUsuario]    Script Date: 12/11/2023 21:46:32 ******/
CREATE NONCLUSTERED INDEX [IX_Like_codUsuario] ON [dbo].[Like]
(
	[codUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_ListaEsperaEmpresa_codAdmin]    Script Date: 12/11/2023 21:46:32 ******/
CREATE NONCLUSTERED INDEX [IX_ListaEsperaEmpresa_codAdmin] ON [dbo].[ListaEsperaEmpresa]
(
	[codAdmin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_ListaEsperaEmpresa_codEmpresa]    Script Date: 12/11/2023 21:46:32 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_ListaEsperaEmpresa_codEmpresa] ON [dbo].[ListaEsperaEmpresa]
(
	[codEmpresa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_LogsAuditoria_codPersona]    Script Date: 12/11/2023 21:46:32 ******/
CREATE NONCLUSTERED INDEX [IX_LogsAuditoria_codPersona] ON [dbo].[LogsAuditoria]
(
	[codPersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Orden_codEmpresa]    Script Date: 12/11/2023 21:46:32 ******/
CREATE NONCLUSTERED INDEX [IX_Orden_codEmpresa] ON [dbo].[Orden]
(
	[codEmpresa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Orden_codUsuario]    Script Date: 12/11/2023 21:46:32 ******/
CREATE NONCLUSTERED INDEX [IX_Orden_codUsuario] ON [dbo].[Orden]
(
	[codUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Persona_mailPersona]    Script Date: 12/11/2023 21:46:32 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Persona_mailPersona] ON [dbo].[Persona]
(
	[mailPersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Persona_userPersona]    Script Date: 12/11/2023 21:46:32 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Persona_userPersona] ON [dbo].[Persona]
(
	[userPersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_PersonalEmpresa_codEmpresa]    Script Date: 12/11/2023 21:46:32 ******/
CREATE NONCLUSTERED INDEX [IX_PersonalEmpresa_codEmpresa] ON [dbo].[PersonalEmpresa]
(
	[codEmpresa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_PersonalEmpresa_codPersona]    Script Date: 12/11/2023 21:46:32 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_PersonalEmpresa_codPersona] ON [dbo].[PersonalEmpresa]
(
	[codPersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Producto_codEmpresa]    Script Date: 12/11/2023 21:46:32 ******/
CREATE NONCLUSTERED INDEX [IX_Producto_codEmpresa] ON [dbo].[Producto]
(
	[codEmpresa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_ReclamosEmpresa_codAdmin]    Script Date: 12/11/2023 21:46:32 ******/
CREATE NONCLUSTERED INDEX [IX_ReclamosEmpresa_codAdmin] ON [dbo].[ReclamosEmpresa]
(
	[codAdmin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_ReclamosEmpresa_codProducto]    Script Date: 12/11/2023 21:46:32 ******/
CREATE NONCLUSTERED INDEX [IX_ReclamosEmpresa_codProducto] ON [dbo].[ReclamosEmpresa]
(
	[codProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_ReclamosEmpresa_codUsuario]    Script Date: 12/11/2023 21:46:32 ******/
CREATE NONCLUSTERED INDEX [IX_ReclamosEmpresa_codUsuario] ON [dbo].[ReclamosEmpresa]
(
	[codUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_TokenGuardado_codPersona]    Script Date: 12/11/2023 21:46:32 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_TokenGuardado_codPersona] ON [dbo].[TokenGuardado]
(
	[codPersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_TokenGuardado_Token]    Script Date: 12/11/2023 21:46:32 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_TokenGuardado_Token] ON [dbo].[TokenGuardado]
(
	[Token] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Usuarios_codPersona]    Script Date: 12/11/2023 21:46:32 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Usuarios_codPersona] ON [dbo].[Usuarios]
(
	[codPersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_VisitasEmpresa_codEmpresa]    Script Date: 12/11/2023 21:46:32 ******/
CREATE NONCLUSTERED INDEX [IX_VisitasEmpresa_codEmpresa] ON [dbo].[VisitasEmpresa]
(
	[codEmpresa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_VisitasEmpresa_codUsuario]    Script Date: 12/11/2023 21:46:32 ******/
CREATE NONCLUSTERED INDEX [IX_VisitasEmpresa_codUsuario] ON [dbo].[VisitasEmpresa]
(
	[codUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Wishlist_codUsuario]    Script Date: 12/11/2023 21:46:32 ******/
CREATE NONCLUSTERED INDEX [IX_Wishlist_codUsuario] ON [dbo].[Wishlist]
(
	[codUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Administradores]  WITH CHECK ADD  CONSTRAINT [FK_Administradores_Persona_codPersona] FOREIGN KEY([codPersona])
REFERENCES [dbo].[Persona] ([codPersona])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Administradores] CHECK CONSTRAINT [FK_Administradores_Persona_codPersona]
GO
ALTER TABLE [dbo].[CategoriasPorProducto]  WITH CHECK ADD  CONSTRAINT [FK_CategoriasPorProducto_Categorias_codCategoria] FOREIGN KEY([codCategoria])
REFERENCES [dbo].[Categorias] ([codCategoria])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CategoriasPorProducto] CHECK CONSTRAINT [FK_CategoriasPorProducto_Categorias_codCategoria]
GO
ALTER TABLE [dbo].[CategoriasPorProducto]  WITH CHECK ADD  CONSTRAINT [FK_CategoriasPorProducto_Producto_codProducto] FOREIGN KEY([codProducto])
REFERENCES [dbo].[Producto] ([codProducto])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CategoriasPorProducto] CHECK CONSTRAINT [FK_CategoriasPorProducto_Producto_codProducto]
GO
ALTER TABLE [dbo].[Comentarios]  WITH CHECK ADD  CONSTRAINT [FK_Comentarios_Persona_codPersona] FOREIGN KEY([codPersona])
REFERENCES [dbo].[Persona] ([codPersona])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Comentarios] CHECK CONSTRAINT [FK_Comentarios_Persona_codPersona]
GO
ALTER TABLE [dbo].[Comentarios]  WITH CHECK ADD  CONSTRAINT [FK_Comentarios_Producto_codProducto] FOREIGN KEY([codProducto])
REFERENCES [dbo].[Producto] ([codProducto])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Comentarios] CHECK CONSTRAINT [FK_Comentarios_Producto_codProducto]
GO
ALTER TABLE [dbo].[DetalleOrden]  WITH CHECK ADD  CONSTRAINT [FK_DetalleOrden_Orden_codOrden] FOREIGN KEY([codOrden])
REFERENCES [dbo].[Orden] ([codOrden])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DetalleOrden] CHECK CONSTRAINT [FK_DetalleOrden_Orden_codOrden]
GO
ALTER TABLE [dbo].[DetalleOrden]  WITH CHECK ADD  CONSTRAINT [FK_DetalleOrden_Producto_codProducto] FOREIGN KEY([codProducto])
REFERENCES [dbo].[Producto] ([codProducto])
GO
ALTER TABLE [dbo].[DetalleOrden] CHECK CONSTRAINT [FK_DetalleOrden_Producto_codProducto]
GO
ALTER TABLE [dbo].[DetalleWishlist]  WITH CHECK ADD  CONSTRAINT [FK_DetalleWishlist_Producto_codProducto] FOREIGN KEY([codProducto])
REFERENCES [dbo].[Producto] ([codProducto])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DetalleWishlist] CHECK CONSTRAINT [FK_DetalleWishlist_Producto_codProducto]
GO
ALTER TABLE [dbo].[DetalleWishlist]  WITH CHECK ADD  CONSTRAINT [FK_DetalleWishlist_Wishlist_codWishlist] FOREIGN KEY([codWishlist])
REFERENCES [dbo].[Wishlist] ([codWishlist])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DetalleWishlist] CHECK CONSTRAINT [FK_DetalleWishlist_Wishlist_codWishlist]
GO
ALTER TABLE [dbo].[GuardadoCarrito]  WITH CHECK ADD  CONSTRAINT [FK_GuardadoCarrito_Producto_codProducto] FOREIGN KEY([codProducto])
REFERENCES [dbo].[Producto] ([codProducto])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GuardadoCarrito] CHECK CONSTRAINT [FK_GuardadoCarrito_Producto_codProducto]
GO
ALTER TABLE [dbo].[GuardadoCarrito]  WITH CHECK ADD  CONSTRAINT [FK_GuardadoCarrito_Usuarios_codUsuario] FOREIGN KEY([codUsuario])
REFERENCES [dbo].[Usuarios] ([codUsuario])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GuardadoCarrito] CHECK CONSTRAINT [FK_GuardadoCarrito_Usuarios_codUsuario]
GO
ALTER TABLE [dbo].[GuardadoWishlist]  WITH CHECK ADD  CONSTRAINT [FK_GuardadoWishlist_Producto_codProducto] FOREIGN KEY([codProducto])
REFERENCES [dbo].[Producto] ([codProducto])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GuardadoWishlist] CHECK CONSTRAINT [FK_GuardadoWishlist_Producto_codProducto]
GO
ALTER TABLE [dbo].[GuardadoWishlist]  WITH CHECK ADD  CONSTRAINT [FK_GuardadoWishlist_Usuarios_codUsuario] FOREIGN KEY([codUsuario])
REFERENCES [dbo].[Usuarios] ([codUsuario])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GuardadoWishlist] CHECK CONSTRAINT [FK_GuardadoWishlist_Usuarios_codUsuario]
GO
ALTER TABLE [dbo].[Like]  WITH CHECK ADD  CONSTRAINT [FK_Like_Producto_codProducto] FOREIGN KEY([codProducto])
REFERENCES [dbo].[Producto] ([codProducto])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Like] CHECK CONSTRAINT [FK_Like_Producto_codProducto]
GO
ALTER TABLE [dbo].[Like]  WITH CHECK ADD  CONSTRAINT [FK_Like_Usuarios_codUsuario] FOREIGN KEY([codUsuario])
REFERENCES [dbo].[Usuarios] ([codUsuario])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Like] CHECK CONSTRAINT [FK_Like_Usuarios_codUsuario]
GO
ALTER TABLE [dbo].[ListaEsperaEmpresa]  WITH CHECK ADD  CONSTRAINT [FK_ListaEsperaEmpresa_Administradores_codAdmin] FOREIGN KEY([codAdmin])
REFERENCES [dbo].[Administradores] ([codAdmin])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ListaEsperaEmpresa] CHECK CONSTRAINT [FK_ListaEsperaEmpresa_Administradores_codAdmin]
GO
ALTER TABLE [dbo].[ListaEsperaEmpresa]  WITH CHECK ADD  CONSTRAINT [FK_ListaEsperaEmpresa_Empresa_codEmpresa] FOREIGN KEY([codEmpresa])
REFERENCES [dbo].[Empresa] ([codEmpresa])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ListaEsperaEmpresa] CHECK CONSTRAINT [FK_ListaEsperaEmpresa_Empresa_codEmpresa]
GO
ALTER TABLE [dbo].[LogsAuditoria]  WITH CHECK ADD  CONSTRAINT [FK_LogsAuditoria_Persona_codPersona] FOREIGN KEY([codPersona])
REFERENCES [dbo].[Persona] ([codPersona])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LogsAuditoria] CHECK CONSTRAINT [FK_LogsAuditoria_Persona_codPersona]
GO
ALTER TABLE [dbo].[Orden]  WITH CHECK ADD  CONSTRAINT [FK_Orden_Empresa_codEmpresa] FOREIGN KEY([codEmpresa])
REFERENCES [dbo].[Empresa] ([codEmpresa])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orden] CHECK CONSTRAINT [FK_Orden_Empresa_codEmpresa]
GO
ALTER TABLE [dbo].[Orden]  WITH CHECK ADD  CONSTRAINT [FK_Orden_Usuarios_codUsuario] FOREIGN KEY([codUsuario])
REFERENCES [dbo].[Usuarios] ([codUsuario])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orden] CHECK CONSTRAINT [FK_Orden_Usuarios_codUsuario]
GO
ALTER TABLE [dbo].[PersonalEmpresa]  WITH CHECK ADD  CONSTRAINT [FK_PersonalEmpresa_Empresa_codEmpresa] FOREIGN KEY([codEmpresa])
REFERENCES [dbo].[Empresa] ([codEmpresa])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PersonalEmpresa] CHECK CONSTRAINT [FK_PersonalEmpresa_Empresa_codEmpresa]
GO
ALTER TABLE [dbo].[PersonalEmpresa]  WITH CHECK ADD  CONSTRAINT [FK_PersonalEmpresa_Persona_codPersona] FOREIGN KEY([codPersona])
REFERENCES [dbo].[Persona] ([codPersona])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PersonalEmpresa] CHECK CONSTRAINT [FK_PersonalEmpresa_Persona_codPersona]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Empresa_codEmpresa] FOREIGN KEY([codEmpresa])
REFERENCES [dbo].[Empresa] ([codEmpresa])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Empresa_codEmpresa]
GO
ALTER TABLE [dbo].[ReclamosEmpresa]  WITH CHECK ADD  CONSTRAINT [FK_ReclamosEmpresa_Administradores_codAdmin] FOREIGN KEY([codAdmin])
REFERENCES [dbo].[Administradores] ([codAdmin])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ReclamosEmpresa] CHECK CONSTRAINT [FK_ReclamosEmpresa_Administradores_codAdmin]
GO
ALTER TABLE [dbo].[ReclamosEmpresa]  WITH CHECK ADD  CONSTRAINT [FK_ReclamosEmpresa_Producto_codProducto] FOREIGN KEY([codProducto])
REFERENCES [dbo].[Producto] ([codProducto])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ReclamosEmpresa] CHECK CONSTRAINT [FK_ReclamosEmpresa_Producto_codProducto]
GO
ALTER TABLE [dbo].[ReclamosEmpresa]  WITH CHECK ADD  CONSTRAINT [FK_ReclamosEmpresa_Usuarios_codUsuario] FOREIGN KEY([codUsuario])
REFERENCES [dbo].[Usuarios] ([codUsuario])
GO
ALTER TABLE [dbo].[ReclamosEmpresa] CHECK CONSTRAINT [FK_ReclamosEmpresa_Usuarios_codUsuario]
GO
ALTER TABLE [dbo].[TokenGuardado]  WITH CHECK ADD  CONSTRAINT [FK_TokenGuardado_Persona_codPersona] FOREIGN KEY([codPersona])
REFERENCES [dbo].[Persona] ([codPersona])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TokenGuardado] CHECK CONSTRAINT [FK_TokenGuardado_Persona_codPersona]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Persona_codPersona] FOREIGN KEY([codPersona])
REFERENCES [dbo].[Persona] ([codPersona])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Persona_codPersona]
GO
ALTER TABLE [dbo].[VisitasEmpresa]  WITH CHECK ADD  CONSTRAINT [FK_VisitasEmpresa_Empresa_codEmpresa] FOREIGN KEY([codEmpresa])
REFERENCES [dbo].[Empresa] ([codEmpresa])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[VisitasEmpresa] CHECK CONSTRAINT [FK_VisitasEmpresa_Empresa_codEmpresa]
GO
ALTER TABLE [dbo].[VisitasEmpresa]  WITH CHECK ADD  CONSTRAINT [FK_VisitasEmpresa_Usuarios_codUsuario] FOREIGN KEY([codUsuario])
REFERENCES [dbo].[Usuarios] ([codUsuario])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[VisitasEmpresa] CHECK CONSTRAINT [FK_VisitasEmpresa_Usuarios_codUsuario]
GO
ALTER TABLE [dbo].[Wishlist]  WITH CHECK ADD  CONSTRAINT [FK_Wishlist_Usuarios_codUsuario] FOREIGN KEY([codUsuario])
REFERENCES [dbo].[Usuarios] ([codUsuario])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Wishlist] CHECK CONSTRAINT [FK_Wishlist_Usuarios_codUsuario]
GO
USE [master]
GO
ALTER DATABASE [ProyectoFinal] SET  READ_WRITE 
GO
