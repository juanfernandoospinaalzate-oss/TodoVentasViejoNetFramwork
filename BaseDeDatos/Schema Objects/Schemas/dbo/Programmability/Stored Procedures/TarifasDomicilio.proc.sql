CREATE PROCEDURE [dbo].[TarifasDomicilioInsert] 	
@TarifaDomicilioNuevo nvarchar(50),
@ValorDomicilio float
AS
INSERT INTO [dbo].[TarifasDomicilio]([TarifaDomicilioNuevo],[ValorDomicilio])VALUES(@TarifaDomicilioNuevo,@ValorDomicilio)
GO
CREATE PROCEDURE [dbo].[TarifasDomicilioSelect]
AS
SELECT [IdTarifasDomicilio],
[TarifaDomicilioNuevo],
[ValorDomicilio]
FROM [dbo].[TarifasDomicilio]
GO
CREATE PROCEDURE [dbo].[TarifasDomicilioUpdate]
(@IdTarifasDomicilio int,
@TarifaDomicilioNuevo nvarchar(20),
@ValorDomicilio float)
AS
UPDATE [dbo].[TarifasDomicilio]
   SET [TarifaDomicilioNuevo] = @TarifaDomicilioNuevo,
	   [ValorDomicilio] = @ValorDomicilio
 WHERE [IdTarifasDomicilio] = @IdTarifasDomicilio
GO
CREATE PROCEDURE [dbo].[TarifasDomicilioDelete]
@IdTarifasDomicilio int
AS
DELETE FROM [dbo].[TarifasDomicilio]
WHERE [IdTarifasDomicilio] = @IdTarifasDomicilio