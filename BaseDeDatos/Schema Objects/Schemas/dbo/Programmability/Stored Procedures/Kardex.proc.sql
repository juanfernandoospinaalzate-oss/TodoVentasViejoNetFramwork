CREATE PROCEDURE KardexInsert
	(@IdPresentacionArticulo INT
	,@Fecha DATETIME
	,@Nombre NVARCHAR(100)
	,@CantidadEntrada INT
	,@CantidadSalida INT
	,@PrecioUnitario FLOAT
	,@CostoUnitario FLOAT
	,@TotalExistencias INT
	,@PrecioTotal FLOAT
	,@CostoTotal FLOAT
	,@Detalle NVARCHAR (100))
AS
INSERT INTO [dbo].[Kardex]
	([IdPresentacionArticulo]
	,[Fecha]
	,[Nombre]
	,[CantidadEntrada]
	,[CantidadSalida]
	,[PrecioUnitario]
	,[CostoUnitario]
	,[TotalExistencias]
	,[PrecioTotal]
	,[CostoTotal]
	,[Detalle])
VALUES
	(@IdPresentacionArticulo
	,@Fecha
	,@Nombre
	,@CantidadEntrada
	,@CantidadSalida
	,@PrecioUnitario
	,@CostoUnitario
	,@TotalExistencias
	,@PrecioTotal
	,@CostoTotal
	,@Detalle)
GO

CREATE PROCEDURE KardexSelectPorIdPresentacionArticulo
	(@IdPresentacionArticulo INT)
AS
SELECT 
	[Id]
	,[IdPresentacionArticulo]
	,[Fecha]
	,[Nombre]
	,[CantidadEntrada]
	,[CantidadSalida]
	,[PrecioUnitario]
	,[CostoUnitario]
	,[TotalExistencias]
	,[PrecioTotal]
	,[CostoTotal]
	,[Detalle]
FROM  [dbo].[Kardex] WHERE [IdPresentacionArticulo] = @IdPresentacionArticulo
GO

CREATE PROCEDURE [dbo].[KardexVerificarRelacionPresentacionArticulo]
	@IdPresentacionArticulo INT,
	@ContadorTotalMovimientos INT OUTPUT
AS
	SET @ContadorTotalMovimientos = (SELECT COUNT([IdPresentacionArticulo]) FROM [dbo].[Kardex] WHERE IdPresentacionArticulo = @IdPresentacionArticulo)