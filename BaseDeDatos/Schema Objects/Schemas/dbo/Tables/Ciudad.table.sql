CREATE TABLE [dbo].[Ciudad]
(
	IdCiudad int IDENTITY(1,1) NOT NULL, 
	IdDepartamento int NOT NULL,
	Nombre nvarchar(42) NOT NULL
)
