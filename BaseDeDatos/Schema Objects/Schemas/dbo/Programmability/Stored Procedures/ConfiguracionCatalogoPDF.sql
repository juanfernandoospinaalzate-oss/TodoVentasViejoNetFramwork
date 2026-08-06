CREATE PROCEDURE [dbo].[ConfiguracionCatalogoPDFSelect]
AS
SELECT [existencias],
[precio],
[nroDeColumnas]
FROM [dbo].[ConfiguracionCatalogoPDF]
GO

CREATE PROCEDURE [dbo].[ConfiguracionCatalogoPDFInsert]
@existencias int,
@precio float,
@nroDeColumnas int
AS
INSERT INTO [dbo].[ConfiguracionCatalogoPDF]
	([existencias]
	,[precio]
	,[nroDeColumnas])
	VALUES
	(@existencias
	,@precio,
	@nroDeColumnas)
GO

CREATE PROCEDURE [dbo].[ConfiguracionCatalogoPDFUpdate]
(@existencias int,
@precio float,
@nroDeColumnas int)
AS
UPDATE [dbo].[ConfiguracionCatalogoPDF]
   SET existencias = @existencias,
	   precio = @precio,
	   nroDeColumnas = @nroDeColumnas
GO

