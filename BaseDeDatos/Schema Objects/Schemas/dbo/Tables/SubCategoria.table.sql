CREATE TABLE [dbo].[SubCategoria]
(
	IdSubCategoria int IDENTITY(1,1) NOT NULL, 
	IdCategoria int NOT NULL,
	Nombre nvarchar(60) NOT NULL,
	Descripcion nvarchar(250) NOT NULL
)
