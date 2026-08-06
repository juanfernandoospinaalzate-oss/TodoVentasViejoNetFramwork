CREATE PROCEDURE [dbo].[AlbaranInsert]
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
	@TotalVenta float,
	@TotalCosto float,
	@NroGuia nvarchar(20),
	@CostoFlete int,
	@Anulado bit,
	@OutIdAlbaran int OUTPUT
AS
INSERT INTO [dbo].[Albaran]
	([IdCliente]
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
	,[TotalVenta]
	,[TotalCosto]
	,[NroGuia]
	,[CostoFlete]
	,[Anulado])
VALUES
	(@IdCliente,
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
	@TotalVenta,
	@TotalCosto,
	@NroGuia,
	@CostoFlete,
	@Anulado)

SET @OutIdAlbaran = SCOPE_IDENTITY();
GO
