ALTER TABLE [dbo].[Contacto]
	ADD CONSTRAINT [ForeignKeyContactoIdCiudad] 
	FOREIGN KEY (IdCiudad)
	REFERENCES Ciudad (IdCiudad)	
GO
	ALTER TABLE [dbo].[Contacto]
	ADD CONSTRAINT [ForeignKeyContactoIdIdioma] 
	FOREIGN KEY (IdIdioma)
	REFERENCES Idioma (IdIdioma)