ALTER TABLE [dbo].[VentaWeb]
	ADD CONSTRAINT [ForeignKeyIdClienteWeb] 
	FOREIGN KEY (IdCliente)
	REFERENCES [dbo].[Cliente] (IdCliente)	
GO

