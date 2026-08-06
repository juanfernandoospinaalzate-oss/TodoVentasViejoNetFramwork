CREATE FULLTEXT CATALOG CatalogoPresentacionArticulos
GO

CREATE FULLTEXT INDEX 
	ON [dbo].[Articulo] (Titulo, Descripcion, PalabrasRelacionArticulo)
	KEY INDEX PrimaryKeyArticulo
	ON CatalogoPresentacionArticulos
	WITH CHANGE_TRACKING AUTO
GO

CREATE FULLTEXT INDEX
	ON [dbo].[Categoria] (Nombre, Descripcion, PalabrasClaves)
	KEY INDEX PrimaryKeyCategoria
	ON CatalogoPresentacionArticulos
	WITH CHANGE_TRACKING AUTO
GO

CREATE FULLTEXT INDEX
	ON [dbo].[Busquedas] (Texto)
	KEY INDEX PrimaryKeyBusquedas
	ON CatalogoPresentacionArticulos
	WITH CHANGE_TRACKING AUTO
GO