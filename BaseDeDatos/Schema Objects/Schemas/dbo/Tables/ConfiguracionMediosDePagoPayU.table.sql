
CREATE TABLE [dbo].[ConfiguracionMediosDePagoPayU]
(
	IdConfiguracionMediosDePagoPayU int IDENTITY(1,1) NOT NULL, 
	ValorMinimoEfecty int NOT NULL,
	ValorMinimoBaloto int NOT NULL,
	ValorMinimoTarjetaCredito int NOT NULL,
	ValorMinimoCuentaAhorro int NOT NULL
)