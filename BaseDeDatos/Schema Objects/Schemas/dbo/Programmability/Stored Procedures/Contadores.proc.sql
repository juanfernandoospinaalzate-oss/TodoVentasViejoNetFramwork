CREATE PROCEDURE [dbo].[ContadoresGenerarCodigoReferenciaPayU]
AS
	UPDATE [dbo].[Contadores]
		SET [codigoReferenciaPayU] = [codigoReferenciaPayU] + 1
	WHERE [IdContadores] = 1

	SELECT CAST([codigoReferenciaPayU] AS INT) FROM [dbo].[Contadores] WHERE [IdContadores] = 1 
GO

CREATE PROCEDURE [dbo].[ContadoresGenerarNumeroFactura]
AS
	UPDATE [dbo].[Contadores]
		SET [NroFactura]= [NroFactura] + 1
	WHERE [IdContadores] = 1

	SELECT CAST([NroFactura] AS INT) FROM [dbo].[Contadores] WHERE [IdContadores] = 1 
GO