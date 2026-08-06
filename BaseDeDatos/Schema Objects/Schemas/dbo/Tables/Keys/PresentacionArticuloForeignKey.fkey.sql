ALTER TABLE [dbo].[PresentacionArticulo]
	ADD CONSTRAINT [ForeignKeyIdColor] 
	FOREIGN KEY (IdColor)
	REFERENCES Color (IdColor)	
GO
ALTER TABLE [dbo].[PresentacionArticulo]
	ADD CONSTRAINT [ForeignKeyIdTalla] 
	FOREIGN KEY (IdTalla)
	REFERENCES Talla (IdTalla)	
GO
ALTER TABLE [dbo].[PresentacionArticulo]
	ADD CONSTRAINT [ForeignKeyIdUnidadLongitud] 
	FOREIGN KEY (IdUnidadLongitud)
	REFERENCES UnidadLongitud (IdUnidadLongitud)	
GO
ALTER TABLE [dbo].[PresentacionArticulo]
	ADD CONSTRAINT [ForeignKeyIdUnidadMasa] 
	FOREIGN KEY (IdUnidadMasa)
	REFERENCES UnidadMasa (IdUnidadMasa)	
GO
ALTER TABLE [dbo].[PresentacionArticulo]
	ADD CONSTRAINT [ForeignKeyIdUnidadVolumen] 
	FOREIGN KEY (IdUnidadVolumen)
	REFERENCES UnidadVolumen (IdUnidadVolumen)	
GO
ALTER TABLE [dbo].[PresentacionArticulo]
	ADD CONSTRAINT [ForeignKeyIdArticulo] 
	FOREIGN KEY (IdArticulo)
	REFERENCES Articulo (IdArticulo)	
GO
ALTER TABLE [dbo].[PresentacionArticulo]
	ADD CONSTRAINT [ForeignKeyIdSabor] 
	FOREIGN KEY (IdSabor)
	REFERENCES Sabor (IdSabor)	
GO
ALTER TABLE [dbo].[PresentacionArticulo]
	ADD CONSTRAINT [ForeignKeyIdUnidadPresentacion] 
	FOREIGN KEY (IdUnidadPresentacion)
	REFERENCES UnidadPresentacion (IdUnidadPresentacion)	
GO