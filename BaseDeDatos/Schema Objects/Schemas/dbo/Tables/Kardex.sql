CREATE TABLE [Kardex]
(
	[Id] INT IDENTITY(1,1) NOT NULL, 
    [IdPresentacionArticulo] INT NOT NULL, 
    [Fecha] DATETIME NOT NULL, 
    [Nombre] NVARCHAR(100) NOT NULL, 
    [CantidadEntrada] INT NOT NULL, 
	[CantidadSalida] INT NOT NULL, 
    [PrecioUnitario] FLOAT NOT NULL, 
    [CostoUnitario] FLOAT NOT NULL, 
    [TotalExistencias] INT NOT NULL, 
    [PrecioTotal] FLOAT NOT NULL, 
    [CostoTotal] FLOAT NOT NULL,
	[Detalle] NVARCHAR (100) NOT NULL
)

GO
