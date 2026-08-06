CREATE PROCEDURE [dbo].[ConfiguracionFacturaInsert] 	
@TextoPieDePagina nvarchar(250),
@NroFactura int
AS
INSERT INTO [dbo].[ConfiguracionFactura]([TextoPieDePagina], [NroFactura])
								  VALUES(@TextoPieDePagina, @NroFactura)
GO

CREATE PROCEDURE [dbo].[ConfiguracionFacturaUpdate]
(@TextoPieDePagina nvarchar(250)
,@NroFactura int)
AS
UPDATE [dbo].[Contadores]
   SET [NroFactura] = @NroFactura
GO
