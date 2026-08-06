CREATE TABLE [dbo].[Contacto]
(
	IdContacto int IDENTITY(1,1) NOT NULL, 
	Nombre nvarchar(60) NOT NULL,
	IdCiudad int  NOT NULL,
	Telefono nvarchar(60) NOT NULL,
	Movil nvarchar(60) NOT NULL,
	Email nvarchar(60)NOT NULL,
	IdIdioma int NOT NULL
)
