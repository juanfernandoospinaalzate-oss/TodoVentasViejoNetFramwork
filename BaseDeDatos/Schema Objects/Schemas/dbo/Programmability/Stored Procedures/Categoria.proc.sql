CREATE PROCEDURE [dbo].[CategoriaInsert]
	(@IdCategoriaPadre int
	,@Nombre nvarchar(60)
	,@Descripcion nvarchar(250)
	,@PalabrasClaves nvarchar(250)
	,@OutIdCategoria int OUTPUT)
AS
INSERT INTO [dbo].[Categoria]
           ([IdCategoriaPadre]
           ,[Nombre]
           ,[Descripcion]
           ,[PalabrasClaves])
           VALUES
		  (@IdCategoriaPadre
		  ,@Nombre
		  ,@Descripcion
		  ,@PalabrasClaves)

		  SET @OutIdCategoria = SCOPE_IDENTITY();
GO

CREATE PROCEDURE [dbo].[CategoriaUpdate]
	(@IdCategoria int
	,@IdCategoriaPadre int
	,@Nombre nvarchar(60)
	,@Descripcion nvarchar(250)
	,@PalabrasClaves nvarchar(250))
AS
UPDATE [dbo].[Categoria]
         SET [IdCategoriaPadre] = @IdCategoriaPadre
           ,[Nombre] = @Nombre
           ,[Descripcion] = @Descripcion
           ,[PalabrasClaves] = @PalabrasClaves 
		   WHERE IdCategoria = @IdCategoria    
GO

CREATE PROCEDURE [dbo].[CategoriaDelete]
@IdCategoria int
AS
DELETE FROM [dbo].[Categoria]
WHERE IdCategoria = @IdCategoria
GO

CREATE PROCEDURE [dbo].[CategoriaSelect]
AS
SELECT 
       [IdCategoria]
      ,[IdCategoriaPadre]
      ,[Nombre]
      ,[Descripcion]
      ,[PalabrasClaves]
	  FROM [Categoria]
GO

CREATE PROCEDURE [dbo].[CategoriaSelectPorIdCategoria]
@IdCategoria int
AS
SELECT 
       [IdCategoria]
      ,[IdCategoriaPadre]
      ,[Nombre]
      ,[Descripcion]
      ,[PalabrasClaves]
	  FROM [Categoria]
	  WHERE IdCategoriaPadre = @IdCategoria
GO

CREATE PROCEDURE [dbo].[CategoriaVerificarRelacionArticulo] 
	@IdCategoria int
AS
SELECT TOP 1 [IdCategoria] FROM  [dbo].[Articulo]
WHERE [dbo].[Articulo].IdCategoria = @IdCategoria
GO

CREATE PROCEDURE CategoriaVerificarSubCategoria
@IdCategoria int
AS
SELECT TOP 1 [IdCategoria] FROM [dbo].[Categoria]  
WHERE [dbo].[Categoria].IdCategoriaPadre = @IdCategoria
GO

CREATE PROCEDURE CategoriaVerificarDuplicidad
@IdCategoria int,
@Nombre varchar(60)
AS
SELECT TOP 1 IdCategoria FROM [dbo].[Categoria]  
WHERE [dbo].[Categoria].IdCategoria <> @IdCategoria AND [dbo].[Categoria].Nombre=@Nombre
GO

CREATE PROCEDURE [dbo].[CategoriaSelectUsadas]
AS
SELECT TOP (1000) 
	Categoria.IdCategoria
    ,Categoria.IdCategoriaPadre
    ,Categoria.Nombre
    ,Categoria.Descripcion
    ,Categoria.PalabrasClaves
FROM [TodoVentas].[dbo].[Articulo] 
INNER JOIN Categoria ON Categoria.IdCategoria = Articulo.IdCategoria
INNER JOIN PresentacionArticulo ON PresentacionArticulo.IdArticulo = Articulo.IdArticulo
WHERE Articulo.Activo = 1 and Articulo.EnLinea = 1 and PresentacionArticulo.Activo = 1 and PresentacionArticulo.EnLinea = 1
GROUP BY Categoria.IdCategoria, Categoria.IdCategoriaPadre, Categoria.Nombre, Categoria.Descripcion,Categoria.PalabrasClaves
GO