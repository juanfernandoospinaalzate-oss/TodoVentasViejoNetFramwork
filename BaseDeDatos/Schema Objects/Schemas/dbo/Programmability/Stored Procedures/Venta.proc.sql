CREATE PROCEDURE [dbo].[VentaConsultarParaVentaSelect]
@IdUsuario int
AS
SELECT DISTINCT
0 AS IdVenta,
0 AS NroFactura,
[dbo].[Cliente].IdCliente, 
[dbo].[Cliente].DocCliente, 
[dbo].[Cliente].Nombre,
[dbo].[Cliente].Apellido, 
[dbo].[Cliente].Telefono1, 
[dbo].[Cliente].Telefono2, 
[dbo].[Cliente].EMail, 
[dbo].[Cliente].Contrasena,
'Reemplazar por Nombre Destinatario seleccionado' AS NombreDestinatario,
'Reemplazar por direccion seleccionada' AS DireccionEnvio,
'Reemplazar por Telefono seleccionado' AS Telefono,
'Reemplazar por Nombre Pais seleccionado' AS NombrePais,
'Reemplazar por Nombre Departamento seleccionado' AS NombreDepartamento,
'Reemplazar por Nombre Ciudad seleccionado' AS NombreCiudad,
GETDATE() AS Fecha,
0 AS CodigoReferenciaPayU,
'Reemplazar por medio de pago' AS MedioDePago,
'0' AS TotalVenta,
'0' AS TotalCosto,
'Reemplazar por el Nro. de guia' AS NroGuia,
0 AS CostoFlete,
'false' AS Anulado
FROM [dbo].[Carrito]
INNER JOIN [dbo].[Cliente] ON [dbo].[Cliente].IdCliente = [dbo].[Carrito].IdUsuario
INNER JOIN [dbo].[PresentacionArticulo] ON [dbo].[PresentacionArticulo].IdPresentacionArticulo = [dbo].[Carrito].IdPresentacionArticulo
WHERE [dbo].[Cliente].IdCliente = @IdUsuario
GO

CREATE PROCEDURE [dbo].[DetalleVentaConsultarParaDetalleVentaSelect]
@IdUsuario int
AS
SELECT 0 AS IdDetalleVenta,
0 AS IdVenta,
[dbo].[Cliente].IdCliente,
[dbo].[Marca].Nombre AS 'Nombre Marca',
[dbo].[Articulo].Titulo,
[dbo].[UnidadVolumen].Nombre AS 'NombreUnidadVolumen',
[dbo].[PresentacionArticulo].VlrUnidadVolumenLargo AS 'VlrVolumenLargo',
[dbo].[PresentacionArticulo].VlrUnidadVolumenAncho AS 'VlrVolumenAncho',
[dbo].[PresentacionArticulo].VlrUnidadVolumenProfundidad AS 'VlrVolumenProfundidad',
[dbo].[PresentacionArticulo].VlrContenidoVolumetrico AS 'VlrContenidoVolumetrico',
[dbo].[UnidadMasa].Nombre AS 'NombreUnidadMasa',
[dbo].[PresentacionArticulo].VlrUnidadMasa AS 'VlrUnidadMasa',
[dbo].[UnidadLongitud].Nombre AS 'NombreUnidadLongitud',
[dbo].[PresentacionArticulo].VlrUnidadLongitud,
[dbo].[Talla].Nombre AS 'NombreTalla',
[dbo].[Color].Nombre AS 'NombreColor',
[dbo].[Sabor].Nombre AS 'NombreSabor',
[dbo].[PresentacionArticulo].Precio AS 'PrecioVenta',
[dbo].[Carrito].Cantidad,
'0' AS CostoDelProducto,
'0' AS SubTotalVenta,
'0' AS SubtotalCosto,
'Reemplazar por Nombre de Categoria' AS NombreCategoria,
'Reemplazar por camino subcategoria' AS CaminoSubCategorias,
[dbo].[PresentacionArticulo].[IdPresentacionArticulo]
FROM [dbo].[Carrito]
INNER JOIN [dbo].[Cliente] ON [dbo].[Cliente].IdCliente = [dbo].[Carrito].IdUsuario
INNER JOIN [dbo].[PresentacionArticulo] ON [dbo].[PresentacionArticulo].IdPresentacionArticulo = [dbo].[Carrito].IdPresentacionArticulo 
INNER JOIN [dbo].[Articulo] ON [dbo].[Articulo].IdArticulo = [dbo].[PresentacionArticulo].IdArticulo 
INNER JOIN [dbo].[Marca] ON [dbo].[Marca].IdMarca = [dbo].[Articulo].IdMarca
INNER JOIN [dbo].[UnidadVolumen] ON [dbo].[UnidadVolumen].IdUnidadVolumen = [dbo].[PresentacionArticulo].IdUnidadVolumen
INNER JOIN [dbo].[UnidadMasa] ON [dbo].[UnidadMasa].IdUnidadMasa = [dbo].[PresentacionArticulo].IdUnidadMasa  
INNER JOIN [dbo].[UnidadLongitud] ON [dbo].[UnidadLongitud].IdUnidadLongitud = [dbo].[PresentacionArticulo].IdUnidadLongitud
INNER JOIN [dbo].[Talla] ON [dbo].[Talla].IdTalla = [dbo].[PresentacionArticulo].IdTalla
INNER JOIN [dbo].[Color] ON [dbo].[Color].IdColor = [dbo].[PresentacionArticulo].[IdColor]
INNER JOIN [dbo].[Sabor] ON [dbo].[Sabor].IdSabor = [dbo].[PresentacionArticulo].[IdSabor]
WHERE [dbo].[Cliente].IdCliente = @IdUsuario
GO

CREATE PROCEDURE [dbo].[VentaInsert]
@NroFactura int,
@IdCliente int,
@DocCliente int,
@NombreCliente  nvarchar(30),
@ApellidoCliente nvarchar(30),
@TelefonoClienteUno nvarchar(20),
@TelefonoClienteDos nvarchar(20),
@EmailCliente nvarchar(50),
@ContrasenaCliente nvarchar(50),
@NombreDestinatario nvarchar(30),
@DireccionEnvioDestinatario nvarchar(80),
@TelefonoDestinatario nvarchar(20),
@NombrePaisDestinatario nvarchar(42),
@NombreDepartamentoDestinatario nvarchar(42),
@NombreCiudadDestinatario nvarchar(42),
@Fecha date,
@CodigoReferenciaPayU int,
@MedioDePago nvarchar(60),
@TotalVenta float,
@TotalCosto float,
@NroGuia nvarchar(20),
@CostoFlete int,
@Anulado bit,
@EstadoVenta nvarchar(50),
@OutIdVenta int OUTPUT
AS
INSERT INTO [dbo].[Venta]
([NroFactura]
,[IdCliente]
,[DocCliente]
,[NombreCliente]
,[ApellidoCliente]
,[TelefonoClienteUno]
,[TelefonoClienteDos]
,[EmailCliente]
,[ContrasenaCliente]
,[NombreDestinatario]
,[DireccionEnvioDestinatario]
,[TelefonoDestinatario]
,[NombrePaisDestinatario]
,[NombreDepartamentoDestinatario]
,[NombreCiudadDestinatario]
,[Fecha]
,[CodigoReferenciaPayU]
,[MedioDePago]
,[TotalVenta]
,[TotalCosto]
,[NroGuia]
,[CostoFlete]
,[Anulado]
,[EstadoDeLaVenta])
VALUES
(@NroFactura,
@IdCliente,
@DocCliente, 
@NombreCliente,
@ApellidoCliente,
@TelefonoClienteUno,
@TelefonoClienteDos,
@EmailCliente,
@ContrasenaCliente,
@NombreDestinatario,
@DireccionEnvioDestinatario,
@TelefonoDestinatario, 
@NombrePaisDestinatario,
@NombreDepartamentoDestinatario,
@NombreCiudadDestinatario,
@Fecha,
@CodigoReferenciaPayU,
@MedioDePago,
@TotalVenta,
@TotalCosto,
@NroGuia,
@CostoFlete,
@Anulado,
@EstadoVenta)

SET @OutIdVenta = SCOPE_IDENTITY();
GO

CREATE PROCEDURE [dbo].[DetalleVentaInsert]
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
INSERT INTO [dbo].[DetalleVenta]
([IdVenta]
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

CREATE PROCEDURE [dbo].[VentaEliminarPorIdUsuarioDelCarrito]
@IdUsuario int
AS
DELETE FROM [dbo].[Carrito]
WHERE [IdUsuario] = @IdUsuario
GO

CREATE PROCEDURE [dbo].[VentaConsultarModoInvitadoSelect]
AS
SELECT DISTINCT
0 AS IdVenta,
0 AS NroFactura,
[dbo].[Cliente].IdCliente, 
[dbo].[Cliente].DocCliente, 
[dbo].[Cliente].Nombre,
[dbo].[Cliente].Apellido, 
[dbo].[Cliente].Telefono1, 
[dbo].[Cliente].Telefono2, 
[dbo].[Cliente].EMail, 
[dbo].[Cliente].Contrasena,
'Reemplazar por Nombre Destinatario seleccionado' AS NombreDestinatario,
'Reemplazar por direccion seleccionada' AS DireccionEnvio,
'Reemplazar por Telefono seleccionado' AS Telefono,
'Reemplazar por Nombre Pais seleccionado' AS NombrePais,
'Reemplazar por Nombre Departamento seleccionado' AS NombreDepartamento,
'Reemplazar por Nombre Ciudad seleccionado' AS NombreCiudad,
GETDATE() AS Fecha,
0 AS CodigoReferenciaPayU,
'Reemplazar por medio de pago' AS MedioDePago,
'0' AS TotalVenta,
'0' AS TotalCosto,
'Reemplazar por el Nro. de guia' AS NroGuia,
0 AS CostoFlete,
'false' AS Anulado
FROM [dbo].[Cliente]
GO

CREATE PROCEDURE [dbo].[DetalleVentaConsultarModoInvitadoSelect]
AS
SELECT 0 AS IdDetalleVenta,
0 AS IdVenta,
[dbo].[Cliente].IdCliente,
[dbo].[Marca].Nombre AS 'Nombre Marca',
[dbo].[Articulo].Titulo,
[dbo].[UnidadVolumen].Nombre AS 'NombreUnidadVolumen',
[dbo].[PresentacionArticulo].VlrUnidadVolumenLargo AS 'VlrVolumenLargo',
[dbo].[PresentacionArticulo].VlrUnidadVolumenAncho AS 'VlrVolumenAncho',
[dbo].[PresentacionArticulo].VlrUnidadVolumenProfundidad AS 'VlrVolumenProfundidad',
[dbo].[PresentacionArticulo].VlrContenidoVolumetrico AS 'VlrContenidoVolumetrico',
[dbo].[UnidadMasa].Nombre AS 'NombreUnidadMasa',
[dbo].[PresentacionArticulo].VlrUnidadMasa AS 'VlrUnidadMasa',
[dbo].[UnidadLongitud].Nombre AS 'NombreUnidadLongitud',
[dbo].[PresentacionArticulo].VlrUnidadLongitud,
[dbo].[Talla].Nombre AS 'NombreTalla',
[dbo].[Color].Nombre AS 'NombreColor',
[dbo].[Sabor].Nombre AS 'NombreSabor',
[dbo].[PresentacionArticulo].Precio AS 'PrecioVenta',
[dbo].[Carrito].Cantidad,
'0' AS CostoDelProducto,
'0' AS SubTotalVenta,
'0' AS SubtotalCosto,
'Reemplazar por Nombre de Categoria' AS NombreCategoria,
'Reemplazar por camino subcategoria' AS CaminoSubCategorias,
[dbo].[PresentacionArticulo].[IdPresentacionArticulo]
FROM [dbo].[Carrito]
INNER JOIN [dbo].[Cliente] ON [dbo].[Cliente].IdCliente = [dbo].[Carrito].IdUsuario
INNER JOIN [dbo].[PresentacionArticulo] ON [dbo].[PresentacionArticulo].IdPresentacionArticulo = [dbo].[Carrito].IdPresentacionArticulo 
INNER JOIN [dbo].[Articulo] ON [dbo].[Articulo].IdArticulo = [dbo].[PresentacionArticulo].IdArticulo 
INNER JOIN [dbo].[Marca] ON [dbo].[Marca].IdMarca = [dbo].[Articulo].IdMarca
INNER JOIN [dbo].[UnidadVolumen] ON [dbo].[UnidadVolumen].IdUnidadVolumen = [dbo].[PresentacionArticulo].IdUnidadVolumen
INNER JOIN [dbo].[UnidadMasa] ON [dbo].[UnidadMasa].IdUnidadMasa = [dbo].[PresentacionArticulo].IdUnidadMasa  
INNER JOIN [dbo].[UnidadLongitud] ON [dbo].[UnidadLongitud].IdUnidadLongitud = [dbo].[PresentacionArticulo].IdUnidadLongitud
INNER JOIN [dbo].[Talla] ON [dbo].[Talla].IdTalla = [dbo].[PresentacionArticulo].IdTalla
INNER JOIN [dbo].[Color] ON [dbo].[Color].IdColor = [dbo].[PresentacionArticulo].[IdColor]
INNER JOIN [dbo].[Sabor] ON [dbo].[Sabor].IdSabor = [dbo].[PresentacionArticulo].[IdSabor]
GO

