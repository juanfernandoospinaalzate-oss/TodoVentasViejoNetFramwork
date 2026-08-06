
CREATE PROCEDURE [dbo].[DetalleVentaWebInsert]
	@IdVenta int,
	@IdCliente int,
	@NombreMarca nvarchar(20),
	@Titulo nvarchar(50),
	--@CodigoEAN nvarchar(30),
	@NombreUnidadVolumen nvarchar(40),
	@VlrVolumenLargo float,
	@VlrVolumenAncho float,
	@VlrVolumenProfundidad float,
	@VlrContenidoVolumetrico float,
	@NombreUnidadMasa nvarchar(20),
	@VlrUnidadMasa float,
	@NombreUnidadLongitud nvarchar(20),
	@VlrUnidadLongitud float,
	@NombreTalla nvarchar(20),
	@NombreColor nvarchar(25),
	@NombreSabor nvarchar(20),
	@PrecioVenta float,
	@Cantidad int,
	@CostoDelProducto float,
	@SubTotalVenta float,
	@SubtotalCosto float,
	@NombreCategoria nvarchar(60),
	@CaminoSubCategorias nvarchar(250),
	@IdPresentacionArticulo int,
	@NombreUnidadPresentacion nvarchar(40),
	@VlrUnidadPresentacion float
AS
INSERT INTO [dbo].[DetalleVentaWeb]
	([IdVentaWeb]
	,[IdCliente]
	,[NombreMarca]
	,[Titulo]
	--,[CodigoEAN]
	,[NombreUnidadVolumen]
	,[VlrVolumenLargo]
	,[VlrVolumenAncho]
	,[VlrVolumenProfundidad]
	,[VlrContenidoVolumetrico]
	,[NombreUnidadMasa]
	,[VlrUnidadMasa]
	,[NombreUnidadLongitud]
	,[VlrUnidadLongitud]
	,[NombreTalla]
	,[NombreColor]
	,[NombreSabor]
	,[PrecioVenta]
	,[Cantidad]
	,[CostoDelProducto]
	,[SubTotalVenta]
	,[SubtotalCosto]
	,[NombreCategoria]
	,[CaminoSubCategorias]
	,[IdPresentacionArticulo]
	,[NombreUnidadPresentacion]
	,[VlrUnidadPresentacion])
VALUES
	(@IdVenta
	,@IdCliente
	,@NombreMarca
	,@Titulo
	--,@CodigoEAN
	,@NombreUnidadVolumen
	,@VlrVolumenLargo
	,@VlrVolumenAncho
	,@VlrVolumenProfundidad
	,@VlrContenidoVolumetrico
	,@NombreUnidadMasa
	,@VlrUnidadMasa
	,@NombreUnidadLongitud
	,@VlrUnidadLongitud
	,@NombreTalla
	,@NombreColor
	,@NombreSabor
	,@PrecioVenta
	,@Cantidad
	,@CostoDelProducto
	,@SubTotalVenta
	,@SubtotalCosto
	,@NombreCategoria
	,@CaminoSubCategorias
	,@IdPresentacionArticulo
	,@NombreUnidadPresentacion
	,@VlrUnidadPresentacion)
GO

CREATE PROCEDURE [dbo].[DetalleVentaVerificarVentaArticulo]
	@IdPresentacionArticulo INT,
	@TotalVentas INT OUTPUT
AS
	DECLARE @ContadorVentas INT
	DECLARE @ContadorVentasWeb INT

	SET @ContadorVentas = (SELECT COUNT(IdPresentacionArticulo) FROM [dbo].[DetalleVenta] WHERE IdPresentacionArticulo = @IdPresentacionArticulo)
	SET @ContadorVentasWeb = (SELECT COUNT(IdPresentacionArticulo) FROM [dbo].[DetalleVentaWeb] WHERE IdPresentacionArticulo = @IdPresentacionArticulo)
	SET @TotalVentas = @ContadorVentas + @ContadorVentasWeb
GO

