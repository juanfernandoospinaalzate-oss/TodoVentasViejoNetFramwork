CREATE PROCEDURE [dbo].[MarcaInsert] 	
@Nombre nvarchar(20)
AS
INSERT INTO [dbo].[Marca]([Nombre])VALUES(@Nombre)
GO

CREATE PROCEDURE MarcaSelect
AS
SELECT [IdMarca]
,[Nombre]
FROM [dbo].[Marca] ORDER BY [Nombre] ASC
GO

CREATE PROCEDURE MarcaSelectPorNombre
@Nombre nvarchar(20)
AS
SELECT [IdMarca]
,[Nombre]
FROM [dbo].[Marca] WHERE Nombre = @Nombre 
ORDER BY [Nombre] ASC
GO

CREATE PROCEDURE MarcaSelectOrdenadoPorId
AS
SELECT [IdMarca]
,[Nombre]
FROM [dbo].[Marca] ORDER BY [IdMarca] ASC
GO

CREATE PROCEDURE MarcaSelectPorId
@IdMarca int
AS
SELECT [IdMarca]
,[Nombre]
FROM [dbo].[Marca] WHERE [IdMarca] = @IdMarca
ORDER BY [IdMarca] ASC
GO

CREATE PROCEDURE [dbo].[MarcaUpdate]
(@IdMarca int,
@Nombre nvarchar(20))
AS
UPDATE [dbo].[Marca]
   SET Nombre = @Nombre
 WHERE IdMarca = @IdMarca
 GO

CREATE PROCEDURE [dbo].[MarcaDelete]
@IdMarca int
AS
DELETE FROM [dbo].[Marca]
WHERE IdMarca = @IdMarca
GO

CREATE PROCEDURE MarcaVerificarRelacionArticulo
	@IdMarca INT
AS
IF EXISTS (SELECT TOP 1 1 FROM Articulo where IdMarca = @IdMarca)
	BEGIN
		select 'true'
	END
	ELSE
	BEGIN
		select 'false'
	END
GO