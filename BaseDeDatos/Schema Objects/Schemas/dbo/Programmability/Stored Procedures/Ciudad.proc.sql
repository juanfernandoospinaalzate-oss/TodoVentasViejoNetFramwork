CREATE PROCEDURE [dbo].[CiudadInsert] 	
@Nombre nvarchar(42)
,@IdDepartamento int
AS
INSERT INTO [dbo].[Ciudad](Nombre, IdDepartamento)VALUES(@Nombre, @IdDepartamento)
GO
CREATE PROCEDURE [dbo].[CiudadSelect]
@IdDpto int
AS
SELECT [IdCiudad], [IdDepartamento], [Nombre]
FROM [dbo].[Ciudad]
WHERE [IdDepartamento] = @IdDpto
GO
CREATE PROCEDURE [dbo].[CiudadDelete]
@IdCiudad int
AS
DELETE FROM [dbo].[Ciudad]
WHERE [IdCiudad] = @IdCiudad
GO
CREATE PROCEDURE [dbo].[CiudadUpdate]
(@IdCiudad int,
@Nombre nvarchar(42))
AS
UPDATE [dbo].[Ciudad]
   SET Nombre = @Nombre
 WHERE IdCiudad = @IdCiudad
