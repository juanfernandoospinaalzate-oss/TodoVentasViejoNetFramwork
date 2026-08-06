  CREATE PROCEDURE [dbo].[CarritoSelect]
@IdUsuario int
AS
 SELECT [dbo].[Carrito].[IdItemCarrito],
		[dbo].[Carrito].[IdUsuario],
		[dbo].[Carrito].[IdPresentacionArticulo],
		[dbo].[Carrito].[Cantidad],
		[dbo].[PresentacionArticulo].Nombre,
		[dbo].[PresentacionArticulo].Precio
FROM [dbo].[Carrito]
INNER JOIN [dbo].[PresentacionArticulo]
  ON [dbo].[PresentacionArticulo].[IdPresentacionArticulo] = [dbo].[Carrito].[IdPresentacionArticulo]
    WHERE [dbo].[Carrito].[IdUsuario] = @IdUsuario
	and [dbo].[PresentacionArticulo].Activo = 1 
	and [dbo].[PresentacionArticulo].EnLinea = 1;
GO

CREATE PROCEDURE [dbo].[CarritoDelete]
@IdItemCarrito int
AS
DELETE FROM [dbo].[Carrito]
WHERE [IdItemCarrito] = @IdItemCarrito
GO

CREATE PROCEDURE [dbo].[CarritoUpdate]
(@IdItemCarrito int,
 @Cantidad int)
AS
UPDATE [dbo].[Carrito]
   SET [Cantidad] = @Cantidad
 WHERE [IdItemCarrito] = @IdItemCarrito
 GO

CREATE PROCEDURE [dbo].[CarritoInsert] 
@IdUsuario int,	
@IdPresentacionArticulo int,
@Cantidad int
AS
INSERT INTO [dbo].[Carrito]([IdUsuario],[IdPresentacionArticulo],[Cantidad])VALUES(@IdUsuario,@IdPresentacionArticulo,@Cantidad)
GO 
  
CREATE PROCEDURE [dbo].[CarritoConsultarPorIdPresentacionArticulo]
@IdPresentacionArticulo int,
@IdUsuario int
AS
SELECT [dbo].[Carrito].IdItemCarrito, [dbo].[Carrito].IdUsuario, [dbo].[Carrito].IdPresentacionArticulo, [dbo].[Carrito].Cantidad ,[dbo].[PresentacionArticulo].Nombre 
	FROM [dbo].[Carrito]
	INNER JOIN [dbo].[PresentacionArticulo] ON [dbo].[PresentacionArticulo].IdPresentacionArticulo = [dbo].[Carrito].IdPresentacionArticulo
	WHERE [dbo].[Carrito].IdPresentacionArticulo = @IdPresentacionArticulo AND [dbo].[Carrito].[IdUsuario] = @IdUsuario
GO

CREATE PROCEDURE [dbo].[CarritoTotalPorIdUsuario]
@IdUsuario int
AS
SELECT SUM([dbo].[Carrito].[Cantidad]*[PresentacionArticulo].[Precio]) AS "Total"
FROM [dbo].[Carrito]
INNER JOIN [dbo].[PresentacionArticulo]
ON [dbo].[Carrito].IdPresentacionArticulo = [dbo].[PresentacionArticulo].IdPresentacionArticulo
WHERE [dbo].[Carrito].IdUsuario = @IdUsuario
GO

CREATE PROCEDURE [dbo].[CarritoEliminarPorIdPresentacionArticulo]
	@IdPresentacionArticulo AS INT
AS
	DELETE FROM Carrito WHERE IdPresentacionArticulo = @IdPresentacionArticulo
GO