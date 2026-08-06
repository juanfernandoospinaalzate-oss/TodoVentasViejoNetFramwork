CREATE PROCEDURE [dbo].[PaisInsert] 	
@Nombre nvarchar(42)
AS
INSERT INTO [dbo].[Pais]([Nombre])VALUES(@Nombre)
GO
CREATE PROCEDURE [dbo].[PaisSelect]
AS
SELECT [IdPais],[Nombre]
FROM [dbo].[Pais]
GO
CREATE PROCEDURE [dbo].[PaisDelete]
@IdPais int
AS
DELETE FROM [dbo].[Pais]
WHERE IdPais = @IdPais