CREATE TABLE [dbo].[ConfiguracionFactura]
(
	IdAlmacen int IDENTITY(1,1) NOT NULL, 
	TextoPieDePagina nvarchar(250) NOT NULL, 
    [NroFactura] INT NOT NULL
)
