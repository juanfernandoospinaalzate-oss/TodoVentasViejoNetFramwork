CREATE INDEX IndexIdArticulo
    ON [dbo].[ArticulosPorAlmacen]
	(IdPresentacionArticulo)
GO
CREATE INDEX IndexIdAlmacen
    ON [dbo].[ArticulosPorAlmacen]
	(IdAlmacen)
GO
