ALTER TABLE [dbo].[ContactosPorAlmacen]
	ADD CONSTRAINT [ForeignKeyConstraint_ContactoPorAlmacen_Almacen] 
	FOREIGN KEY (IdAlmacen)
	REFERENCES Almacen (IdAlmacen)	
GO

ALTER TABLE [dbo].[ContactosPorAlmacen]
	ADD CONSTRAINT [ForeignKeyConstraint_ContactoPorAlmacen_Contacto] 
	FOREIGN KEY (IdContacto)
	REFERENCES Contacto (IdContacto)	
GO
