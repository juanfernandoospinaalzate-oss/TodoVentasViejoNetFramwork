
CREATE PROCEDURE [dbo].[AlmacenSelect]
AS
	SELECT [IdAlmacen]
      ,[Nombre]
      ,[Descripcion]
      ,[Direccion]
      ,[IdCiudad]
      ,[Telefono1]
      ,[Telefono2]
      ,[Fax]
	  ,[Email]
	  ,[Nit]
	  ,[SitioWeb]
	FROM [Almacen]
GO

CREATE PROCEDURE [dbo].[AlmacenInsert]
	(@Nombre nvarchar(60)
	,@Descripcion nvarchar(250)
	,@Direccion nvarchar(250)
	,@IdCiudad int
	,@Telefono1 nvarchar(50)
	,@Telefono2 nvarchar(50)
	,@Fax nvarchar(25)
	,@Email nvarchar(50)
	,@Nit int
	,@SitioWeb nvarchar(50))
AS
	INSERT INTO [dbo].[Almacen]
	([Nombre]
	,[Descripcion]
	,[Direccion]
	,[IdCiudad]
	,[Telefono1]
	,[Telefono2]
	,[Fax]
	,[Email]
	,[Nit]
	,[SitioWeb])
    VALUES
	(@Nombre
	,@Descripcion
	,@Direccion
	,@IdCiudad
	,@Telefono1
	,@Telefono2
	,@Fax
	,@Email
	,@Nit
	,@SitioWeb)
GO

CREATE PROCEDURE [dbo].[AlmacenUpdate]
	(@IdAlmacen int
	,@Nombre nvarchar(60)
	,@Descripcion nvarchar(250)
	,@Direccion nvarchar(250)
	,@IdCiudad int
	,@Telefono1 nvarchar(50)
	,@Telefono2 nvarchar(50)
	,@Fax nvarchar(25)
	,@Email nvarchar(50)
	,@Nit int
	,@SitioWeb nvarchar(50))
AS
	UPDATE [dbo].[Almacen]
	   SET [Nombre] = @Nombre
		,[Descripcion] = @Descripcion
		,[Direccion] = @Direccion
		,[IdCiudad] = @IdCiudad
		,[Telefono1] = @Telefono1
		,[Telefono2] = @Telefono2
		,[Fax] = @Fax
		,[Email] = @Email
		,[Nit] = @Nit
		,[SitioWeb] = @SitioWeb
	 WHERE IdAlmacen = @IdAlmacen
GO

CREATE PROCEDURE [dbo].[AlmacenDelete]
	@IdAlmacen int
AS
	DELETE FROM [dbo].[Almacen]
		  WHERE IdAlmacen = @IdAlmacen
GO

CREATE PROCEDURE [dbo].[AlmacenSelectPorIdAlmacen]
	@IdAlmacen int
AS
	SELECT [IdAlmacen]
		,[Nombre]
		,[Descripcion]
		,[Direccion]
		,[IdCiudad]
		,[Telefono1]
		,[Telefono2]
		,[Fax]
		,[Email]
		,[Nit]
		,[SitioWeb]
	FROM [dbo].[Almacen]
		WHERE IdAlmacen = @IdAlmacen
GO