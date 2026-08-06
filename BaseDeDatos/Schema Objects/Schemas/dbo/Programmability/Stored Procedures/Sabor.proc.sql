CREATE PROCEDURE [dbo].[SaborInsert] 	
@Nombre nvarchar(20)
AS
INSERT INTO [dbo].[Sabor]([Nombre])VALUES(@Nombre)
GO
CREATE PROCEDURE [dbo].[SaborSelect]
AS
SELECT [IdSabor]
,[Nombre]
FROM [dbo].[Sabor]
GO
CREATE PROCEDURE [dbo].[SaborDelete]
@IdSabor int
AS
DELETE FROM [dbo].[Sabor]
WHERE [IdSabor] = @IdSabor
GO
CREATE PROCEDURE [dbo].[SaborUpdate]
(@IdSabor int,
@Nombre nvarchar(20))
AS
UPDATE [dbo].[Sabor]
   SET Nombre = @Nombre
 WHERE IdSabor = @IdSabor
 GO

