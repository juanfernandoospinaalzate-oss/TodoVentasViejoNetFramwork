CREATE PROCEDURE [dbo].[TarjetaCreditoPayUSelect]
AS
SELECT [Id], [IdPayU], [Descripcion]
FROM [dbo].[TarjetaCreditoPayU]
GO

CREATE PROCEDURE [dbo].[TarjetaCreditoPayUInsert] 
@IdPayU int,	
@Descripcion nvarchar(50)
AS
INSERT INTO [dbo].[TarjetaCreditoPayU]([IdPayU], [Descripcion])VALUES(@IdPayU, @Descripcion)
GO

CREATE PROCEDURE [dbo].[TarjetaCreditoPayUDelete] 
@IdPayU int
AS
DELETE FROM [dbo].[TarjetaCreditoPayU]
WHERE IdPayU = @IdPayU