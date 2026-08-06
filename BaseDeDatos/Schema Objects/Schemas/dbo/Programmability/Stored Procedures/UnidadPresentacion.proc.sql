
CREATE PROCEDURE UnidadPresentacionSelect
AS
	SELECT 
		[IdUnidadPresentacion]
		,[Nombre]
	FROM [dbo].[UnidadPresentacion]
	ORDER BY NOMBRE ASC
GO

CREATE PROCEDURE UnidadPresentacionInsert
	@Nombre NVARCHAR(40)
AS
INSERT INTO [UnidadPresentacion] (Nombre)
     VALUES (@Nombre)
GO

CREATE PROCEDURE UnidadPresentacionUpdate
	@IdUnidadPresentacion INT,
	@Nombre NVARCHAR(40)
AS
	UPDATE [UnidadPresentacion]
	SET [Nombre] = @Nombre
	WHERE [IdUnidadPresentacion] = @IdUnidadPresentacion
GO

CREATE PROCEDURE UnidadPresentacionDelete
	@IdUnidadPresentacion INT
AS
	DELETE FROM [UnidadPresentacion]
    WHERE IdUnidadPresentacion = @IdUnidadPresentacion
GO