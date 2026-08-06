CREATE PROCEDURE [dbo].[ArticulosPorAlmacenSelect]
AS
	SELECT [IdArticulosPorAlmacen]
		  ,[IdPresentacionArticulo]
		  ,[IdAlmacen]
		  ,[MaxExistencias]
		  ,[MinExistencias]
		  ,[CostoUnitario]
		  ,[PrecioVenta]
		  ,[Iva]
	FROM [dbo].[ArticulosPorAlmacen]
GO

CREATE PROCEDURE [dbo].[ArticulosPorAlmacenInsert]
	(@IdArticulo int
	,@IdAlmacen int
	,@MaxExistencias int
	,@MinExistencias int
	,@CostoUnitario numeric(18,2)
	,@PrecioVenta numeric(18,2)
	,@Iva numeric(3,2))
AS
INSERT INTO [dbo].[ArticulosPorAlmacen]
           (IdPresentacionArticulo
           ,[IdAlmacen]
           ,[MaxExistencias]
           ,[MinExistencias]
           ,[CostoUnitario]
           ,[PrecioVenta]
           ,[Iva])
     VALUES
           (@IdArticulo
           ,@IdAlmacen
           ,@MaxExistencias
           ,@MinExistencias
           ,@CostoUnitario
           ,@PrecioVenta
           ,@Iva)
GO

CREATE PROCEDURE [dbo].[ArticulosPorAlmacenUpdate]
	(@IdPresentacionArticulo int
	,@IdAlmacen int
	,@MaxExistencias int
	,@MinExistencias int
	,@CostoUnitario numeric(18,2)
	,@PrecioVenta numeric(18,2)
	,@Iva numeric(3,2))
AS
UPDATE [dbo].[ArticulosPorAlmacen]
   SET IdPresentacionArticulo = @IdPresentacionArticulo
      ,[IdAlmacen] = @IdAlmacen
      ,[MaxExistencias] = @MaxExistencias
      ,[MinExistencias] = @MinExistencias
      ,[CostoUnitario] = @CostoUnitario
      ,[PrecioVenta] = @PrecioVenta
      ,[Iva] = @Iva
 WHERE IdPresentacionArticulo = @IdPresentacionArticulo
GO

CREATE PROCEDURE [dbo].[ArticulosPorAlmacenDelete]
	@IdPresentacionArticulo int
AS
DELETE FROM [dbo].[ArticulosPorAlmacen]
      WHERE IdPresentacionArticulo = @IdPresentacionArticulo
GO

CREATE PROCEDURE [dbo].[ListarPresentacionArticulo]
AS
SELECT [Nombre]
,[DescripcionBreve]
FROM [dbo].[PresentacionArticulo]
GO

CREATE PROCEDURE [dbo].[ListarPresentacionArticuloPorAlmacen]
@IdAlmacen int
AS
SELECT [Existencia]
,[MaxExistencias]
,[MinExistencias]
,[CostoUnitario]
,[PrecioVenta]
,[dbo].[PresentacionArticulo].Nombre
,[dbo].[ArticulosPorAlmacen].[IdPresentacionArticulo]
FROM [dbo].[ArticulosPorAlmacen]
INNER JOIN [dbo].[PresentacionArticulo] ON [dbo].[PresentacionArticulo].IdPresentacionArticulo = [dbo].[ArticulosPorAlmacen].[IdPresentacionArticulo]
WHERE [dbo].[ArticulosPorAlmacen].IdAlmacen = @IdAlmacen
GO