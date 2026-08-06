CREATE PROCEDURE [dbo].[OrdenesCompraEncabezadoSelect]
AS
BEGIN
	SELECT
		NombreCliente,
		ApellidoCliente,
		DocCliente,
		NroFactura,
		Fecha,
		MedioDePago,
		TotalVenta,
		IdAlbaran
	FROM Albaran
END
