
CREATE INDEX [IndexIdCategoria]
    ON [dbo].[Categoria]
	(IdCategoria)
go
	CREATE INDEX [IndexIdSubCategoria]
    ON [dbo].[Categoria]
	(IdCategoriaPadre)