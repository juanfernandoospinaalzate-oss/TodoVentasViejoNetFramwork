CREATE TABLE [dbo].[Categoria]
(
	IdCategoria int IDENTITY(1,1) NOT NULL, 
	IdCategoriaPadre int  NOT NULL, 
	Nombre nvarchar(60) NOT NULL,
	Descripcion nvarchar(250) NOT NULL, 
    PalabrasClaves NVARCHAR(250) NOT NULL
)
