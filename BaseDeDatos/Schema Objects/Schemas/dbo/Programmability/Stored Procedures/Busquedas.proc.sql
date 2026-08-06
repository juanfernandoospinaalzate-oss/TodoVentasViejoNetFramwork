/*Inserta una busqueda nueva cuando no existe en la base de datos*/
CREATE PROCEDURE [dbo].[BusquedasInsertar]
	@Texto NVARCHAR(250)
AS
	DECLARE @IdBusqueda as int /*Determina si la búsqueda ya se ha hecho antes*/

	/*Investigar si la búsqueda ya se ha hecho*/ /*NOTA PASAR A FULLTEXT SEARCH*/
	SET @IdBusqueda = (SELECT IdBusqueda FROM [dbo].[Busquedas] WHERE Texto = @Texto)

	/*Si la búsqueda ya se ha hecho se incrementa el contado */
	IF @IdBusqueda > 0
		UPDATE [dbo].[Busquedas] SET [ContadorBusquedas] = [ContadorBusquedas] + 1 WHERE IdBusqueda = @IdBusqueda
	ELSE /*Si la busqueda no se ha hecho nunca, se inserta y comienza el contador en 1*/
		INSERT INTO [dbo].[Busquedas]
			   ([Texto]
			   ,[ContadorBusquedas]
			   ,[Eliminado]
			   ,[Aprobado])
		 VALUES
			   (@Texto, 1, 0, 0)
GO

CREATE PROCEDURE [dbo].[BusquedasEliminar]
	@Id INT
AS
	UPDATE [dbo].[Busquedas] SET [Eliminado] = 1
GO

CREATE PROCEDURE [dbo].[BusquedasAprobar]
	@Id INT
AS
	UPDATE [dbo].[Busquedas] SET [Aprobado] = 1
GO


/*Lista las busquedas que pueden verse en el buscador de la web, (utilizado por el ServiciosWebPublica)*/
CREATE PROCEDURE [dbo].[BusquedasListarWeb]
	@Texto AS NVARCHAR(250)
AS
	SET @Texto = @Texto + '%'

	SELECT [IdBusqueda]
	,[Texto]
	FROM [Busquedas]
	WHERE [Eliminado] = 0 AND [Aprobado] = 1 AND Texto LIKE @Texto
GO

/*Lista las busquedas según parametros (utilizado por ServiciosWeb desde software de escritorio)*/
CREATE PROCEDURE [dbo].[BusquedasListarAprobadosEliminados]
	@Eliminado AS BIT,
	@Aprobado AS BIT
AS
SELECT [IdBusqueda]
      ,[Texto]
      ,[ContadorBusquedas]
      ,[Eliminado]
      ,[Aprobado]
  FROM [dbo].[Busquedas]
  WHERE [Eliminado] =  @Eliminado AND [Aprobado] = @Aprobado
GO

/**/