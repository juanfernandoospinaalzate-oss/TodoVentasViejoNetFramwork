CREATE TABLE [dbo].[Carrito]
(
	IdItemCarrito int IDENTITY(1,1) NOT NULL, 
	IdUsuario int NOT NULL,
	IdPresentacionArticulo  int NOT NULL,
	Cantidad int NOT NULL
)
