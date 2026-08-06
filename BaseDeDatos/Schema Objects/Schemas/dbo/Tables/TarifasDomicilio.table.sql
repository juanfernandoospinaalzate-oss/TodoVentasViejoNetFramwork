CREATE TABLE [dbo].[TarifasDomicilio]
(
	[IdTarifasDomicilio] [int] IDENTITY(1,1) NOT NULL,
	[TarifaDomicilioNuevo] [nvarchar](50) NOT NULL,
	[ValorDomicilio] [float] NOT NULL, 
    CONSTRAINT [PK_TarifasDomicilio] PRIMARY KEY ([IdTarifasDomicilio])
)
