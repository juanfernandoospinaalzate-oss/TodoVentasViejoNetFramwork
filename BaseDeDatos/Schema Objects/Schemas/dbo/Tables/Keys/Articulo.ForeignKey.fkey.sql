ALTER TABLE [dbo].[Articulo]
	ADD CONSTRAINT [ForeignKeyAlmacen_Categoria] 
	FOREIGN KEY (IdCategoria)
	REFERENCES Categoria (IdCategoria)
GO
ALTER TABLE  [dbo].[Articulo]
	ADD CONSTRAINT [ForeignKeyMarca] 
	FOREIGN KEY (IdMarca)
	REFERENCES Marca (IdMarca)	
GO



