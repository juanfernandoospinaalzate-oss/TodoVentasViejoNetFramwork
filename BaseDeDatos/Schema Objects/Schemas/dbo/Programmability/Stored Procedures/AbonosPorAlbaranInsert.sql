CREATE PROCEDURE [dbo].[AbonosPorAlbaranInsert]
@IdAlbaran int, 	
@ValorAbono float,
@MedioDePago nvarchar (50),
@NroFactura int
AS
DECLARE @TotalVenta varchar(50)
SELECT @TotalVenta = [TotalVenta] FROM [dbo].[Albaran] WHERE [IdAlbaran] = @IdAlbaran;

IF(@ValorAbono <= @TotalVenta) 
BEGIN
	INSERT INTO [dbo].[Abonos]([IdAlbaran],[ValorAbono],[Fecha],[MedioDePago], [NroFactura])VALUES(@IdAlbaran,@ValorAbono, GETDATE(), @MedioDePago, @NroFactura)
END