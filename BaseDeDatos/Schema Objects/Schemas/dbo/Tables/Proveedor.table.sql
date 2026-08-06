CREATE TABLE [dbo].[Proveedor]
(
	IdProveedor int IDENTITY(1,1) NOT NULL, 
	NIT int NOT NULL,
	Nombre nvarchar(100) NOT NULL,
	Descripcion nvarchar(250) NOT NULL,
	Direccion nvarchar(250) NOT NULL,
	IdCiudad int NOT NULL,
	Telefono1 nvarchar(50) NOT NULL,
	Telefono2 nvarchar(50) NOT NULL,
	Fax nvarchar(50) NOT NULL,
	SitioWeb nvarchar(250) NOT NULL
)
