CREATE PROCEDURE UnidadMasaInsert 	
@Nombre nvarchar(20)
AS
INSERT INTO [dbo].[UnidadMasa]([Nombre])VALUES(@Nombre)
GO

CREATE PROCEDURE UnidadMasaSelect
AS
SELECT IdUnidadMasa
,Nombre
FROM [dbo].[UnidadMasa]
GO

CREATE PROCEDURE UnidadMasaUpdate
(@IdUnidadMasa int,
@Nombre nvarchar(20))
AS
UPDATE [dbo].[UnidadMasa]
   SET Nombre = @Nombre
 WHERE IdUnidadMasa = @IdUnidadMasa
 GO

CREATE PROCEDURE UnidadMasaDelete
@IdUnidadMasa int
AS
DELETE FROM [dbo].[UnidadMasa]
WHERE IdUnidadMasa = @IdUnidadMasa
GO

CREATE PROCEDURE UnidadMasaVerificarDuplicidad
@IdUnidadMasa int,
@Nombre nvarchar(20)
AS
SELECT TOP 1 IdUnidadMasa FROM [dbo].[UnidadMasa] 
WHERE [dbo].[UnidadMasa].IdUnidadMasa <> @IdUnidadMasa AND [dbo].[UnidadMasa].Nombre=@Nombre
GO

CREATE PROCEDURE UnidadMasaVerificarRelacionArticulo
@IdUnidadMasa int
AS
SELECT TOP 1 [IdUnidadMasa] FROM  [dbo].[PresentacionArticulo]
WHERE [dbo].[PresentacionArticulo].IdUnidadMasa = @IdUnidadMasa
GO

