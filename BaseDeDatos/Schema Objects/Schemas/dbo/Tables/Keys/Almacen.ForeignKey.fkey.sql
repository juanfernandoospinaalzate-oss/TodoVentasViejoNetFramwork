ALTER TABLE [dbo].[Almacen]
	ADD CONSTRAINT [ForeignKeyIdCiudad] 
	FOREIGN KEY (IdCiudad)
	REFERENCES Ciudad (IdCiudad)	
GO
	

