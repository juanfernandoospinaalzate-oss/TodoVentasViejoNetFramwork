CREATE TABLE [dbo].[Articulo]
(
	IdArticulo int IDENTITY(1,1) NOT NULL, 
	IdMarca int NOT NULL,
	Titulo nvarchar(100) NOT NULL,
	IdCategoria int NOT NULL,
	Descripcion nvarchar(MAX) NOT NULL,
	PalabrasRelacionArticulo nvarchar(250) NOT NULL,
	MetaDescripcion nvarchar(250) NOT NULL,
	MetaKeyWords nvarchar(250) NOT NULL,
	UnidadVolumen bit NOT NULL,
	UnidadMasa bit NOT NULL,
	UnidadLongitud bit NOT NULL,
	Tallas bit NOT NULL,
	Colores bit NOT NULL,
	EnLinea bit NOT NULL,
	PreOrdenar bit NOT NULL,
	Sabor bit NOT NULL,
	Activo bit NOT NULL,
	GarantiaMeses int NOT NULL,
	VideoYoutube nvarchar(150) NOT NULL,
	UnidadPresentacion bit NOT NULL,
	Actualizar bit NULL
)
