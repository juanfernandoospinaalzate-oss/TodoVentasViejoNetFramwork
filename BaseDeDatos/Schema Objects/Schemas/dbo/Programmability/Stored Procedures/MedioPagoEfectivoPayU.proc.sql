CREATE PROCEDURE [dbo].[MedioPagoEfectivoPayUSelect]
AS
SELECT [Id], [IdPayU], [Descripcion]
FROM [dbo].[MedioPagoEfectivoPayU]
GO

CREATE PROCEDURE [dbo].[MedioPagoEfectivoPayUInsert] 
@IdPayU int,	
@Descripcion nvarchar(50)
AS
INSERT INTO [dbo].[MedioPagoEfectivoPayU]([IdPayU], [Descripcion])VALUES(@IdPayU, @Descripcion)
GO

CREATE PROCEDURE [dbo].[MedioPagoEfectivoPayUDelete] 
@IdPayU int
AS
DELETE FROM [dbo].[MedioPagoEfectivoPayU]
WHERE IdPayU = @IdPayU
GO






