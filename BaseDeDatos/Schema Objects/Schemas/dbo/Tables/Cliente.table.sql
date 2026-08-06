CREATE TABLE Cliente
(
	IdCliente int IDENTITY(1,1) NOT NULL, 
	DocCliente int NOT NULL,
	Nombre nvarchar(30) NOT NULL,
	Apellido nvarchar(30) NOT NULL,
	Telefono1 nvarchar(20) NOT NULL,
	Telefono2 nvarchar(20) NOT NULL,
	EMail nvarchar(50) NOT NULL,
	Contrasena nvarchar(50) NOT NULL,
)	