ALTER TABLE [dbo].[ContactosPorProveedor]
	ADD CONSTRAINT [ForeignKeyContactosPorProveedor_IdContacto] 
	FOREIGN KEY (IdContacto)
	REFERENCES Contacto (Idcontacto)	
GO
ALTER TABLE [dbo].[ContactosPorProveedor]
	ADD CONSTRAINT [ForeignKeyContactosPorProveedor_IdProveedor] 
	FOREIGN KEY (IdProveedor)
	REFERENCES Proveedor (IdProveedor)	
GO