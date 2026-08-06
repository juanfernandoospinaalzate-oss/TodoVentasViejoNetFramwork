CREATE PROCEDURE [dbo].[OrdenesCompraDetalleSelect]
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
      ,AbonoDesdeFacturacion
  FROM DetalleAlbaran

END
