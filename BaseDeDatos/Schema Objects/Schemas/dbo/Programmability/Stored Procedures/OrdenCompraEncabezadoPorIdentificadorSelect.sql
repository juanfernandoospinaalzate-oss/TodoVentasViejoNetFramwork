CREATE PROCEDURE [dbo].[OrdenCompraEncabezadoPorIdentificadorSelect]
	@Identificador INT,
	@Opcion INT,
    @OutIdAlbaran INT OUT 
AS
DECLARE @CantidadElementosRetorno INT
BEGIN
	IF(@Opcion = 1) 
	BEGIN
		
		SET @CantidadElementosRetorno = ( SELECT COUNT(*) FROM Albaran WHERE NroFactura = @Identificador )

		IF  @CantidadElementosRetorno = 1  
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
				WHERE NroFactura = @Identificador

				SET @OutIdAlbaran = (SELECT A.IdAlbaran FROM Albaran A WHERE A.NroFactura = @Identificador)
			END
		ELSE
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
				WHERE NroFactura = @Identificador
			END

	END

	IF(@Opcion = 2) 
	BEGIN
		SET @CantidadElementosRetorno = ( SELECT COUNT(*) FROM Albaran WHERE DocCliente = @Identificador )

		IF  @CantidadElementosRetorno = 1  
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
				WHERE DocCliente = @Identificador

				SET @OutIdAlbaran = (SELECT A.IdAlbaran FROM Albaran A WHERE A.NroFactura = @Identificador)
			END
		ELSE
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
				WHERE DocCliente = @Identificador
			END
	END	
END