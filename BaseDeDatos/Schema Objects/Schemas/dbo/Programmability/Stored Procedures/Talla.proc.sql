CREATE PROCEDURE [dbo].[TallaInsert] 	
@Nombre nvarchar(20)
AS
INSERT INTO [dbo].[Talla]([Nombre])VALUES(@Nombre)
GO

CREATE PROCEDURE [dbo].[TallaVerificarDuplicidad]
@IdTalla int,
@Nombre nvarchar(20)
AS
SELECT TOP 1 IdTalla FROM [dbo].[Talla]  
WHERE [dbo].[Talla].IdTalla <> @IdTalla AND [dbo].[Talla].Nombre=@Nombre
GO

CREATE PROCEDURE TallaUpdate
(@IdTalla int,
@Nombre nvarchar(20))
AS
UPDATE [dbo].[Talla]
   SET Nombre = @Nombre
 WHERE IdTalla = @IdTalla
 GO

CREATE PROCEDURE TallaSelect
AS
SELECT [IdTalla]
,[Nombre]
FROM [dbo].[Talla]
GO

CREATE PROCEDURE TallaDelete
@IdTalla int
AS
DELETE FROM [dbo].[Talla]
WHERE IdTalla = @IdTalla
GO
CREATE PROCEDURE TallaVerificarRelacionArticulo
@IdTalla int
AS
SELECT TOP 1 [IdTalla] FROM  [dbo].[PresentacionArticulo]
WHERE [dbo].[PresentacionArticulo].IdTalla = @IdTalla
GO