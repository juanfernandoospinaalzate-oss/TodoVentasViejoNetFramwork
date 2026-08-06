CREATE TABLE [dbo].[ArticulosPorAlmacen]
(
	IdArticulosPorAlmacen int identity(1,1) NOT NULL, 
	IdPresentacionArticulo int NOT NULL,
	IdAlmacen int NOT NULL,
	Existencia int NOT NULL,
	MaxExistencias int NOT NULL,
	MinExistencias int NOT NULL,
	CostoUnitario numeric(18,2) NOT NULL,
	PrecioVenta numeric(18,2) NOT NULL,
	Iva numeric(3,2) NOT NULL
)
