ALTER TABLE [dbo].[ArticulosPorAlmacen]
	ADD CONSTRAINT [ForeignKeyArticulo] 
	FOREIGN KEY (IdPresentacionArticulo)
	REFERENCES PresentacionArticulo (IdPresentacionArticulo)	
GO
ALTER TABLE [dbo].[ArticulosPorAlmacen]
	ADD CONSTRAINT [ForeignKeyAlmacen] 
	FOREIGN KEY (IdAlmacen)
	REFERENCES Almacen (IdAlmacen)	
GO
