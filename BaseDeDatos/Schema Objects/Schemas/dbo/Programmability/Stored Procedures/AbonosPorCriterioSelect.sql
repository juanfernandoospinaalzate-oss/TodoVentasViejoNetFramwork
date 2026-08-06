CREATE PROCEDURE [dbo].[AbonosPorCriterioSelect] 
	@CriterioBusqueda NVARCHAR(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
  SELECT [IdAbono]
      ,AB.[IdAlbaran]
      ,[ValorAbono]
      ,AB.[Fecha]
      ,AB.[MedioDePago]
	  ,AL.NroFactura
	  ,AL.NombreCliente +' ' + AL.ApellidoCliente as NombreCompletoCliente
  FROM [TodoVentas].[dbo].[Abonos] AB
  INNER JOIN Albaran AL
  ON AB.IdAlbaran = AL.IdAlbaran
  WHERE AL.NroFactura = @CriterioBusqueda
END
