CREATE PROCEDURE UnidadLongitudInsert 	
@Nombre nvarchar(40)
AS
INSERT INTO [dbo].[UnidadLongitud]([Nombre])VALUES(@Nombre)
GO

CREATE PROCEDURE UnidadLongitudSelect
AS
SELECT IdUnidadLongitud
,Nombre
FROM [dbo].[UnidadLongitud]
GO

CREATE PROCEDURE UnidadLongitudDelete
@IdUnidadLongitud int
AS
DELETE FROM [dbo].[UnidadLongitud]
WHERE IdUnidadLongitud = @IdUnidadLongitud
GO

CREATE PROCEDURE [dbo].[UnidadLongitudUpdate]
(@IdUnidadLongitud int,
@Nombre nvarchar(40))
AS
UPDATE [dbo].[UnidadLongitud]
   SET Nombre = @Nombre
 WHERE IdUnidadLongitud = @IdUnidadLongitud
 GO

CREATE PROCEDURE UnidadLongitudVerificarDuplicidad
@IdUnidadLongitud int,
@Nombre nvarchar(20)
AS
SELECT TOP 1 IdUnidadLongitud FROM [dbo].[UnidadLongitud] 
WHERE [dbo].[UnidadLongitud].IdUnidadLongitud <> @IdUnidadLongitud AND [dbo].[UnidadLongitud].Nombre=@Nombre
GO

CREATE PROCEDURE UnidadLongitudVerificarRelacionArticulo
@IdUnidadLongitud int
AS
SELECT TOP 1 IdUnidadLongitud FROM  [dbo].[PresentacionArticulo]
WHERE [dbo].[PresentacionArticulo].IdUnidadLongitud = @IdUnidadLongitud
GO