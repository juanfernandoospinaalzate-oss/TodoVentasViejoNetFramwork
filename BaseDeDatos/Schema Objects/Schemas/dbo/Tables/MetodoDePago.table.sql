CREATE TABLE [dbo].[MetodoDePago]
(
	IdMetodoDePago int IDENTITY(1,1) NOT NULL, 
	Nombre nvarchar(60) NOT NULL,
	Descripcion nvarchar(250) NOT NULL
)
