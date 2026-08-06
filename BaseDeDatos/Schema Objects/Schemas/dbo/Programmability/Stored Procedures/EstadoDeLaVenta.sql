CREATE PROCEDURE [dbo].[EstadoNuevoDelaVentaInsert] 	
@EstadoNuevo nvarchar(20)
AS
INSERT INTO [dbo].[EstadoDeLaVenta]([EstadoNuevo])VALUES(@EstadoNuevo)
GO

CREATE PROCEDURE [dbo].[EstadoDeLaVentaUpdate]
(@IdEstadoDeLaVenta int,
@EstadoNuevo nvarchar(20))
AS
UPDATE [dbo].[EstadoDeLaVenta]
   SET [EstadoNuevo] = @EstadoNuevo
 WHERE [IdEstadoDeLaVenta] = @IdEstadoDeLaVenta
GO

CREATE PROCEDURE [dbo].[EstadoDeLaVentaSelect]
AS
SELECT [IdEstadoDeLaVenta],
[EstadoNuevo]
FROM [dbo].[EstadoDeLaVenta]
GO

CREATE PROCEDURE [dbo].[EstadoDeLaVentaDelete]
@IdEstadoDeLaVenta int
AS
DELETE FROM [dbo].[EstadoDeLaVenta]
WHERE [IdEstadoDeLaVenta] = @IdEstadoDeLaVenta
GO
