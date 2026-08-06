CREATE PROCEDURE UnidadVolumenInsert 	
@Nombre nvarchar(40)
AS
INSERT INTO [dbo].[UnidadVolumen]([Nombre])VALUES(@Nombre)
GO

CREATE PROCEDURE UnidadVolumenDelete
@IdUnidadVolumen int
AS
DELETE FROM [dbo].[UnidadVolumen]
WHERE IdUnidadVolumen = @IdUnidadVolumen
GO

CREATE PROCEDURE UnidadVolumenUpdate
(@IdUnidadVolumen int,
@Nombre nvarchar(40))
AS
UPDATE [dbo].[UnidadVolumen]
   SET Nombre = @Nombre
 WHERE IdUnidadVolumen = @IdUnidadVolumen
 GO

CREATE PROCEDURE UnidadVolumenSelect
AS
SELECT IdUnidadVolumen
,Nombre
FROM [dbo].[UnidadVolumen]
GO

CREATE PROCEDURE UnidadVolumenVerificarDuplicidad
@IdUnidadVolumen int,
@Nombre nvarchar(40)
AS
SELECT TOP 1 IdUnidadVolumen FROM [dbo].[UnidadVolumen] 
WHERE [dbo].[UnidadVolumen].IdUnidadVolumen <> @IdUnidadVolumen AND [dbo].[UnidadVolumen].Nombre=@Nombre
GO

CREATE PROCEDURE UnidadVolumenVerificarRelacionArticulo
@IdUnidadVolumen int
AS
SELECT TOP 1 [IdUnidadVolumen] FROM  [dbo].[PresentacionArticulo]
WHERE [dbo].[PresentacionArticulo].IdUnidadVolumen = @IdUnidadVolumen
GO