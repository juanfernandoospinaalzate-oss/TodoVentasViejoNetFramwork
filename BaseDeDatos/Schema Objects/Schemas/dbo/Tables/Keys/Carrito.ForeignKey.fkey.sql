ALTER TABLE [dbo].[Carrito]
	ADD CONSTRAINT [ForeignKeyCarritoIdPresentacionArticulo] 
	FOREIGN KEY (IdPresentacionArticulo)
	REFERENCES [dbo].[PresentacionArticulo](IdPresentacionArticulo)
GO
	
ALTER TABLE [dbo].[Carrito]
	ADD CONSTRAINT [ForeignKeyCarritoIdCliente] 
	FOREIGN KEY (IdUsuario)
	REFERENCES [dbo].[Cliente](IdCliente)
GO