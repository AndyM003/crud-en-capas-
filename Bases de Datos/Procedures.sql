CREATE PROC SP_Mostrar
AS
SELECT * FROM Personas
GO

--INSERTAR DATOS--
CREATE PROCEDURE SP_Insertar
@ID INT,
@Nombre NVARCHAR (30),
@Apellido NVARCHAR (30),
@Sexo NVARCHAR (12)
AS
INSERT INTO Personas VALUES (@ID, @Nombre, @Apellido,@Sexo)
GO

--Actualizar Datos
CREATE PROCEDURE SP_Modificar
@ID INT,
@Nombre NVARCHAR (30),
@Apellido NVARCHAR (30),
@Sexo NVARCHAR (12)
AS
UPDATE Personas SET Nombre = @Nombre, Apellido = @Apellido, Sexo = @Sexo
WHERE ID = @ID
GO
 
--DElete
CREATE PROCEDURE SP_Eliminar
@ID INT
AS
DELETE Personas WHERE ID = @ID
GO

---Buscar
CREATE PROCEDURE SP_Buscar
@Buscar NVARCHAR(30)
AS
SELECT * FROM Personas WHERE Nombre LIKE @Buscar + '%'
GO