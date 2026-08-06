CREATE PROCEDURE [dbo].[OrdenesCompraDetallePorIdentificadorSelect]
	@IdAlbaran INT
AS
BEGIN

	SELECT NombreMarca
      ,Titulo
      ,NombreUnidadVolumen
      ,NombreUnidadMasa
      ,NombreUnidadLongitud
      ,NombreTalla
      ,NombreColor
      ,NombreSabor
      ,PrecioVenta
      ,Cantidad
      ,CostoDelProducto
      ,SubTotalVenta
      ,SubtotalCosto
      ,NombreCategoria
      ,NombreUnidadPresentacion
      ,IdPresentacionArticulo
	 FROM DetalleAlbaran WHERE IdAlbaran = @IdAlbaran

END