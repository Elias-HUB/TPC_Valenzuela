USE [master]
GO
/****** Object:  Database [Valenzuela_DB]    Script Date: 19/12/2019 22:27:00 ******/
CREATE DATABASE [Valenzuela_DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Valenzuela_DB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.FRGP_PROG\MSSQL\DATA\Valenzuela_DB.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Valenzuela_DB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.FRGP_PROG\MSSQL\DATA\Valenzuela_DB_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Valenzuela_DB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Valenzuela_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Valenzuela_DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Valenzuela_DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Valenzuela_DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Valenzuela_DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Valenzuela_DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [Valenzuela_DB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Valenzuela_DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Valenzuela_DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Valenzuela_DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Valenzuela_DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Valenzuela_DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Valenzuela_DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Valenzuela_DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Valenzuela_DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Valenzuela_DB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Valenzuela_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Valenzuela_DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Valenzuela_DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Valenzuela_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Valenzuela_DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Valenzuela_DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Valenzuela_DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Valenzuela_DB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Valenzuela_DB] SET  MULTI_USER 
GO
ALTER DATABASE [Valenzuela_DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Valenzuela_DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Valenzuela_DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Valenzuela_DB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Valenzuela_DB] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Valenzuela_DB]
GO
/****** Object:  Table [dbo].[Alumno]    Script Date: 19/12/2019 22:27:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Alumno](
	[Legajo] [bigint] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[Telefono] [int] NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Direccion] [varchar](50) NOT NULL,
	[Ciudad] [varchar](50) NOT NULL,
	[CodigoPostal] [int] NOT NULL,
	[TipoPerfil] [varchar](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[Legajo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Carrera]    Script Date: 19/12/2019 22:27:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Carrera](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[IdUniversidad] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Comentario]    Script Date: 19/12/2019 22:27:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Comentario](
	[idComision] [bigint] NOT NULL,
	[IdInstancia] [bigint] NOT NULL,
	[IdAlumno] [bigint] NOT NULL,
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](350) NOT NULL,
	[FechaAlta] [datetime] NOT NULL,
	[FechaModificacion] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Comision]    Script Date: 19/12/2019 22:27:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comision](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdMateria] [bigint] NOT NULL,
	[IdTurno] [bigint] NOT NULL,
	[IdCuatrimestre] [bigint] NOT NULL,
	[IdDocente] [bigint] NOT NULL,
	[Anio] [int] NOT NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Cuatrimestre]    Script Date: 19/12/2019 22:27:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cuatrimestre](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DetComisionAlumnos]    Script Date: 19/12/2019 22:27:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetComisionAlumnos](
	[idComision] [bigint] NOT NULL,
	[IdAlumno] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idComision] ASC,
	[IdAlumno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DetComisionInstancia]    Script Date: 19/12/2019 22:27:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetComisionInstancia](
	[idComision] [bigint] NOT NULL,
	[IdInstancia] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idComision] ASC,
	[IdInstancia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Docente]    Script Date: 19/12/2019 22:27:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Docente](
	[Legajo] [bigint] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[Telefono] [int] NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Direccion] [varchar](50) NOT NULL,
	[Ciudad] [varchar](50) NOT NULL,
	[CodigoPostal] [int] NOT NULL,
	[TipoPerfil] [varchar](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[Legajo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Instancia]    Script Date: 19/12/2019 22:27:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Instancia](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[FechaInicio] [datetime] NOT NULL,
	[FechaFin] [datetime] NOT NULL,
	[Estado] [bit] NULL,
	[IdTipoinstancia] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Materia]    Script Date: 19/12/2019 22:27:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Materia](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[IdCarrera] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoInstancia]    Script Date: 19/12/2019 22:27:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoInstancia](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Turno]    Script Date: 19/12/2019 22:27:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Turno](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Universidad]    Script Date: 19/12/2019 22:27:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Universidad](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 19/12/2019 22:27:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[LegajoDocente] [bigint] NOT NULL,
	[Clave] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Alumno] ([Legajo], [Nombre], [Apellido], [Telefono], [Email], [Direccion], [Ciudad], [CodigoPostal], [TipoPerfil]) VALUES (22012, N'Elias', N'Valenzuela', 1157490469, N'Elias_valenzuela51@yahoo.com.ar', N'Fagnano 2781', N'Talar', 1716, NULL)
INSERT [dbo].[Alumno] ([Legajo], [Nombre], [Apellido], [Telefono], [Email], [Direccion], [Ciudad], [CodigoPostal], [TipoPerfil]) VALUES (22013, N'Agustin', N'Suarez', 1154590470, N'Eliasvalenzuela953@gmail.com', N'Fagnano 2781', N'Talar', 1716, NULL)
INSERT [dbo].[Alumno] ([Legajo], [Nombre], [Apellido], [Telefono], [Email], [Direccion], [Ciudad], [CodigoPostal], [TipoPerfil]) VALUES (22014, N'Chewbacca', N'(?', 1154590470, N'Prueba953@gmail.com', N'Fagnano 2781', N'Talar', 1716, NULL)
INSERT [dbo].[Alumno] ([Legajo], [Nombre], [Apellido], [Telefono], [Email], [Direccion], [Ciudad], [CodigoPostal], [TipoPerfil]) VALUES (22015, N'Luke', N'Skywalker', 1154590470, N'Prueba953@gmail.com', N'Fagnano 2781', N'Talar', 1716, NULL)
INSERT [dbo].[Alumno] ([Legajo], [Nombre], [Apellido], [Telefono], [Email], [Direccion], [Ciudad], [CodigoPostal], [TipoPerfil]) VALUES (22016, N'Darth', N'Vader', 1154590470, N'msarfernandez@docentes.frgp.utn.edu.ar', N'Fagnano 2781', N'Talar', 1716, NULL)
INSERT [dbo].[Alumno] ([Legajo], [Nombre], [Apellido], [Telefono], [Email], [Direccion], [Ciudad], [CodigoPostal], [TipoPerfil]) VALUES (12312312, N'Elias', N'agasd', 1157491111, N'mail@yahoo.com.ar', N'Fagnano 2781', N'san isidro', 1713, NULL)
SET IDENTITY_INSERT [dbo].[Carrera] ON 

INSERT [dbo].[Carrera] ([Id], [Nombre], [IdUniversidad]) VALUES (1, N'Tecnicatura Universitaria en Programacion', 1)
INSERT [dbo].[Carrera] ([Id], [Nombre], [IdUniversidad]) VALUES (2, N'Ingenieria en Sistema', 1)
INSERT [dbo].[Carrera] ([Id], [Nombre], [IdUniversidad]) VALUES (3, N'Tecnicatura Unicersitaria en sistemas', 1)
SET IDENTITY_INSERT [dbo].[Carrera] OFF
SET IDENTITY_INSERT [dbo].[Comentario] ON 

INSERT [dbo].[Comentario] ([idComision], [IdInstancia], [IdAlumno], [Id], [Descripcion], [FechaAlta], [FechaModificacion]) VALUES (3, 1, 22012, 1, N'Le fue bien', CAST(N'2019-04-04 00:00:00.000' AS DateTime), CAST(N'2019-04-10 00:00:00.000' AS DateTime))
INSERT [dbo].[Comentario] ([idComision], [IdInstancia], [IdAlumno], [Id], [Descripcion], [FechaAlta], [FechaModificacion]) VALUES (3, 1, 22012, 2, N'Le Falto que envie mail', CAST(N'2019-04-04 00:00:00.000' AS DateTime), CAST(N'2019-04-10 00:00:00.000' AS DateTime))
INSERT [dbo].[Comentario] ([idComision], [IdInstancia], [IdAlumno], [Id], [Descripcion], [FechaAlta], [FechaModificacion]) VALUES (3, 1, 22012, 3, N'Le Falto que envie mail', CAST(N'2019-04-04 00:00:00.000' AS DateTime), CAST(N'2019-04-10 00:00:00.000' AS DateTime))
INSERT [dbo].[Comentario] ([idComision], [IdInstancia], [IdAlumno], [Id], [Descripcion], [FechaAlta], [FechaModificacion]) VALUES (2, 1, 22012, 4, N'Le Falto que envie mail', CAST(N'2019-04-04 00:00:00.000' AS DateTime), CAST(N'2019-04-10 00:00:00.000' AS DateTime))
INSERT [dbo].[Comentario] ([idComision], [IdInstancia], [IdAlumno], [Id], [Descripcion], [FechaAlta], [FechaModificacion]) VALUES (2, 1, 22012, 5, N'gdfgdfgd', CAST(N'2019-12-19 12:21:54.120' AS DateTime), CAST(N'2019-12-19 12:21:54.120' AS DateTime))
SET IDENTITY_INSERT [dbo].[Comentario] OFF
SET IDENTITY_INSERT [dbo].[Comision] ON 

INSERT [dbo].[Comision] ([Id], [IdMateria], [IdTurno], [IdCuatrimestre], [IdDocente], [Anio], [Estado]) VALUES (1, 3, 1, 1, 1, 2019, NULL)
INSERT [dbo].[Comision] ([Id], [IdMateria], [IdTurno], [IdCuatrimestre], [IdDocente], [Anio], [Estado]) VALUES (2, 1, 1, 2, 2, 2020, NULL)
INSERT [dbo].[Comision] ([Id], [IdMateria], [IdTurno], [IdCuatrimestre], [IdDocente], [Anio], [Estado]) VALUES (3, 2, 2, 2, 2, 2020, NULL)
INSERT [dbo].[Comision] ([Id], [IdMateria], [IdTurno], [IdCuatrimestre], [IdDocente], [Anio], [Estado]) VALUES (4, 1, 2, 2, 2, 2019, NULL)
INSERT [dbo].[Comision] ([Id], [IdMateria], [IdTurno], [IdCuatrimestre], [IdDocente], [Anio], [Estado]) VALUES (5, 2, 2, 1, 2, 2019, NULL)
INSERT [dbo].[Comision] ([Id], [IdMateria], [IdTurno], [IdCuatrimestre], [IdDocente], [Anio], [Estado]) VALUES (6, 2, 1, 1, 2, 2019, NULL)
SET IDENTITY_INSERT [dbo].[Comision] OFF
SET IDENTITY_INSERT [dbo].[Cuatrimestre] ON 

INSERT [dbo].[Cuatrimestre] ([Id], [Nombre]) VALUES (1, N'1º Cuatrimestre')
INSERT [dbo].[Cuatrimestre] ([Id], [Nombre]) VALUES (2, N'2º Cuatrimestre')
SET IDENTITY_INSERT [dbo].[Cuatrimestre] OFF
INSERT [dbo].[DetComisionAlumnos] ([idComision], [IdAlumno]) VALUES (1, 22012)
INSERT [dbo].[DetComisionAlumnos] ([idComision], [IdAlumno]) VALUES (2, 22012)
INSERT [dbo].[DetComisionAlumnos] ([idComision], [IdAlumno]) VALUES (2, 22013)
INSERT [dbo].[DetComisionAlumnos] ([idComision], [IdAlumno]) VALUES (2, 22014)
INSERT [dbo].[DetComisionAlumnos] ([idComision], [IdAlumno]) VALUES (2, 22015)
INSERT [dbo].[DetComisionAlumnos] ([idComision], [IdAlumno]) VALUES (2, 22016)
INSERT [dbo].[DetComisionAlumnos] ([idComision], [IdAlumno]) VALUES (2, 12312312)
INSERT [dbo].[DetComisionAlumnos] ([idComision], [IdAlumno]) VALUES (3, 22012)
INSERT [dbo].[DetComisionAlumnos] ([idComision], [IdAlumno]) VALUES (3, 22013)
INSERT [dbo].[DetComisionAlumnos] ([idComision], [IdAlumno]) VALUES (3, 22014)
INSERT [dbo].[DetComisionAlumnos] ([idComision], [IdAlumno]) VALUES (3, 22015)
INSERT [dbo].[DetComisionAlumnos] ([idComision], [IdAlumno]) VALUES (3, 22016)
INSERT [dbo].[DetComisionInstancia] ([idComision], [IdInstancia]) VALUES (2, 1)
INSERT [dbo].[DetComisionInstancia] ([idComision], [IdInstancia]) VALUES (2, 2)
INSERT [dbo].[DetComisionInstancia] ([idComision], [IdInstancia]) VALUES (2, 3)
INSERT [dbo].[DetComisionInstancia] ([idComision], [IdInstancia]) VALUES (3, 1)
INSERT [dbo].[DetComisionInstancia] ([idComision], [IdInstancia]) VALUES (3, 2)
INSERT [dbo].[DetComisionInstancia] ([idComision], [IdInstancia]) VALUES (3, 3)
INSERT [dbo].[Docente] ([Legajo], [Nombre], [Apellido], [Telefono], [Email], [Direccion], [Ciudad], [CodigoPostal], [TipoPerfil]) VALUES (1, N'Angel', N'Simon', 1157450480, N'asimon@docentes.frgp.utn.edu.ar', N'avenida siempre viva 742', N'Talar', 1716, NULL)
INSERT [dbo].[Docente] ([Legajo], [Nombre], [Apellido], [Telefono], [Email], [Direccion], [Ciudad], [CodigoPostal], [TipoPerfil]) VALUES (2, N'Maxi', N'Fernandez', 1154590470, N'msarfernandez@docentes.frgp.utn.edu.ar', N'República Galáctica', N'Talar', 1716, NULL)
SET IDENTITY_INSERT [dbo].[Instancia] ON 

INSERT [dbo].[Instancia] ([Id], [Nombre], [FechaInicio], [FechaFin], [Estado], [IdTipoinstancia]) VALUES (1, N'ABC', CAST(N'2019-04-05 00:00:00.000' AS DateTime), CAST(N'2019-04-05 01:00:00.000' AS DateTime), NULL, 2)
INSERT [dbo].[Instancia] ([Id], [Nombre], [FechaInicio], [FechaFin], [Estado], [IdTipoinstancia]) VALUES (2, N'Recuperatorio', CAST(N'2019-04-05 00:00:00.000' AS DateTime), CAST(N'2019-04-05 00:00:00.000' AS DateTime), NULL, 2)
INSERT [dbo].[Instancia] ([Id], [Nombre], [FechaInicio], [FechaFin], [Estado], [IdTipoinstancia]) VALUES (3, N'Tp1', CAST(N'2019-04-05 00:00:00.000' AS DateTime), CAST(N'2019-04-05 00:00:00.000' AS DateTime), NULL, 1)
INSERT [dbo].[Instancia] ([Id], [Nombre], [FechaInicio], [FechaFin], [Estado], [IdTipoinstancia]) VALUES (4, N'TPC', CAST(N'2019-04-05 00:00:00.000' AS DateTime), CAST(N'2019-04-05 00:00:00.000' AS DateTime), NULL, 4)
INSERT [dbo].[Instancia] ([Id], [Nombre], [FechaInicio], [FechaFin], [Estado], [IdTipoinstancia]) VALUES (5, N'uty', CAST(N'2019-12-12 00:00:00.000' AS DateTime), CAST(N'2019-12-14 00:00:00.000' AS DateTime), NULL, 1)
INSERT [dbo].[Instancia] ([Id], [Nombre], [FechaInicio], [FechaFin], [Estado], [IdTipoinstancia]) VALUES (6, N'gfd', CAST(N'2019-12-26 04:00:00.000' AS DateTime), CAST(N'2019-12-27 04:00:00.000' AS DateTime), NULL, 1)
SET IDENTITY_INSERT [dbo].[Instancia] OFF
SET IDENTITY_INSERT [dbo].[Materia] ON 

INSERT [dbo].[Materia] ([Id], [Nombre], [IdCarrera]) VALUES (1, N'Programacion III', 1)
INSERT [dbo].[Materia] ([Id], [Nombre], [IdCarrera]) VALUES (2, N'Programacion I', 1)
INSERT [dbo].[Materia] ([Id], [Nombre], [IdCarrera]) VALUES (3, N'Laboratorio I', 1)
INSERT [dbo].[Materia] ([Id], [Nombre], [IdCarrera]) VALUES (4, N'Laboratorio III', 1)
SET IDENTITY_INSERT [dbo].[Materia] OFF
SET IDENTITY_INSERT [dbo].[TipoInstancia] ON 

INSERT [dbo].[TipoInstancia] ([Id], [Nombre]) VALUES (1, N'Trabajo Practico')
INSERT [dbo].[TipoInstancia] ([Id], [Nombre]) VALUES (2, N'Parcial')
INSERT [dbo].[TipoInstancia] ([Id], [Nombre]) VALUES (3, N'Final')
INSERT [dbo].[TipoInstancia] ([Id], [Nombre]) VALUES (4, N'Trabajo Practico Cuatrimestral')
SET IDENTITY_INSERT [dbo].[TipoInstancia] OFF
SET IDENTITY_INSERT [dbo].[Turno] ON 

INSERT [dbo].[Turno] ([Id], [Nombre]) VALUES (1, N'Mañana')
INSERT [dbo].[Turno] ([Id], [Nombre]) VALUES (2, N'Tarde')
INSERT [dbo].[Turno] ([Id], [Nombre]) VALUES (3, N'Noche')
SET IDENTITY_INSERT [dbo].[Turno] OFF
SET IDENTITY_INSERT [dbo].[Universidad] ON 

INSERT [dbo].[Universidad] ([Id], [Nombre]) VALUES (1, N'Universidad Tecnológica Nacional')
INSERT [dbo].[Universidad] ([Id], [Nombre]) VALUES (2, N'Universidad de Buenos Aires')
INSERT [dbo].[Universidad] ([Id], [Nombre]) VALUES (3, N'Universidad Nacional de La Plata')
SET IDENTITY_INSERT [dbo].[Universidad] OFF
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([Id], [LegajoDocente], [Clave]) VALUES (1, 2, N'1234')
INSERT [dbo].[Usuario] ([Id], [LegajoDocente], [Clave]) VALUES (2, 1, N'1234')
SET IDENTITY_INSERT [dbo].[Usuario] OFF
/****** Object:  Index [UQ__Comision__037ED2C2C68D1F2A]    Script Date: 19/12/2019 22:27:01 ******/
ALTER TABLE [dbo].[Comision] ADD UNIQUE NONCLUSTERED 
(
	[IdMateria] ASC,
	[IdTurno] ASC,
	[IdCuatrimestre] ASC,
	[IdDocente] ASC,
	[Anio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Carrera]  WITH CHECK ADD FOREIGN KEY([IdUniversidad])
REFERENCES [dbo].[Universidad] ([Id])
GO
ALTER TABLE [dbo].[Comentario]  WITH CHECK ADD FOREIGN KEY([IdAlumno])
REFERENCES [dbo].[Alumno] ([Legajo])
GO
ALTER TABLE [dbo].[Comentario]  WITH CHECK ADD FOREIGN KEY([idComision])
REFERENCES [dbo].[Comision] ([Id])
GO
ALTER TABLE [dbo].[Comentario]  WITH CHECK ADD FOREIGN KEY([IdInstancia])
REFERENCES [dbo].[Instancia] ([Id])
GO
ALTER TABLE [dbo].[Comision]  WITH CHECK ADD FOREIGN KEY([IdCuatrimestre])
REFERENCES [dbo].[Cuatrimestre] ([Id])
GO
ALTER TABLE [dbo].[Comision]  WITH CHECK ADD FOREIGN KEY([IdDocente])
REFERENCES [dbo].[Docente] ([Legajo])
GO
ALTER TABLE [dbo].[Comision]  WITH CHECK ADD FOREIGN KEY([IdMateria])
REFERENCES [dbo].[Materia] ([Id])
GO
ALTER TABLE [dbo].[Comision]  WITH CHECK ADD FOREIGN KEY([IdTurno])
REFERENCES [dbo].[Turno] ([Id])
GO
ALTER TABLE [dbo].[DetComisionAlumnos]  WITH CHECK ADD FOREIGN KEY([IdAlumno])
REFERENCES [dbo].[Alumno] ([Legajo])
GO
ALTER TABLE [dbo].[DetComisionAlumnos]  WITH CHECK ADD FOREIGN KEY([idComision])
REFERENCES [dbo].[Comision] ([Id])
GO
ALTER TABLE [dbo].[DetComisionInstancia]  WITH CHECK ADD FOREIGN KEY([idComision])
REFERENCES [dbo].[Comision] ([Id])
GO
ALTER TABLE [dbo].[DetComisionInstancia]  WITH CHECK ADD FOREIGN KEY([IdInstancia])
REFERENCES [dbo].[Instancia] ([Id])
GO
ALTER TABLE [dbo].[Instancia]  WITH CHECK ADD FOREIGN KEY([IdTipoinstancia])
REFERENCES [dbo].[TipoInstancia] ([Id])
GO
ALTER TABLE [dbo].[Materia]  WITH CHECK ADD FOREIGN KEY([IdCarrera])
REFERENCES [dbo].[Carrera] ([Id])
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD FOREIGN KEY([LegajoDocente])
REFERENCES [dbo].[Docente] ([Legajo])
GO
/****** Object:  StoredProcedure [dbo].[PR_ComiAlumnos]    Script Date: 19/12/2019 22:27:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[PR_ComiAlumnos] 
(@IdCom bigint , @Legajo Bigint, @Nombre Varchar(50), @Apellido Varchar(50)) 
AS
begin
SELECT Comision.Id, Alumno.* 
	FROM [Valenzuela_DB].[dbo].[DetComisionAlumnos] 
		inner join Comision on Comision.Id = DetComisionAlumnos.idComision 
		inner join Alumno on Alumno.Legajo = DetComisionAlumnos.IdAlumno 
where Comision.Id = @IdCom and Alumno.Legajo like @Legajo 
	  and Alumno.Nombre like @Nombre and Alumno.Apellido like @Apellido
end
GO
/****** Object:  StoredProcedure [dbo].[PRComiAlumnos]    Script Date: 19/12/2019 22:27:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[PRComiAlumnos] 
(@IdCom bigint , @Legajo Bigint, @Nombre Varchar(50), @Apellido Varchar(50)) 
AS
begin
SELECT Comision.Id, Alumno.* 
	FROM [Valenzuela_DB].[dbo].[DetComisionAlumnos] 
		inner join Comision on Comision.Id = DetComisionAlumnos.idComision 
		inner join Alumno on Alumno.Legajo = DetComisionAlumnos.IdAlumno 
where Comision.Id = @IdCom and Alumno.Legajo like @Legajo 
	  and Alumno.Nombre like @Nombre and Alumno.Apellido like @Apellido
end
GO
/****** Object:  StoredProcedure [dbo].[sp_ComiAlumnos]    Script Date: 19/12/2019 22:27:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_ComiAlumnos] 
(@IdCom bigint , @Legajo Varchar(50), @Nombre Varchar(50), @Apellido Varchar(50)) 
AS
begin
SELECT Comision.Id, Alumno.* 
	FROM [Valenzuela_DB].[dbo].[DetComisionAlumnos] 
		inner join Comision on Comision.Id = DetComisionAlumnos.idComision 
		inner join Alumno on Alumno.Legajo = DetComisionAlumnos.IdAlumno 
where Comision.Id = @IdCom and Alumno.Legajo like @Legajo 
	  and Alumno.Nombre like @Nombre and Alumno.Apellido like @Apellido
end
GO
USE [master]
GO
ALTER DATABASE [Valenzuela_DB] SET  READ_WRITE 
GO
