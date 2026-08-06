ALTER TABLE [dbo].[Venta]
	ADD CONSTRAINT [ForeignKeyIdCliente] 
	FOREIGN KEY (IdCliente)
	REFERENCES [dbo].[Cliente] (IdCliente)	
GO

