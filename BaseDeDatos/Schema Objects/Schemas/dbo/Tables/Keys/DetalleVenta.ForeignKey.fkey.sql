ALTER TABLE [dbo].[DetalleVenta]
	ADD CONSTRAINT [ForeignKeyIdVenta] 
	FOREIGN KEY (IdVenta)
	REFERENCES [dbo].[Venta] (IdVenta)	
GO