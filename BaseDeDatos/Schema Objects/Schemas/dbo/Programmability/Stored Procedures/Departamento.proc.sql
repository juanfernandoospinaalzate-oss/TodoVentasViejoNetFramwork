CREATE PROCEDURE [dbo].[DepartamentoInsert] 	
@Nombre nvarchar(42)
,@IdPais int
AS
INSERT INTO [dbo].[Departamento]([Nombre], IdPais)VALUES(@Nombre, @IdPais)
GO
CREATE PROCEDURE [dbo].[DepartamentoSelect]
@IdPais int
AS
SELECT [IdDepartamento],[IdPais],[Nombre]
FROM [dbo].[Departamento]
WHERE IdPais = @IdPais
GO	
CREATE PROCEDURE [dbo].[DepartamentoUpdate]
(@IdDepartamento int,
@Nombre nvarchar(42))
AS
UPDATE [dbo].[Departamento]
   SET Nombre = @Nombre
 WHERE IdDepartamento = @IdDepartamento
 GO
 CREATE PROCEDURE [dbo].[DepartamentoDelete]
@IdDepartamento int
AS
DELETE FROM [dbo].[Departamento]
WHERE IdDepartamento = @IdDepartamento
