ALTER TABLE [dbo].[Kardex]
	ADD CONSTRAINT [ForeignKeyPresentacionArticulo]
	FOREIGN KEY (IdPresentacionArticulo)
	REFERENCES [PresentacionArticulo] (IdPresentacionArticulo)
