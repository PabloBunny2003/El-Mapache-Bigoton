CREATE DATABASE BarberiaBD;
GO
USE BarberiaBD;

CREATE TABLE Citas (
    Id INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(50),
    Apellido NVARCHAR(50),
    Telefono NVARCHAR(15),
    Servicio NVARCHAR(50),
    Fecha DATETIME,
	Hora NVARCHAR (20)
);