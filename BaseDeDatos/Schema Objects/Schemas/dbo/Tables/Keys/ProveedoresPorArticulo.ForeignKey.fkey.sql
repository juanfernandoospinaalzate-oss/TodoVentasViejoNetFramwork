ALTER TABLE [dbo].[ProveedoresPorArticulo]
	ADD CONSTRAINT [ForeignKeyIdProveedor_ProveedoresPorArticulo] 
	FOREIGN KEY (IdProveedor)
	REFERENCES Proveedor (IdProveedor)	
GO
ALTER TABLE [dbo].[ProveedoresPorArticulo]
	ADD CONSTRAINT [ForeignKeyIdArticulo_ProveedoresPorArticulo] 
	FOREIGN KEY (IdArticulo)
	REFERENCES Articulo (IdArticulo)	
GO