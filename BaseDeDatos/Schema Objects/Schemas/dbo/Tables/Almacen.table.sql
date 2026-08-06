CREATE TABLE [dbo].[Almacen]
(
	IdAlmacen int IDENTITY(1,1) NOT NULL, 
	[Nombre] nvarchar(60) NOT NULL,
	Descripcion nvarchar(250) NOT NULL,
	Direccion nvarchar(250) NOT NULL,
	IdCiudad int NOT NULL,
	Telefono1 nvarchar(50) NOT NULL,
	Telefono2 nvarchar(50) NOT NULL,
	Fax nvarchar(25) NOT NULL, 
    [Email] nvarchar(50) NOT NULL, 
    [Nit] INT NOT NULL, 
    [SitioWeb] NVARCHAR(50) NOT NULL
)
