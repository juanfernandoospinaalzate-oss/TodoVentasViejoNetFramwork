CREATE TABLE Direccion
(
	IdDireccion int IDENTITY(1,1) NOT NULL,
	NombreDestinatario nvarchar(30) NOT NULL,
	DireccionEnvio nvarchar(80) NOT NULL,
	Telefono nvarchar(20) NOT NULL,
	IdPais int NOT NULL,
	IdDepartamento int NOT NULL,
	IdCiudad int NOT NULL,
	IdCliente int NOT NULL
)
