CREATE PROCEDURE [dbo].[ConfiguracionCatalogoPDFPorCategoriasInsert] 	
	@IdCategoria int,
	@NroColumnas int
AS
INSERT INTO [dbo].[ConfiguracionCatalogoPDFPorCategorias]
	([IdCategoria],
	[NroColumnasPorCategoria])
	VALUES
	(@IdCategoria,
	@NroColumnas)
GO

CREATE PROCEDURE [dbo].[ConfiguracionCatalogoPDFPorCategoriasSelect]
AS
SELECT [dbo].[ConfiguracionCatalogoPDFPorCategorias].[IdCategoria],[dbo].[ConfiguracionCatalogoPDFPorCategorias].[NroColumnasPorCategoria], [dbo].[Categoria].[Nombre]
FROM [dbo].[ConfiguracionCatalogoPDFPorCategorias]
INNER JOIN [dbo].[Categoria] ON [dbo].[Categoria].IdCategoria = [dbo].[ConfiguracionCatalogoPDFPorCategorias].[IdCategoria]
GO

CREATE PROCEDURE [dbo].[ConfiguracionCatalogoPDFPorCategoriasDelete]
@IdCategoria int
AS
DELETE FROM [dbo].[ConfiguracionCatalogoPDFPorCategorias]
WHERE [IdCategoria] = @IdCategoria
GO