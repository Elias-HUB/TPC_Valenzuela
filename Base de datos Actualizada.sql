Create database Valenzuela_DB
go
Use Valenzuela_DB
go

CREATE TABLE Universidad(
Id bigINT NOT NULL PRIMARY KEY IDENTITY (1,1),
Nombre VARCHAR (50) NOT NULL,
)
go

insert into Universidad (Nombre)
values ('Universidad Tecnológica Nacional'),('Universidad de Buenos Aires'),('Universidad Nacional de La Plata')
go

CREATE TABLE Turno(
Id bigINT NOT NULL PRIMARY KEY IDENTITY (1,1),
Nombre VARCHAR (50) NOT NULL,
)
go

insert into Turno (Nombre)
values ('Mañana'),('Tarde'),('Noche')
go

CREATE TABLE TipoInstancia(
Id bigINT NOT NULL PRIMARY KEY IDENTITY (1,1),
Nombre VARCHAR (50) NOT NULL,
)
go

insert into TipoInstancia (Nombre)
values ('Trabajo Practico'),('Parcial'),('Final'),('Trabajo Practico Cuatrimestral')
go

CREATE TABLE Cuatrimestre(
Id bigINT NOT NULL PRIMARY KEY IDENTITY (1,1),
Nombre VARCHAR (50) NOT NULL,
)
go

insert into Cuatrimestre (Nombre)
values ('Primer Cuatrimestre'),('Segundo Cuatrimestre')
go

CREATE TABLE Carrera(
Id bigINT NOT NULL PRIMARY KEY IDENTITY (1,1),
Nombre VARCHAR (50) NOT NULL,
IdUniversidad bigINT NOT NULL FOREIGN KEY REFERENCES Universidad(Id)
)
go

insert into Carrera (Nombre,IdUniversidad)
values ('Tecnicatura Superior en Programacion',1),('Ingenieria en Sistema',1)
go

CREATE TABLE Materia(
Id bigINT NOT NULL PRIMARY KEY IDENTITY (1,1),
Nombre VARCHAR (50) NOT NULL,
IdCarrera bigINT NOT NULL FOREIGN KEY REFERENCES Carrera(Id)
)
go

insert into Materia (Nombre,IdCarrera)
values ('Programacion III',1),('Programacion I',1)
go

CREATE TABLE Alumno(
Legajo bigINT NOT NULL PRIMARY KEY IDENTITY (1,1),
Nombre VARCHAR (50) NOT NULL,
Apellido VARCHAR (50) NOT NULL,
Telefono int NOT NULL,
Email VARCHAR (50) NOT NULL,
Direccion VARCHAR (50) NOT NULL,
Ciudad VARCHAR (50) NOT NULL,
CodigoPostal int NOT NULL,
TipoPerfil varchar (1)
)
go
insert into Alumno (Nombre,Apellido,Telefono,Email,Direccion,Ciudad,CodigoPostal)
values ('Elias','Valenzuela',1157490469,'Elias_valenzuela51@yahoo.com.ar','Fagnano 2781','Talar',1716),
	   ('Agustin','Suarez',1154590470,'Eliasvalenzuela953@gmail.com','Fagnano 2781','Talar',1716)
go

CREATE TABLE Docente(
Legajo bigINT NOT NULL PRIMARY KEY IDENTITY (1,1),
Nombre VARCHAR (50) NOT NULL,
Apellido VARCHAR (50) NOT NULL,
Telefono int NOT NULL,
Email VARCHAR (50) NOT NULL,
Direccion VARCHAR (50) NOT NULL,
Ciudad VARCHAR (50) NOT NULL,
CodigoPostal int NOT NULL,
TipoPerfil varchar (1)
)
go
insert into Docente (Nombre,Apellido,Telefono,Email,Direccion,Ciudad,CodigoPostal)
values ('Angel','Simon',1157450480,'asimon@docentes.frgp.utn.edu.ar','avenida siempre viva 742','Talar',1716),
	   ('Maxi','Fernandez',1154590470,'msarfernandez@docentes.frgp.utn.edu.ar','República Galáctica','Talar',1716)
go

CREATE TABLE Comision(
Id bigINT NOT NULL PRIMARY KEY IDENTITY (1,1),
IdMateria bigINT NOT NULL FOREIGN KEY REFERENCES Materia(Id),
IdTurno bigINT NOT NULL FOREIGN KEY REFERENCES Turno(Id),
IdCuatrimestre bigINT NOT NULL FOREIGN KEY REFERENCES Cuatrimestre(Id),
--IdDetComisionAlumnos bigINT NOT NULL FOREIGN KEY REFERENCES DetComisionAlumnos(Codigo),
--IdDetComisionInstancia bigINT NOT NULL FOREIGN KEY REFERENCES DetComisionInstancia(Codigo),
IdDocente bigINT NOT NULL FOREIGN KEY REFERENCES Docente(Legajo),
Anio int not null,
Estado bit 
)
go
insert into Comision (IdMateria,IdTurno,IdCuatrimestre,IdDocente,Anio)
values (1,1,1,1,2019),
	   (2,2,2,2,2019),
	   (2,2,2,2,2019)
go


CREATE TABLE DetComisionAlumnos(
idComision bigINT NOT NULL FOREIGN KEY REFERENCES Comision(Id),
IdAlumno bigINT NOT NULL FOREIGN KEY REFERENCES Alumno(Legajo),
PRIMARY KEY (idComision, IdAlumno)
)
go
insert into DetComisionAlumnos (idComision,IdAlumno)
values (1,1),
	   (1,2),
	   (2,2)
go

CREATE TABLE Instancia(
Id bigINT NOT NULL PRIMARY KEY IDENTITY (1,1),
Nombre VARCHAR (50) NOT NULL,
FechaInicio datetime not null,
FechaFin datetime not null,
Estado bit ,
IdTipoinstancia bigINT NOT NULL FOREIGN KEY REFERENCES Tipoinstancia(Id),
)
go
insert into Instancia (Nombre,FechaInicio,FechaFin,IdTipoinstancia)
values ('Parcialito','2019-04-05','2019-04-05',1),
	   ('Parcialito 2','2019-04-05','2019-04-05',1)
go


CREATE TABLE DetComisionInstancia(
idComision bigINT NOT NULL FOREIGN KEY REFERENCES Comision(Id),
IdInstancia bigINT NOT NULL FOREIGN KEY REFERENCES Instancia(Id),
PRIMARY KEY (idComision, IdInstancia)
)
go
insert into DetComisionInstancia (idComision,IdInstancia)
values (1,1),
	   (1,2)
go


--CREATE TABLE DetInstanciaAlumno(
--Codigo bigINT NOT NULL,
--IdInstancia bigINT NOT NULL FOREIGN KEY REFERENCES Instancia(ID),
--idComision bigINT NOT NULL FOREIGN KEY REFERENCES Comision(Id),
--IdAlumno bigINT NOT NULL FOREIGN KEY REFERENCES Alumno(Legajo),
--PRIMARY KEY (IdInstancia,IdAlumno,idComision)
--)
--go

CREATE TABLE Comentario(
idComision bigINT NOT NULL FOREIGN KEY REFERENCES Comision(Id),
IdInstancia bigINT NOT NULL FOREIGN KEY REFERENCES Instancia(Id),
IdAlumno bigINT NOT NULL FOREIGN KEY REFERENCES Alumno(Legajo),
Id bigINT NOT NULL PRIMARY KEY IDENTITY (1,1),
Descripcion VARCHAR (350) NOT NULL,
FechaAlta datetime not null,
FechaModificacion datetime not null,
unique (IdInstancia,idComision,IdAlumno)
)
go
insert into Comentario (idComision,IdInstancia,IdAlumno,Descripcion,FechaAlta,FechaModificacion)
values (1,1,1,'Le fue bien','2019-04-04','2019-04-10'),
	   (1,2,1,'Le Falto que envie mail','2019-04-04','2019-04-10')
go

--calificacion

--nota
--instancia
--0 10
--binario