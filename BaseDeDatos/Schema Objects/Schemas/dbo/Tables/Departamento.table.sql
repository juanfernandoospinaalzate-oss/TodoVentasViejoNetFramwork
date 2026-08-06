CREATE TABLE [dbo].[Departamento]
(
	IdDepartamento int IDENTITY(1,1) NOT NULL, 
	IdPais int NOT NULL,
	Nombre nvarchar(42) NOT NULL
)
