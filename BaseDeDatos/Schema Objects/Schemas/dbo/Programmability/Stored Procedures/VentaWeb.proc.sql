CREATE PROCEDURE [dbo].[VentaWebInsert]
	@NroFactura int,
	@IdCliente int,
	@DocCliente int,
	@NombreCliente  nvarchar(30),
	@ApellidoCliente nvarchar(30),
	@TelefonoClienteUno nvarchar(20),
	@TelefonoClienteDos nvarchar(20),
	@EmailCliente nvarchar(50),
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
	@OutIdVentaWeb int OUTPUT
AS
INSERT INTO [dbo].[VentaWeb]
	([NroFactura]
	,[IdCliente]
	,[DocCliente]
	,[NombreCliente]
	,[ApellidoCliente]
	,[TelefonoClienteUno]
	,[TelefonoClienteDos]
	,[EmailCliente]
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

SET @OutIdVentaWeb = SCOPE_IDENTITY();
GO

GO
