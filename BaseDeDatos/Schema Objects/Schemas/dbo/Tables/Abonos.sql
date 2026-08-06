CREATE TABLE [dbo].[Abonos]
(
	[IdAbono] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [IdAlbaran] INT NOT NULL, 
    [ValorAbono] FLOAT NOT NULL, 
	[Fecha] DATETIME NOT NULL,
    [MedioDePago] NVARCHAR(50) NOT NULL,
	[NroFactura] [int] NOT NULL
)
