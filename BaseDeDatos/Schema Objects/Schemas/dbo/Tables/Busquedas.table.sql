CREATE TABLE [dbo].[Busquedas]
(
	[IdBusqueda] INT IDENTITY(1,1) NOT NULL, 
    [Texto] NVARCHAR(250) NOT NULL, 
    [ContadorBusquedas] INT NOT NULL, 
    [Eliminado] BIT NOT NULL,
	[Aprobado] BIT NOT NULL
)
