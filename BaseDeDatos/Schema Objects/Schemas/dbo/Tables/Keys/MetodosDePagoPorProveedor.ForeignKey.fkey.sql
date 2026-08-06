ALTER TABLE [dbo].[MetodosDePagoPorProveedor]
	ADD CONSTRAINT [ForeignKeyMetodosDePagoPorProveedor_IdMetodoDePago] 
	FOREIGN KEY (IdMetodoDePago)
	REFERENCES MetodoDePago (IdMetodoDePago)	
GO
ALTER TABLE [dbo].[MetodosDePagoPorProveedor]
	ADD CONSTRAINT [ForeignKeyMetodosDePagoPorProveedor_IdProveedor] 
	FOREIGN KEY (IdProveedor)
	REFERENCES Proveedor (IdProveedor)	
GO