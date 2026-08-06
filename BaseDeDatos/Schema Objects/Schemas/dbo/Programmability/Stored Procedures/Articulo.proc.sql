CREATE PROCEDURE [dbo].[ArticuloSelect]
AS
	SELECT [Articulo].[IdArticulo]
	  ,[Articulo].[IdMarca]
	  ,[Articulo].[Titulo]
      ,[Articulo].[IdCategoria]
	  ,[Categoria].[IdCategoriaPadre]
	  ,[Categoria].[Nombre]
	  ,[Categoria].[Descripcion]
	  ,[Categoria].[PalabrasClaves]
      ,[Articulo].[Descripcion]
	  ,[Articulo].[PalabrasRelacionArticulo]
	  ,[Articulo].[MetaDescripcion]
      ,[Articulo].[MetaKeyWords]
	  ,[Articulo].[UnidadVolumen]
	  ,[Articulo].[UnidadMasa]
	  ,[Articulo].[UnidadLongitud]
	  ,[Articulo].[Tallas]
	  ,[Articulo].[Colores]
	  ,[Articulo].[EnLinea]
	  ,[Articulo].[PreOrdenar]
	  ,[Articulo].[Sabor]
	  ,[Articulo].[Activo]
      ,[Articulo].[GarantiaMeses]
      ,[Articulo].[VideoYoutube]
	  ,[Articulo].[UnidadPresentacion]
  FROM [dbo].[Articulo]
  INNER JOIN [dbo].[Categoria]
  ON [Categoria].[IdCategoria] = [Articulo].[IdCategoria] ORDER BY [Articulo].[IdArticulo]
GO

CREATE PROCEDURE [dbo].[ArticuloSelectWeb]
AS
	SELECT [Articulo].[IdArticulo]
	  ,[Articulo].[IdMarca]
	  ,[Articulo].[Titulo]
      ,[Articulo].[IdCategoria]
	  ,[Categoria].[IdCategoriaPadre]
	  ,[Categoria].[Nombre]
	  ,[Categoria].[Descripcion]
	  ,[Categoria].[PalabrasClaves]
      ,[Articulo].[Descripcion]
	  ,[Articulo].[PalabrasRelacionArticulo]
	  ,[Articulo].[MetaDescripcion]
      ,[Articulo].[MetaKeyWords]
	  ,[Articulo].[UnidadVolumen]
	  ,[Articulo].[UnidadMasa]
	  ,[Articulo].[UnidadLongitud]
	  ,[Articulo].[Tallas]
	  ,[Articulo].[Colores]
	  ,[Articulo].[EnLinea]
	  ,[Articulo].[PreOrdenar]
	  ,[Articulo].[Sabor]
	  ,[Articulo].[Activo]
      ,[Articulo].[GarantiaMeses]
      ,[Articulo].[VideoYoutube]
	  ,[Articulo].[UnidadPresentacion]
  FROM [dbo].[Articulo]
  INNER JOIN [dbo].[Categoria]
  ON [Categoria].[IdCategoria] = [Articulo].[IdCategoria] 
  WHERE [Articulo].[Activo] = 1 AND [Articulo].[EnLinea] = 1
  ORDER BY [Articulo].[IdArticulo] 
GO

CREATE PROCEDURE [dbo].[ArticuloInsert]
	(@IdMarca int
	,@Titulo nvarchar(50)
	,@IdCategoria int
	,@Descripcion nvarchar(MAX)
	,@PalabrasRelacionArticulo nvarchar(250)
	,@MetaDescripcion nvarchar(250)
	,@UnidadVolumen bit 
	,@UnidadMasa bit
	,@UnidadLongitud bit
	,@Tallas bit
	,@Colores bit
	,@EnLinea bit
	,@PreOrdenar bit
	,@Sabor bit
	,@Activo bit
	,@MetaKeyWords nvarchar(250)
	,@GarantiaMeses smallint
	,@VideoYoutube nvarchar(150)
	,@UnidadPresentacion bit
	,@OutIdArticulo int OUTPUT)
AS
INSERT INTO [dbo].[Articulo]
        ([IdMarca]
		,[Titulo]
        ,[IdCategoria]
        ,[Descripcion]
		,[PalabrasRelacionArticulo]
		,[MetaDescripcion]
		,[MetaKeyWords]
		,[UnidadVolumen]
	    ,[UnidadMasa]
	    ,[UnidadLongitud]
	    ,[Tallas]
	    ,[Colores]
	    ,[EnLinea]
		,[PreOrdenar]
		,[Sabor]
		,[Activo]
        ,[GarantiaMeses]
        ,[VideoYoutube]
		,[UnidadPresentacion]
		,[Actualizar])
     VALUES
		(@IdMarca
		,@Titulo
		,@IdCategoria
		,@Descripcion
		,@PalabrasRelacionArticulo
		,@MetaDescripcion
		,@MetaKeyWords
		,@UnidadVolumen 
		,@UnidadMasa 
		,@UnidadLongitud 
		,@Tallas 
		,@Colores 
		,@EnLinea 
		,@PreOrdenar
		,@Sabor
		,@Activo 
		,@GarantiaMeses
		,@VideoYoutube
		,@UnidadPresentacion
		,1)

		SET @OutIdArticulo = SCOPE_IDENTITY();
GO

CREATE PROCEDURE [dbo].[ArticuloUpdate]
	(@IdArticulo int
	,@IdMarca int
	,@Titulo nvarchar(50)
	,@IdSubCategoria int
	,@Descripcion nvarchar(MAX)
	,@PalabrasRelacionArticulo nvarchar(250)
	,@MetaDescripcion nvarchar(250)
	,@MetaKeyWords nvarchar(250)
	,@UnidadVolumen bit
	,@UnidadMasa bit
	,@UnidadLongitud bit
	,@Tallas bit
	,@Colores bit
	,@EnLinea bit
	,@PreOrdenar bit
	,@Sabor bit
	,@Activo bit
	,@GarantiaMeses smallint
	,@VideoYoutube nvarchar(150)
	,@UnidadPresentacion bit)
AS
UPDATE [dbo].[Articulo]
   SET [IdMarca] = @IdMarca
	  ,[Titulo] = @Titulo
      ,[IdCategoria] = @IdSubCategoria
      ,[Descripcion] = @Descripcion
	  ,[PalabrasRelacionArticulo] = @PalabrasRelacionArticulo
	  ,[MetaDescripcion] = @MetaDescripcion
	  ,[MetaKeyWords] = @MetaKeyWords
	  ,[UnidadVolumen] = @UnidadVolumen
	  ,[UnidadMasa] = @UnidadMasa
	  ,[UnidadLongitud] = @UnidadLongitud
	  ,[Tallas] = @Tallas
	  ,[Colores] = @Colores
	  ,[EnLinea] = @EnLinea
	  ,[PreOrdenar] = @PreOrdenar
	  ,[Sabor] = @Sabor
	  ,[Activo] = @Activo 
      ,[GarantiaMeses] = @GarantiaMeses
      ,[VideoYoutube] = @VideoYoutube
	  ,[UnidadPresentacion] = @UnidadPresentacion
	  ,[Actualizar] = 1
 WHERE IdArticulo = @IdArticulo
GO

CREATE PROCEDURE [dbo].[ArticuloDelete]
	@IdArticulo int
AS
	DELETE FROM [dbo].[Articulo]
		  WHERE IdArticulo = @IdArticulo
GO

CREATE PROCEDURE [dbo].[ArticuloSelectPorIdArticulo]
	@IdArticulo int
AS
	SELECT [IdArticulo]
	  ,[IdMarca]
	  ,[Titulo]
      ,[IdCategoria]
      ,[Descripcion]
	  ,[PalabrasRelacionArticulo]
	  ,[MetaDescripcion]
      ,[MetaKeyWords]
	  ,[UnidadVolumen]
	  ,[UnidadMasa]
	  ,[UnidadLongitud]
	  ,[Tallas]
	  ,[Colores]
	  ,[EnLinea]
	  ,[PreOrdenar]
	  ,[Sabor]
	  ,[Activo]
      ,[GarantiaMeses]
      ,[VideoYoutube]
	  ,[UnidadPresentacion]
  FROM [dbo].[Articulo]
  WHERE IdArticulo = @IdArticulo
GO

CREATE PROCEDURE [dbo].[ArticuloPorEstadoSelect]
@Estado bit
AS
	SELECT [Articulo].[IdArticulo]
	  ,[Articulo].[IdMarca]
	  ,[Articulo].[Titulo]
      ,[Articulo].[IdCategoria]
	  ,[Categoria].[IdCategoriaPadre]
	  ,[Categoria].[Nombre]
	  ,[Categoria].[Descripcion]
	  ,[Categoria].[PalabrasClaves]
      ,[Articulo].[Descripcion]
	  ,[Articulo].[PalabrasRelacionArticulo]
	  ,[Articulo].[MetaDescripcion]
      ,[Articulo].[MetaKeyWords]
	  ,[Articulo].[UnidadVolumen]
	  ,[Articulo].[UnidadMasa]
	  ,[Articulo].[UnidadLongitud]
	  ,[Articulo].[Tallas]
	  ,[Articulo].[Colores]
	  ,[Articulo].[EnLinea]
	  ,[Articulo].[PreOrdenar]
	  ,[Articulo].[Sabor]
	  ,[Articulo].[Activo]
      ,[Articulo].[GarantiaMeses]
      ,[Articulo].[VideoYoutube]
	  ,[Articulo].[UnidadPresentacion]
  FROM [dbo].[Articulo] 
  INNER JOIN [dbo].[Categoria]
  ON [Categoria].[IdCategoria] = [Articulo].[IdCategoria]
  WHERE [Activo] = @Estado
  ORDER BY [Articulo].[IdArticulo] DESC
  GO

CREATE PROCEDURE dbo.ArticuloSelectPorListaCategorias
@Ids [dbo].[ids] READONLY
AS
  SET NOCOUNT ON;

  SELECT IdArticulo FROM [dbo].[Articulo]
	WHERE [IdCategoria] IN (SELECT Id FROM @Ids)
GO

CREATE PROCEDURE [dbo].[ArticuloSelectWebPendientesActualizacion]
AS
	SELECT [Articulo].[IdArticulo]
	  ,[Articulo].[IdMarca]
	  ,[Articulo].[Titulo]
      ,[Articulo].[IdCategoria]
	  ,[Categoria].[IdCategoriaPadre]
	  ,[Categoria].[Nombre]
	  ,[Categoria].[Descripcion]
	  ,[Categoria].[PalabrasClaves]
      ,[Articulo].[Descripcion]
	  ,[Articulo].[PalabrasRelacionArticulo]
	  ,[Articulo].[MetaDescripcion]
      ,[Articulo].[MetaKeyWords]
	  ,[Articulo].[UnidadVolumen]
	  ,[Articulo].[UnidadMasa]
	  ,[Articulo].[UnidadLongitud]
	  ,[Articulo].[Tallas]
	  ,[Articulo].[Colores]
	  ,[Articulo].[EnLinea]
	  ,[Articulo].[PreOrdenar]
	  ,[Articulo].[Sabor]
	  ,[Articulo].[Activo]
      ,[Articulo].[GarantiaMeses]
      ,[Articulo].[VideoYoutube]
	  ,[Articulo].[UnidadPresentacion]
	  ,[Marca].[Nombre]
FROM [dbo].[Articulo]
INNER JOIN [dbo].[Categoria] ON [Categoria].[IdCategoria] = [Articulo].[IdCategoria] 
INNER JOIN [dbo].[Marca] ON [Marca].[IdMarca] = [Articulo].[idMarca]
WHERE [Articulo].[Actualizar] = 1
ORDER BY [Articulo].[IdArticulo] 
  GO

CREATE PROCEDURE [dbo].[ArticuloUpdateQuitarMarcaActualizar]
	@IdArticulo AS INT
AS
	UPDATE [dbo].[Articulo]
		SET [Actualizar] = 0
	WHERE IdArticulo = @IdArticulo
GO

CREATE PROCEDURE [dbo].[ArticuloSelectPorIdArticuloEstado]
	@IdArticulo int,
	@Estado bit
AS
	SELECT [Articulo].[IdArticulo]
	  ,[Articulo].[IdMarca]
	  ,[Articulo].[Titulo]
      ,[Articulo].[IdCategoria]
	  ,[Categoria].[IdCategoriaPadre]
	  ,[Categoria].[Nombre]
	  ,[Categoria].[Descripcion]
	  ,[Categoria].[PalabrasClaves]
      ,[Articulo].[Descripcion]
	  ,[Articulo].[PalabrasRelacionArticulo]
	  ,[Articulo].[MetaDescripcion]
      ,[Articulo].[MetaKeyWords]
	  ,[Articulo].[UnidadVolumen]
	  ,[Articulo].[UnidadMasa]
	  ,[Articulo].[UnidadLongitud]
	  ,[Articulo].[Tallas]
	  ,[Articulo].[Colores]
	  ,[Articulo].[EnLinea]
	  ,[Articulo].[PreOrdenar]
	  ,[Articulo].[Sabor]
	  ,[Articulo].[Activo]
      ,[Articulo].[GarantiaMeses]
      ,[Articulo].[VideoYoutube]
	  ,[Articulo].[UnidadPresentacion]
  FROM [dbo].[Articulo]
  INNER JOIN [dbo].[Categoria]
  ON [Categoria].[IdCategoria] = [Articulo].[IdCategoria] 
  WHERE [Articulo].[IdArticulo] = @IdArticulo AND [Articulo].[Activo] = @Estado
  GO

  CREATE PROCEDURE [dbo].[ArticuloSelectWebPorListaCategorias]
  @Ids AS dbo.Ids READONLY
AS
BEGIN
  SET NOCOUNT ON;

  SELECT IdArticulo FROM [dbo].[Articulo]
	WHERE [Articulo].[IdCategoria] IN (SELECT Id FROM @Ids) 
	AND [Articulo].[Activo] = 1 
	AND [Articulo].[EnLinea] = 1
END