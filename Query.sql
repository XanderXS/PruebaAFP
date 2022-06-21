use master

CREATE DATABASE Hospital

use Hospital


--TABLAS-----------------------------------------------------------------------------------------------------
CREATE TABLE Paciente(
	PacienteID int identity(1,1),
	Nombre varchar(100),

	Primary key(PacienteID)
)

CREATE TABLE TipoDotor(
	TipoID int identity(1,1),
	TipoNombre varchar(50),
	TipoDescripcion varchar(150)

	Primary key(TipoID)
)

CREATE TABLE Doctor(
	DoctorID int identity(1,1),
	Nombre varchar(100),
	TipoID int

	Primary key(DoctorID)
	Foreign key(TipoID) references TipoDotor(TipoID)
)

CREATE TABLE Cita(
	CitaID int identity(1,1),
	DoctorID int,
	PacienteID int,
	FechaHora datetime

	Primary key(CitaID)
	Foreign key(DoctorID) references Doctor(DoctorID),
	Foreign key(PacienteID) references Paciente(PacienteID)
)

CREATE TABLE Diagnostico(
	DiagnosticoID int identity(1,1),
	CitaID int,
	Resumen varchar(200)

	Primary key(DiagnosticoID)
	Foreign key(CitaID) references Cita(CitaID)
)

--SP-----------------------------------------------------------------------------------------
--PACIENTES
CREATE PROCEDURE SP_LISTA_PACIENTES
AS  
SELECT * FROM Paciente 


CREATE PROCEDURE SP_ELIMINAR_PACIENTE @ID  int
AS
delete from Paciente where PacienteID = @ID;


CREATE PROCEDURE SP_GUARDAR_PACIENTE @Nombre varchar(100)
AS
INSERT INTO Paciente(Nombre) VALUES(@Nombre) ;


CREATE PROCEDURE SP_MODIFICAR_PACIENTE @ID int, @Nombre varchar(100)
AS
UPDATE Paciente SET Nombre = @Nombre where PacienteID = @ID;


CREATE PROCEDURE SP_GET_PACIENTE @ID int
AS
SELECT * FROM Paciente WHERE PacienteID = @ID;


--DOCTORES
CREATE PROCEDURE SP_LISTA_DOCTORES
AS
SELECT * FROM Doctor


CREATE PROCEDURE SP_ELIMINAR_DOCTOR @ID int
AS
delete from Doctor where DoctorID = @ID


CREATE PROCEDURE SP_GUARDAR_DOCTOR @Nombre varchar(100), @TipoID int
AS
INSERT INTO Doctor(Nombre, TipoID) VALUES(@Nombre, @TipoID) ;


CREATE PROCEDURE SP_GET_DOCTOR @ID int
AS
SELECT * FROM Doctor WHERE DoctorID = @ID


CREATE PROCEDURE SP_UPDATE_DOCTOR @ID int, @Nombre varchar(100), @TipoID int
AS
UPDATE Doctor SET Nombre = @Nombre, TipoID= @TipoID where DoctorID = @ID


--CITAS
CREATE PROCEDURE SP_LISTA_CITAS
AS
SELECT * FROM Cita;


CREATE PROCEDURE SP_ELIMINAR_CITA @ID int
AS
delete from Cita where CitaID = @ID


CREATE PROCEDURE SP_GUARDAR_CITA @PacienteID int, @DoctorID int, @FechaHora datetime
AS
INSERT INTO Cita(PacienteID, DoctorID, FechaHora) VALUES(@PacienteID, @DoctorID, @FechaHora)


--DIAGNOSTICO
CREATE PROCEDURE SP_LISTA_GIAGNOSTICOS
AS
SELECT * FROM Diagnostico;


CREATE PROCEDURE SP_ELIMINAR_DIAGNOSTICO @ID int
AS
delete from Diagnostico where DiagnosticoID = @ID;


CREATE PROCEDURE SP_GUARDAR_DIAGNOSTICO @CitaID int, @Resumen varchar(200)
AS
INSERT INTO Diagnostico(CitaID, Resumen) VALUES(@CitaID, @Resumen);


--TipoDoctor

CREATE PROCEDURE SP_LISTA_TIPO_DOCTOR
AS
SELECT * FROM TipoDotor;


CREATE PROCEDURE SP_ELIMINAR_TIPO_DOCTOR @ID int
AS
delete from TipoDotor where TipoID = @ID;


CREATE PROCEDURE SP_GUARDAR_TIPO_DOCTOR @TipoNombre varchar(50), @TipoDescripcion varchar(150)
AS
INSERT INTO TipoDotor(TipoNombre, TipoDescripcion) VALUES(@TipoNombre, @TipoDescripcion);
