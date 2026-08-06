CREATE PROCEDURE [dbo].[PresentacionArticuloInsert]
	(@IdArticulo int 
	,@CodigoEAN nvarchar(18)
	,@Nombre nvarchar(60)
	,@DescripcionBreve nvarchar(250)
	,@IdColor int
	,@IdTalla int
	,@Imagen1 bit
	,@Imagen2 bit
	,@Imagen3 bit
	,@Imagen4 bit
	,@Imagen5 bit
	,@Imagen6 bit
	,@VlrUnidadMasa float
	,@VlrUnidadVolumenLargo float
	,@VlrUnidadVolumenAncho float
	,@VlrUnidadVolumenProfundidad float
	,@VlrContenidoVolumetrico float
	,@VlrUnidadLongitud float
	,@IdUnidadMasa int
	,@IdUnidadVolumen int
	,@IdUnidadLongitud int
	,@EnLinea bit
	,@Activo bit
	,@Precio float
	,@Existencias int 
	,@IdSabor int
	,@CostoArticulo float
	,@PreOrden bit
	,@IdUnidadPresentacion int
	,@VlrUnidadPresentacion float
	,@OutFecha date OUTPUT
	,@OutIdPresentacionArticulo int OUTPUT
	,@FechaProximoVencimiento date
	,@UsarFechaProximoVencimiento bit
	,@UsarDescuento bit
	,@UsarPorcentajeDescuento bit
	,@ValorPorcentajeDescuento float
	,@UsarValorFijoDescuento bit
	,@ValorFijoDescuento float
	,@FechaInicioDescuento date
	,@FechaFinalDescuento date)
AS 
INSERT INTO [dbo].[PresentacionArticulo]
	([IdArticulo]
	,[CodigoEAN]
	,[Nombre]
	,[DescripcionBreve]
	,[IdColor]
	,[IdTalla]
	,[Imagen1]
	,[Imagen2]
	,[Imagen3]
	,[Imagen4]
	,[Imagen5]
	,[Imagen6]
	,[Fecha]
	,[VlrUnidadMasa]
	,[VlrUnidadVolumenLargo]
	,[VlrUnidadVolumenAncho]
	,[VlrUnidadVolumenProfundidad]
	,[VlrContenidoVolumetrico]
	,[VlrUnidadLongitud]
	,[IdUnidadMasa]
	,[IdUnidadVolumen]
	,[IdUnidadLongitud]
	,[EnLinea]
	,[Activo]
	,[Precio]
	,[Existencias]
	,[IdSabor]
	,[CostoArticulo]
	,[PreOrden]
	,[IdUnidadPresentacion]
	,[VlrUnidadPresentacion]
	,[Actualizar]
	,[FechaProximoVencimiento]
	,[UsarFechaProximoVencimiento]
	,[UsarDescuento]
	,[UsarPorcentajeDescuento]
	,[ValorPorcentajeDescuento]
	,[UsarValorFijoDescuento]
	,[ValorFijoDescuento]
	,[FechaInicioDescuento]
	,[FechaFinalDescuento])
VALUES			
	(@IdArticulo
	,@CodigoEAN
	,@Nombre
	,@DescripcionBreve
	,@IdColor 
	,@IdTalla 
	,@Imagen1 
	,@Imagen2 
	,@Imagen3 
	,@Imagen4 
	,@Imagen5 
	,@Imagen6  
	,CONVERT (date, GETDATE())       
	,@VlrUnidadMasa 
	,@VlrUnidadVolumenLargo
	,@VlrUnidadVolumenAncho
	,@VlrUnidadVolumenProfundidad
	,@VlrContenidoVolumetrico
	,@VlrUnidadLongitud
	,@IdUnidadMasa 
	,@IdUnidadVolumen
	,@IdUnidadLongitud
	,@EnLinea
	,@Activo
	,@Precio
	,@Existencias
	,@IdSabor
	,@CostoArticulo
	,@PreOrden
	,@IdUnidadPresentacion
	,@VlrUnidadPresentacion
	,1
	,@FechaProximoVencimiento
	,@UsarFechaProximoVencimiento
	,@UsarDescuento
	,@UsarPorcentajeDescuento
	,@ValorPorcentajeDescuento
	,@UsarValorFijoDescuento
	,@ValorFijoDescuento
	,@FechaInicioDescuento
	,@FechaFinalDescuento)
	SET @OutFecha = CONVERT(date, GETDATE());
	SET @OutIdPresentacionArticulo = SCOPE_IDENTITY();
GO

CREATE PROCEDURE [dbo].[PresentacionArticuloSelect]
AS
SELECT [IdPresentacionArticulo]
	,[IdArticulo]
	,[CodigoEAN]
	,[PresentacionArticulo].[Nombre]
	,[DescripcionBreve]
	,[PresentacionArticulo].[IdColor]
	,[dbo].[Color].[Codigo]
	,[dbo].[Color].[Nombre]
	,[IdTalla]
	,[Imagen1]
	,[Imagen2]
	,[Imagen3]
	,[Imagen4]
	,[Imagen5]
	,[Imagen6]
	,[Fecha]
	,[VlrUnidadMasa]
	,[VlrUnidadVolumenLargo]
	,[VlrUnidadVolumenAncho]
	,[VlrUnidadVolumenProfundidad]
	,[VlrContenidoVolumetrico]
	,[VlrUnidadLongitud]
	,[IdUnidadMasa]
	,[IdUnidadVolumen]
	,[IdUnidadLongitud]
	,[EnLinea]
	,[Activo]
	,[Precio]
	,[Existencias]
	,[IdSabor]
	,[CostoArticulo]
	,[PreOrden]
	,[PresentacionArticulo].[IdUnidadPresentacion]
	,[VlrUnidadPresentacion]
	,[UnidadPresentacion].[Nombre]
	,[FechaProximoVencimiento]
	,[UsarFechaProximoVencimiento]
	,[UsarDescuento]
	,[UsarPorcentajeDescuento]
	,[ValorPorcentajeDescuento]
	,[UsarValorFijoDescuento]
	,[ValorFijoDescuento]
	,[FechaInicioDescuento]
	,[FechaFinalDescuento]
FROM [dbo].[PresentacionArticulo]
INNER JOIN [dbo].[Color] ON [dbo].[Color].[IdColor] = [dbo].[PresentacionArticulo].[IdColor]
INNER JOIN [dbo].[UnidadPresentacion] ON [dbo].[UnidadPresentacion].[IdUnidadPresentacion] = [dbo].[PresentacionArticulo].[IdUnidadPresentacion]
ORDER BY [IdPresentacionArticulo]
GO

CREATE PROCEDURE [dbo].[PresentacionArticuloSelectActivos]
AS
SELECT [IdPresentacionArticulo]
	,[IdArticulo]
	,[CodigoEAN]
	,[PresentacionArticulo].[Nombre]
	,[DescripcionBreve]
	,[PresentacionArticulo].[IdColor]
	,[dbo].[Color].[Codigo]
	,[dbo].[Color].[Nombre]
	,[IdTalla]
	,[Imagen1]
	,[Imagen2]
	,[Imagen3]
	,[Imagen4]
	,[Imagen5]
	,[Imagen6]
	,[Fecha]
	,[VlrUnidadMasa]
	,[VlrUnidadVolumenLargo]
	,[VlrUnidadVolumenAncho]
	,[VlrUnidadVolumenProfundidad]
	,[VlrContenidoVolumetrico]
	,[VlrUnidadLongitud]
	,[IdUnidadMasa]
	,[IdUnidadVolumen]
	,[IdUnidadLongitud]
	,[EnLinea]
	,[Activo]
	,[Precio]
	,[Existencias]
	,[IdSabor]
	,[CostoArticulo]
	,[PreOrden]
	,[IdUnidadPresentacion]
	,[VlrUnidadPresentacion]
	,[FechaProximoVencimiento]
	,[UsarFechaProximoVencimiento]
	,[UsarDescuento]
	,[UsarPorcentajeDescuento]
	,[ValorPorcentajeDescuento]
	,[UsarValorFijoDescuento]
	,[ValorFijoDescuento]
	,[FechaInicioDescuento]
	,[FechaFinalDescuento]
FROM [dbo].[PresentacionArticulo]
INNER JOIN [dbo].[Color] ON [dbo].[Color].IdColor = [dbo].[PresentacionArticulo].IdColor
WHERE [dbo].[PresentacionArticulo].[Activo] = 1
ORDER BY [IdPresentacionArticulo]
GO

CREATE PROCEDURE [dbo].[PresentacionArticuloSelectPorIdArticulo]
@IdArticulo int
AS
SELECT [IdPresentacionArticulo]
	,[IdArticulo]
	,[CodigoEAN]
	,[PresentacionArticulo].[Nombre]
	,[DescripcionBreve]
	,[PresentacionArticulo].[IdColor]
	,[dbo].[Color].[Codigo]
	,[dbo].[Color].[Nombre]
	,[IdTalla]
	,[Imagen1]
	,[Imagen2]
	,[Imagen3]
	,[Imagen4]
	,[Imagen5]
	,[Imagen6]
	,[Fecha]
	,[VlrUnidadMasa]
	,[VlrUnidadVolumenLargo]
	,[VlrUnidadVolumenAncho]
	,[VlrUnidadVolumenProfundidad]
	,[VlrContenidoVolumetrico]
	,[VlrUnidadLongitud]
	,[IdUnidadMasa]
	,[IdUnidadVolumen]
	,[IdUnidadLongitud]
	,[EnLinea]
	,[Activo]
	,[Precio]
	,[Existencias]
	,[IdSabor]
	,[CostoArticulo]
	,[PreOrden]
	,[IdUnidadPresentacion]
	,[VlrUnidadPresentacion]
	,[FechaProximoVencimiento]
	,[UsarFechaProximoVencimiento]
	,[UsarDescuento]
	,[UsarPorcentajeDescuento]
	,[ValorPorcentajeDescuento]
	,[UsarValorFijoDescuento]
	,[ValorFijoDescuento]
	,[FechaInicioDescuento]
	,[FechaFinalDescuento]
FROM [dbo].[PresentacionArticulo]
INNER JOIN [dbo].[Color] ON [dbo].[Color].IdColor = [dbo].[PresentacionArticulo].IdColor
WHERE [dbo].[PresentacionArticulo].[IdArticulo] = @IdArticulo
GO

CREATE PROCEDURE [dbo].[PresentacionArticuloUpdate]
		(@IdPresentacionArticulo int
		,@IdArticulo int
		,@CodigoEAN nvarchar(18)
		,@Nombre nvarchar(60)
		,@DescripcionBreve nvarchar(250)
		,@IdColor int
		,@IdTalla int
		,@Imagen1 bit
		,@Imagen2 bit
		,@Imagen3 bit
		,@Imagen4 bit
		,@Imagen5 bit
		,@Imagen6 bit
		,@VlrUnidadMasa float
		,@VlrUnidadVolumenLargo float
		,@VlrUnidadVolumenAncho float
		,@VlrUnidadVolumenProfundidad float
		,@VlrContenidoVolumetrico float
		,@VlrUnidadLongitud float
		,@IdUnidadMasa int
		,@IdUnidadVolumen int
		,@IdUnidadLongitud int
		,@EnLinea bit
		,@Activo bit
		,@Precio float
		,@Existencias int
		,@IdSabor int
		,@CostoArticulo float
		,@PreOrden bit
		,@IdUnidadPresentacion int
		,@VlrUnidadPresentacion float
		,@FechaProximoVencimiento date
		,@UsarFechaProximoVencimiento bit
		,@UsarDescuento bit
		,@UsarPorcentajeDescuento bit
		,@ValorPorcentajeDescuento float
		,@UsarValorFijoDescuento bit
		,@ValorFijoDescuento float
		,@FechaInicioDescuento date
		,@FechaFinalDescuento date)
AS
UPDATE [dbo].[PresentacionArticulo]
SET	
	[IdArticulo] = @IdArticulo
	,[CodigoEAN] = @CodigoEAN
	,[Nombre] = @Nombre
	,[DescripcionBreve] = @DescripcionBreve
	,[IdColor] = @IdColor
	,[IdTalla] = @IdTalla
	,[Imagen1] = @Imagen1
	,[Imagen2] = @Imagen2
	,[Imagen3] = @Imagen3
	,[Imagen4] = @Imagen4
	,[Imagen5] = @Imagen5
	,[Imagen6] = @Imagen6
	,[VlrUnidadMasa] = @VlrUnidadMasa
	,[VlrUnidadVolumenLargo] = @VlrUnidadVolumenLargo
	,[VlrUnidadVolumenAncho] = @VlrUnidadVolumenAncho
	,[VlrUnidadVolumenProfundidad] = @VlrUnidadVolumenProfundidad
	,[VlrContenidoVolumetrico] = @VlrContenidoVolumetrico
	,[VlrUnidadLongitud] = @VlrUnidadLongitud
	,[IdUnidadMasa] = @IdUnidadMasa
	,[IdUnidadVolumen] = @IdUnidadVolumen
	,[IdUnidadLongitud] = @IdUnidadLongitud
	,[EnLinea] = @EnLinea
	,[Activo] =  @Activo
	,[Precio] = @Precio
	,[Existencias] = @Existencias
	,[IdSabor] = @IdSabor 
	,[CostoArticulo] = @CostoArticulo
	,[PreOrden] = @PreOrden
	,[IdUnidadPresentacion] = @IdUnidadPresentacion
	,[VlrUnidadPresentacion] = @VlrUnidadPresentacion
	,[Actualizar] = 1
	,[FechaProximoVencimiento] = @FechaProximoVencimiento
	,[UsarFechaProximoVencimiento] = @UsarFechaProximoVencimiento
	,[UsarDescuento] = @UsarDescuento
	,[UsarPorcentajeDescuento] = @UsarPorcentajeDescuento
	,[ValorPorcentajeDescuento] = @ValorPorcentajeDescuento
	,[UsarValorFijoDescuento] = @UsarValorFijoDescuento
	,[ValorFijoDescuento] = @ValorFijoDescuento
	,[FechaInicioDescuento] = @FechaInicioDescuento
	,[FechaFinalDescuento] = @FechaFinalDescuento
WHERE	[IdPresentacionArticulo] = @IdPresentacionArticulo
GO

CREATE PROCEDURE [dbo].[PresentacionArticuloUpdateEstado]
(@IdArticulo int
,@Estado bit)
AS
UPDATE [dbo].[PresentacionArticulo]
SET 
	[Activo] = @Estado
	,[Actualizar] = 1
 WHERE [IdArticulo] = @IdArticulo
GO

CREATE PROCEDURE [dbo].[PresentacionArticuloDelete]
@IdPresentacionArticulo int
AS
DELETE FROM [dbo].[PresentacionArticulo]
WHERE [IdPresentacionArticulo] = @IdPresentacionArticulo
GO

CREATE PROCEDURE [dbo].[PresentacionArticuloSelectWeb]
AS
SELECT [IdPresentacionArticulo]
	,[PresentacionArticulo].[IdArticulo]
	,[PresentacionArticulo].[CodigoEAN]
	,[PresentacionArticulo].[Nombre]
	,[PresentacionArticulo].[DescripcionBreve]
	,[PresentacionArticulo].[IdColor]
	,[PresentacionArticulo].[IdTalla]
	,[PresentacionArticulo].[Imagen1]
	,[PresentacionArticulo].[Imagen2]
	,[PresentacionArticulo].[Imagen3]
	,[PresentacionArticulo].[Imagen4]
	,[PresentacionArticulo].[Imagen5]
	,[PresentacionArticulo].[Imagen6]
	,[PresentacionArticulo].[Fecha]
	,[PresentacionArticulo].[VlrUnidadMasa]
	,[PresentacionArticulo].[VlrUnidadVolumenLargo]
	,[PresentacionArticulo].[VlrUnidadVolumenAncho]
	,[PresentacionArticulo].[VlrUnidadVolumenProfundidad]
	,[PresentacionArticulo].[VlrUnidadLongitud]
	,[PresentacionArticulo].[IdUnidadMasa]
	,[PresentacionArticulo].[IdUnidadVolumen]
	,[PresentacionArticulo].[IdUnidadLongitud]
	,[PresentacionArticulo].[EnLinea]
	,[PresentacionArticulo].[Activo]
	,[PresentacionArticulo].[Precio]
	,[Articulo].[Titulo]
	,[UnidadMasa].Nombre
	,[Sabor].[Nombre]
	,[Talla].Nombre
	,[Color].Nombre
	,[UnidadLongitud].Nombre
	,[UnidadVolumen].Nombre
	,[PresentacionArticulo].[VlrContenidoVolumetrico]
	,[PresentacionArticulo].[Existencias]
	,[Sabor].[IdSabor]
	,[Categoria].[IdCategoria]
	,[Categoria].[IdCategoriaPadre]
	,[Categoria].[Nombre]
	,[PresentacionArticulo].[IdUnidadPresentacion] 
	,[UnidadPresentacion].[Nombre]
	,[PresentacionArticulo].[VlrUnidadPresentacion] 
	,[PresentacionArticulo].[PreOrden]
	,[Marca].[IdMarca]
	,[Marca].[Nombre]
	,[PresentacionArticulo].[FechaProximoVencimiento]
	,[PresentacionArticulo].[UsarFechaProximoVencimiento]
	,[PresentacionArticulo].[UsarDescuento]
	,[PresentacionArticulo].[UsarPorcentajeDescuento]
	,[PresentacionArticulo].[ValorPorcentajeDescuento]
	,[PresentacionArticulo].[UsarValorFijoDescuento]
	,[PresentacionArticulo].[ValorFijoDescuento]
	,[PresentacionArticulo].[FechaInicioDescuento]
	,[PresentacionArticulo].[FechaFinalDescuento]
FROM [dbo].[PresentacionArticulo]
INNER JOIN [Articulo] ON [PresentacionArticulo].IdArticulo = [Articulo].IdArticulo
INNER JOIN [UnidadMasa]ON [UnidadMasa].IdUnidadMasa = [PresentacionArticulo].IdUnidadMasa
INNER JOIN [Sabor] ON [Sabor].IdSabor = [PresentacionArticulo].[IdSabor]
INNER JOIN [Talla] ON [Talla].IdTalla = [PresentacionArticulo].IdTalla
INNER JOIN [Color] ON [Color].IdColor = [PresentacionArticulo].IdColor
INNER JOIN [UnidadLongitud] ON [UnidadLongitud].IdUnidadLongitud = [PresentacionArticulo].IdUnidadLongitud
INNER JOIN [UnidadVolumen] ON [UnidadVolumen].IdUnidadVolumen = [PresentacionArticulo].IdUnidadVolumen
INNER JOIN [Categoria] ON [Categoria].[IdCategoria] = [Articulo].[IdCategoria]
INNER JOIN [UnidadPresentacion] ON [UnidadPresentacion].[IdUnidadPresentacion] = [PresentacionArticulo].[idUnidadPresentacion]
INNER JOIN [Marca] ON [Marca].[IdMarca] = [Articulo].[IdMarca]
WHERE [PresentacionArticulo].[Activo] = 1 AND [PresentacionArticulo].[EnLinea] = 1 
	AND [Articulo].[Activo] =1 AND [Articulo].[EnLinea] = 1
ORDER BY IdPresentacionArticulo
GO

CREATE PROCEDURE [dbo].[PresentacionArticuloSelectWebPendientesActualizacion]
AS
SELECT [IdPresentacionArticulo]
	,[PresentacionArticulo].[IdArticulo]
	,[PresentacionArticulo].[CodigoEAN]
	,[PresentacionArticulo].[Nombre]
	,[PresentacionArticulo].[DescripcionBreve]
	,[PresentacionArticulo].[IdColor]
	,[PresentacionArticulo].[IdTalla]
	,[PresentacionArticulo].[Imagen1]
	,[PresentacionArticulo].[Imagen2]
	,[PresentacionArticulo].[Imagen3]
	,[PresentacionArticulo].[Imagen4]
	,[PresentacionArticulo].[Imagen5]
	,[PresentacionArticulo].[Imagen6]
	,[PresentacionArticulo].[Fecha]
	,[PresentacionArticulo].[VlrUnidadMasa]
	,[PresentacionArticulo].[VlrUnidadVolumenLargo]
	,[PresentacionArticulo].[VlrUnidadVolumenAncho]
	,[PresentacionArticulo].[VlrUnidadVolumenProfundidad]
	,[PresentacionArticulo].[VlrUnidadLongitud]
	,[PresentacionArticulo].[IdUnidadMasa]
	,[PresentacionArticulo].[IdUnidadVolumen]
	,[PresentacionArticulo].[IdUnidadLongitud]
	,[PresentacionArticulo].[EnLinea]
	,[PresentacionArticulo].[Activo]
	,[PresentacionArticulo].[Precio]
	,[Articulo].[Titulo]
	,[UnidadMasa].Nombre
	,[Sabor].[Nombre]
	,[Talla].Nombre
	,[Color].Nombre
	,[UnidadLongitud].Nombre
	,[UnidadVolumen].Nombre
	,[PresentacionArticulo].[VlrContenidoVolumetrico]
	,[PresentacionArticulo].[Existencias]
	,[Sabor].[IdSabor]
	,[Categoria].[IdCategoria]
	,[Categoria].[IdCategoriaPadre]
	,[Categoria].[Nombre]
	,[PresentacionArticulo].[IdUnidadPresentacion] 
	,[UnidadPresentacion].[Nombre]
	,[PresentacionArticulo].[VlrUnidadPresentacion] 
	,[PresentacionArticulo].[PreOrden]
	,[Marca].[IdMarca]
	,[Marca].[Nombre]
	,[FechaProximoVencimiento]
	,[UsarFechaProximoVencimiento]
	,[UsarDescuento]
	,[UsarPorcentajeDescuento]
	,[ValorPorcentajeDescuento]
	,[UsarValorFijoDescuento]
	,[ValorFijoDescuento]
	,[FechaInicioDescuento]
	,[FechaFinalDescuento]
FROM [dbo].[PresentacionArticulo]
INNER JOIN [Articulo] ON [PresentacionArticulo].IdArticulo = [Articulo].IdArticulo
INNER JOIN [UnidadMasa]ON [UnidadMasa].IdUnidadMasa = [PresentacionArticulo].IdUnidadMasa
INNER JOIN [Sabor] ON [Sabor].IdSabor = [PresentacionArticulo].[IdSabor]
INNER JOIN [Talla] ON [Talla].IdTalla = [PresentacionArticulo].IdTalla
INNER JOIN [Color] ON [Color].IdColor = [PresentacionArticulo].IdColor
INNER JOIN [UnidadLongitud] ON [UnidadLongitud].IdUnidadLongitud = [PresentacionArticulo].IdUnidadLongitud
INNER JOIN [UnidadVolumen] ON [UnidadVolumen].IdUnidadVolumen = [PresentacionArticulo].IdUnidadVolumen
INNER JOIN [Categoria] ON [Categoria].[IdCategoria] = [Articulo].[IdCategoria]
INNER JOIN [UnidadPresentacion] ON [UnidadPresentacion].[IdUnidadPresentacion] = [PresentacionArticulo].[idUnidadPresentacion]
INNER JOIN [Marca] ON [Marca].[IdMarca] = [Articulo].[IdMarca]
WHERE [PresentacionArticulo].[Actualizar] = 1
GO

CREATE PROCEDURE [dbo].[PresentacionArticuloSelectPorCodigoEAN]
@CodigoEAN nvarchar(18)
AS
SELECT [IdPresentacionArticulo]
	,[IdArticulo]
	,[CodigoEAN]
	,[Nombre]
	,[DescripcionBreve]
	,[IdColor]
	,[IdTalla]
	,[Imagen1]
	,[Imagen2]
	,[Imagen3]
	,[Imagen4]
	,[Imagen5]
	,[Imagen6]
	,[Fecha]
	,[VlrUnidadMasa]
	,[VlrUnidadVolumenLargo]
	,[VlrUnidadVolumenAncho]
	,[VlrUnidadVolumenProfundidad]
	,[VlrContenidoVolumetrico]
	,[VlrUnidadLongitud]
	,[IdUnidadMasa]
	,[IdUnidadVolumen]
	,[IdUnidadLongitud]
	,[EnLinea]
	,[Activo]
	,[Precio]
	,[Existencias]
	,[IdSabor]
	,[CostoArticulo]
	,[PreOrden]
	,[IdUnidadPresentacion] 
	,[VlrUnidadPresentacion] 
	,[FechaProximoVencimiento]
	,[UsarFechaProximoVencimiento]
	,[UsarDescuento]
	,[UsarPorcentajeDescuento]
	,[ValorPorcentajeDescuento]
	,[UsarValorFijoDescuento]
	,[ValorFijoDescuento]
	,[FechaInicioDescuento]
	,[FechaFinalDescuento]
FROM [dbo].[PresentacionArticulo]
WHERE [CodigoEAN] = @CodigoEAN
GO

CREATE PROCEDURE [dbo].[PresentacionArticuloVerificarRelacionCarrito]
@IdPresentacionArticulo int
AS
SELECT TOP 1 IdPresentacionArticulo FROM [dbo].[Carrito] 
	WHERE [dbo].[Carrito].IdPresentacionArticulo = @IdPresentacionArticulo
GO

CREATE PROCEDURE [dbo].[PresentacionArticuloSelectPendientesActualizacion]
AS
SELECT [IdPresentacionArticulo]
	,[IdArticulo]
	,[CodigoEAN]
	,[PresentacionArticulo].[Nombre]
	,[DescripcionBreve]
	,[PresentacionArticulo].[IdColor]
	,[dbo].[Color].[Codigo]
	,[dbo].[Color].[Nombre]
	,[IdTalla]
	,[Imagen1]
	,[Imagen2]
	,[Imagen3]
	,[Imagen4]
	,[Imagen5]
	,[Imagen6]
	,[Fecha]
	,[VlrUnidadMasa]
	,[VlrUnidadVolumenLargo]
	,[VlrUnidadVolumenAncho]
	,[VlrUnidadVolumenProfundidad]
	,[VlrContenidoVolumetrico]
	,[VlrUnidadLongitud]
	,[IdUnidadMasa]
	,[IdUnidadVolumen]
	,[IdUnidadLongitud]
	,[EnLinea]
	,[Activo]
	,[Precio]
	,[Existencias]
	,[IdSabor]
	,[CostoArticulo]
	,[PreOrden]
	,[IdUnidadPresentacion]
	,[VlrUnidadPresentacion]
	,[FechaProximoVencimiento]
	,[UsarFechaProximoVencimiento]
	,[UsarDescuento]
	,[UsarPorcentajeDescuento]
	,[ValorPorcentajeDescuento]
	,[UsarValorFijoDescuento]
	,[ValorFijoDescuento]
	,[FechaInicioDescuento]
	,[FechaFinalDescuento]
FROM [dbo].[PresentacionArticulo]
INNER JOIN [dbo].[Color] ON [dbo].[Color].IdColor = [dbo].[PresentacionArticulo].IdColor
WHERE [PresentacionArticulo].[Actualizar] = 1
GO

CREATE PROCEDURE [dbo].[PresentacionArticuloSelectWebPorIdPresentacionArticulo]
@IdPresentacionArticulo int
AS
SELECT [IdPresentacionArticulo]
	,[PresentacionArticulo].[IdArticulo]
	,[PresentacionArticulo].[CodigoEAN]
	,[PresentacionArticulo].[Nombre]
	,[PresentacionArticulo].[DescripcionBreve]
	,[PresentacionArticulo].[IdColor]
	,[PresentacionArticulo].[IdTalla]
	,[PresentacionArticulo].[Imagen1]
	,[PresentacionArticulo].[Imagen2]
	,[PresentacionArticulo].[Imagen3]
	,[PresentacionArticulo].[Imagen4]
	,[PresentacionArticulo].[Imagen5]
	,[PresentacionArticulo].[Imagen6]
	,[PresentacionArticulo].[Fecha]
	,[PresentacionArticulo].[VlrUnidadMasa]
	,[PresentacionArticulo].[VlrUnidadVolumenLargo]
	,[PresentacionArticulo].[VlrUnidadVolumenAncho]
	,[PresentacionArticulo].[VlrUnidadVolumenProfundidad]
	,[PresentacionArticulo].[VlrUnidadLongitud]
	,[PresentacionArticulo].[IdUnidadMasa]
	,[PresentacionArticulo].[IdUnidadVolumen]
	,[PresentacionArticulo].[IdUnidadLongitud]
	,[PresentacionArticulo].[EnLinea]
	,[PresentacionArticulo].[Activo]
	,[PresentacionArticulo].[Precio]
	,[Articulo].[Titulo]
	,[UnidadMasa].Nombre
	,[Sabor].[Nombre]
	,[Talla].Nombre
	,[Color].Nombre
	,[UnidadLongitud].Nombre
	,[UnidadVolumen].Nombre
	,[PresentacionArticulo].[VlrContenidoVolumetrico]
	,[PresentacionArticulo].[Existencias]
	,[Sabor].[IdSabor]
	,[Categoria].[IdCategoria]
	,[Categoria].[IdCategoriaPadre]
	,[Categoria].[Nombre]
	,[PresentacionArticulo].[IdUnidadPresentacion] 
	,[UnidadPresentacion].[Nombre]
	,[PresentacionArticulo].[VlrUnidadPresentacion]
	,[PresentacionArticulo].[PreOrden]
	,[PresentacionArticulo].[FechaProximoVencimiento]
	,[Marca].[IdMarca]
	,[Marca].[Nombre]
	,[PresentacionArticulo].[UsarFechaProximoVencimiento]
	,[PresentacionArticulo].[UsarDescuento]
	,[PresentacionArticulo].[UsarPorcentajeDescuento]
	,[PresentacionArticulo].[ValorPorcentajeDescuento]
	,[PresentacionArticulo].[UsarValorFijoDescuento]
	,[PresentacionArticulo].[ValorFijoDescuento]
	,[PresentacionArticulo].[FechaInicioDescuento]
	,[PresentacionArticulo].[FechaFinalDescuento]
FROM [dbo].[PresentacionArticulo]
INNER JOIN [dbo].[Articulo] ON [dbo].[Articulo].IdArticulo = [dbo].[PresentacionArticulo].IdArticulo
INNER JOIN [dbo].[Marca] ON [dbo].[Marca].IdMarca = [dbo].[Articulo].IdMarca
INNER JOIN [dbo].[UnidadVolumen] ON [dbo].[UnidadVolumen].IdUnidadVolumen = [dbo].[PresentacionArticulo].IdUnidadVolumen
INNER JOIN [dbo].[UnidadMasa] ON [dbo].[UnidadMasa].IdUnidadMasa = [dbo].[PresentacionArticulo].IdUnidadMasa
INNER JOIN [dbo].[UnidadLongitud] ON [dbo].[UnidadLongitud].IdUnidadLongitud = [dbo].[PresentacionArticulo].IdUnidadLongitud
INNER JOIN [dbo].[Talla] ON [dbo].[Talla].IdTalla = [dbo].[PresentacionArticulo].IdTalla
INNER JOIN [dbo].[Color] ON [dbo].[Color].IdColor = [dbo].[PresentacionArticulo].IdColor
INNER JOIN [dbo].[Sabor] ON [dbo].[Sabor].IdSabor = [dbo].[PresentacionArticulo].IdSabor
INNER JOIN [dbo].[UnidadPresentacion] ON [dbo].[UnidadPresentacion].IdUnidadPresentacion = [dbo].[PresentacionArticulo].IdUnidadPresentacion
INNER JOIN [Categoria] ON [Categoria].[IdCategoria] = [Articulo].[IdCategoria]

WHERE [dbo].[PresentacionArticulo].[IdPresentacionArticulo] =  @IdPresentacionArticulo
GO

CREATE PROCEDURE PresentacionArticuloUpdateQuitarMarcaActualizar
	@IdPresentacionArticulo AS INT
AS
UPDATE [dbo].[PresentacionArticulo]
   SET Actualizar = 0
 WHERE IdPresentacionArticulo = @IdPresentacionArticulo
GO

CREATE PROCEDURE [dbo].[PresentacionArticuloUpdateStock]
	(@Cantidad int
	,@IdPresentacionArticulo int
	,@Activo bit)
AS
IF @Activo = 1
	BEGIN
		UPDATE [dbo].[PresentacionArticulo]
			SET [Existencias] = [Existencias] - @Cantidad
				,[Actualizar] = 1
				,[EnLinea] = 1
				,[Activo] = 1
		 WHERE [IdPresentacionArticulo] = @IdPresentacionArticulo
	 END
	 ELSE
	 BEGIN
		 UPDATE [dbo].[PresentacionArticulo]
			SET [Existencias] = [Existencias] - @Cantidad
				,[Actualizar] = 1
		 WHERE [IdPresentacionArticulo] = @IdPresentacionArticulo
	 END
GO

CREATE PROCEDURE [dbo].[PresentacionArticuloDescontarExistencias]
	@Cantidad int,
	@IdPresentacionArticulo int
AS
UPDATE [dbo].[PresentacionArticulo]
	SET 
		[Existencias] = @Cantidad - 1  
	WHERE [IdPresentacionArticulo] = @IdPresentacionArticulo
GO

CREATE PROCEDURE [dbo].[PresentacionArticuloIncrementarExistencias]
	@Cantidad int,
	@IdPresentacionArticulo int
AS
UPDATE [dbo].[PresentacionArticulo]
	SET 
		[Existencias] = @Cantidad + 1  
	WHERE [IdPresentacionArticulo] = @IdPresentacionArticulo
GO

 CREATE PROCEDURE [dbo].[PresentacionArticuloUpdateEnLinea]
	(@IdArticulo int
	,@EnLinea bit)
AS
UPDATE [dbo].[PresentacionArticulo]
	SET 
		EnLinea = @EnLinea
		,[Actualizar] = 1
	WHERE [IdArticulo] = @IdArticulo
GO

 CREATE PROCEDURE [dbo].[PresentacionArticuloUpdatePreOrden]
	(@IdArticulo int
	,@PreOrden bit)
AS
	UPDATE [dbo].[PresentacionArticulo]
	SET 
		[PreOrden] = @PreOrden
		,[Actualizar] = 1
	WHERE [IdArticulo] = @IdArticulo
GO

CREATE PROCEDURE [dbo].[PresentacionArticuloSelectWebPorIdArticulo]
	@IdArticulo int
AS
SELECT [IdPresentacionArticulo]
	,[PresentacionArticulo].[IdArticulo]
	,[PresentacionArticulo].[CodigoEAN]
	,[PresentacionArticulo].[Nombre]
	,[PresentacionArticulo].[DescripcionBreve]
	,[PresentacionArticulo].[IdColor]
	,[PresentacionArticulo].[IdTalla]
	,[PresentacionArticulo].[Imagen1]
	,[PresentacionArticulo].[Imagen2]
	,[PresentacionArticulo].[Imagen3]
	,[PresentacionArticulo].[Imagen4]
	,[PresentacionArticulo].[Imagen5]
	,[PresentacionArticulo].[Imagen6]
	,[PresentacionArticulo].[Fecha]
	,[PresentacionArticulo].[VlrUnidadMasa]
	,[PresentacionArticulo].[VlrUnidadVolumenLargo]
	,[PresentacionArticulo].[VlrUnidadVolumenAncho]
	,[PresentacionArticulo].[VlrUnidadVolumenProfundidad]
	,[PresentacionArticulo].[VlrUnidadLongitud]
	,[PresentacionArticulo].[IdUnidadMasa]
	,[PresentacionArticulo].[IdUnidadVolumen]
	,[PresentacionArticulo].[IdUnidadLongitud]
	,[PresentacionArticulo].[EnLinea]
	,[PresentacionArticulo].[Activo]
	,[PresentacionArticulo].[Precio]
	,[Articulo].[Titulo]
	,[UnidadMasa].Nombre
	,[Sabor].[Nombre]
	,[Talla].Nombre
	,[Color].Nombre
	,[UnidadLongitud].Nombre
	,[UnidadVolumen].Nombre
	,[PresentacionArticulo].[VlrContenidoVolumetrico]
	,[PresentacionArticulo].[Existencias]
	,[Sabor].[IdSabor]
	,[Categoria].[IdCategoria]
	,[Categoria].[IdCategoriaPadre]
	,[Categoria].[Nombre]
	,[PresentacionArticulo].[IdUnidadPresentacion] 
	,[UnidadPresentacion].[Nombre]
	,[PresentacionArticulo].[VlrUnidadPresentacion]
	,[PresentacionArticulo].[PreOrden]
	,[Marca].[IdMarca]
	,[Marca].[Nombre]
	,[FechaProximoVencimiento]
	,[UsarFechaProximoVencimiento]
	,[UsarDescuento]
	,[UsarPorcentajeDescuento]
	,[ValorPorcentajeDescuento]
	,[UsarValorFijoDescuento]
	,[ValorFijoDescuento]
	,[FechaInicioDescuento]
	,[FechaFinalDescuento]
FROM [dbo].[PresentacionArticulo]
INNER JOIN [Articulo] ON [PresentacionArticulo].IdArticulo = [Articulo].IdArticulo
INNER JOIN [UnidadMasa]ON [UnidadMasa].IdUnidadMasa = [PresentacionArticulo].IdUnidadMasa
INNER JOIN [Sabor] ON [Sabor].IdSabor = [PresentacionArticulo].[IdSabor]
INNER JOIN [Talla] ON [Talla].IdTalla = [PresentacionArticulo].IdTalla
INNER JOIN [Color] ON [Color].IdColor = [PresentacionArticulo].IdColor
INNER JOIN [UnidadLongitud] ON [UnidadLongitud].IdUnidadLongitud = [PresentacionArticulo].IdUnidadLongitud
INNER JOIN [UnidadVolumen] ON [UnidadVolumen].IdUnidadVolumen = [PresentacionArticulo].IdUnidadVolumen
INNER JOIN [Categoria] ON [Categoria].[IdCategoria] = [Articulo].[IdCategoria]
INNER JOIN [UnidadPresentacion] ON [UnidadPresentacion].[IdUnidadPresentacion] = [PresentacionArticulo].[idUnidadPresentacion]
INNER JOIN [Marca] ON [Marca].[IdMarca] = [Articulo].[IdMarca]
WHERE [PresentacionArticulo].[Activo] = 1 AND [PresentacionArticulo].[EnLinea] = 1 AND [PresentacionArticulo].[Existencias] > 0 and [PresentacionArticulo].[IdArticulo] =  @IdArticulo
ORDER BY IdPresentacionArticulo
GO

CREATE PROCEDURE [dbo].[PresentacionArticuloSelectPorIdPresentacionArticulo]
@IdPresentacionArticulo int
AS
SELECT [IdPresentacionArticulo]
	,[PresentacionArticulo].[IdArticulo]
	,[PresentacionArticulo].[CodigoEAN]
	,[PresentacionArticulo].[Nombre]
	,[PresentacionArticulo].[DescripcionBreve]
	,[PresentacionArticulo].[IdColor]
	,[PresentacionArticulo].[IdTalla]
	,[PresentacionArticulo].[Imagen1]
	,[PresentacionArticulo].[Imagen2]
	,[PresentacionArticulo].[Imagen3]
	,[PresentacionArticulo].[Imagen4]
	,[PresentacionArticulo].[Imagen5]
	,[PresentacionArticulo].[Imagen6]
	,[PresentacionArticulo].[Fecha]
	,[PresentacionArticulo].[VlrUnidadMasa]
	,[PresentacionArticulo].[VlrUnidadVolumenLargo]
	,[PresentacionArticulo].[VlrUnidadVolumenAncho]
	,[PresentacionArticulo].[VlrUnidadVolumenProfundidad]
	,[PresentacionArticulo].[VlrUnidadLongitud]
	,[PresentacionArticulo].[IdUnidadMasa]
	,[PresentacionArticulo].[IdUnidadVolumen]
	,[PresentacionArticulo].[IdUnidadLongitud]
	,[PresentacionArticulo].[EnLinea]
	,[PresentacionArticulo].[Activo]
	,[PresentacionArticulo].[Precio]
	,[Articulo].[Titulo]
	,[UnidadMasa].Nombre
	,[Sabor].[Nombre]
	,[Talla].Nombre
	,[Color].Nombre
	,[UnidadLongitud].Nombre
	,[UnidadVolumen].Nombre
	,[PresentacionArticulo].[VlrContenidoVolumetrico]
	,[PresentacionArticulo].[Existencias]
	,[Sabor].[IdSabor]
	,[Categoria].[IdCategoria]
	,[Categoria].[IdCategoriaPadre]
	,[Categoria].[Nombre]
	,[PresentacionArticulo].[IdUnidadPresentacion] 
	,[UnidadPresentacion].[Nombre]
	,[PresentacionArticulo].[VlrUnidadPresentacion] 
	,[PresentacionArticulo].[PreOrden]
	,[Marca].[IdMarca]
	,[Marca].[Nombre]
	,[FechaProximoVencimiento]
	,[UsarFechaProximoVencimiento]
	,[UsarDescuento]
	,[UsarPorcentajeDescuento]
	,[ValorPorcentajeDescuento]
	,[UsarValorFijoDescuento]
	,[ValorFijoDescuento]
	,[FechaInicioDescuento]
	,[FechaFinalDescuento]
FROM [dbo].[PresentacionArticulo]
INNER JOIN [Articulo] ON [PresentacionArticulo].IdArticulo = [Articulo].IdArticulo
INNER JOIN [UnidadMasa]ON [UnidadMasa].IdUnidadMasa = [PresentacionArticulo].IdUnidadMasa
INNER JOIN [Sabor] ON [Sabor].IdSabor = [PresentacionArticulo].[IdSabor]
INNER JOIN [Talla] ON [Talla].IdTalla = [PresentacionArticulo].IdTalla
INNER JOIN [Color] ON [Color].IdColor = [PresentacionArticulo].IdColor
INNER JOIN [UnidadLongitud] ON [UnidadLongitud].IdUnidadLongitud = [PresentacionArticulo].IdUnidadLongitud
INNER JOIN [UnidadVolumen] ON [UnidadVolumen].IdUnidadVolumen = [PresentacionArticulo].IdUnidadVolumen
INNER JOIN [Categoria] ON [Categoria].[IdCategoria] = [Articulo].[IdCategoria]
INNER JOIN [UnidadPresentacion] ON [UnidadPresentacion].[IdUnidadPresentacion] = [PresentacionArticulo].[idUnidadPresentacion]
INNER JOIN [Marca] ON [Marca].[IdMarca] = [Articulo].[IdMarca]
WHERE [dbo].[PresentacionArticulo].[IdPresentacionArticulo] =  @IdPresentacionArticulo
GO

CREATE PROCEDURE [dbo].[PresentacionArticuloSelectExistencias]
	(@IdPresentacionArticulo int)
AS 
SELECT [Existencias] FROM [dbo].[PresentacionArticulo]
WHERE IdPresentacionArticulo = @IdPresentacionArticulo
GO