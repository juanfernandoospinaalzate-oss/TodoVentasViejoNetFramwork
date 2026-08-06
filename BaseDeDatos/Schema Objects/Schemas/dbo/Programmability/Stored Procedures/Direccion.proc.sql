CREATE PROCEDURE [dbo].[DireccionInsert]
	@NombreDestinatario nvarchar(30),
	@DireccionEnvio nvarchar(40),
	@Telefono nvarchar(20),
	@IdPais int,
	@IdDpto int,
	@IdCiudad int,
	@IdCliente int
AS
	INSERT INTO [dbo].[Direccion]
		([NombreDestinatario]
		,[DireccionEnvio]
		,[Telefono]
		,[IdPais]
		,[IdDepartamento]
		,[IdCiudad]
		,[IdCliente])
	VALUES
		(@NombreDestinatario
		,@DireccionEnvio
		,@Telefono
		,@IdPais
		,@IdDpto
		,@IdCiudad
		,@IdCliente)
GO

CREATE PROCEDURE [dbo].[DireccionSelectIdUsuario]
@IdUsuario int
AS
SELECT [IdDireccion]
,[dbo].[Direccion].[NombreDestinatario]
,[dbo].[Direccion].[DireccionEnvio]
,[dbo].[Direccion].[Telefono]
,[dbo].[Direccion].[IdPais]
,[dbo].[Direccion].[IdDepartamento]
,[dbo].[Direccion].[IdCiudad]
,[dbo].[Direccion].[IdCliente]
,[dbo].[Pais].[Nombre]
,[dbo].[Departamento].[Nombre]
,[dbo].[Ciudad].[Nombre]
FROM [dbo].[Direccion]
INNER JOIN [dbo].[Pais] ON [dbo].[Direccion].IdPais = [dbo].[Pais].IdPais
INNER JOIN [dbo].[Departamento] ON [dbo].[Direccion].IdDepartamento = [dbo].[Departamento].IdDepartamento
INNER JOIN [dbo].[Ciudad] ON [dbo].[Direccion].IdCiudad = [dbo].[Ciudad].IdCiudad
WHERE [dbo].[Direccion].[IdCliente] = @IdUsuario
GO

CREATE PROCEDURE [dbo].[DireccionSelect]
AS
SELECT [IdDireccion]
,[dbo].[Direccion].[NombreDestinatario]
,[dbo].[Direccion].[DireccionEnvio]
,[dbo].[Direccion].[Telefono]
,[dbo].[Direccion].[IdPais]
,[dbo].[Direccion].[IdDepartamento]
,[dbo].[Direccion].[IdCiudad]
,[dbo].[Direccion].[IdCliente]
,[dbo].[Pais].[Nombre]
,[dbo].[Departamento].[Nombre]
,[dbo].[Ciudad].[Nombre]
FROM [dbo].[Direccion]
INNER JOIN [dbo].[Pais] ON [dbo].[Direccion].IdPais = [dbo].[Pais].IdPais
INNER JOIN [dbo].[Departamento] ON [dbo].[Direccion].IdDepartamento = [dbo].[Departamento].IdDepartamento
INNER JOIN [dbo].[Ciudad] ON [dbo].[Direccion].IdCiudad = [dbo].[Ciudad].IdCiudad
GO

CREATE PROCEDURE [dbo].[DireccionUpdate]
	@NombreDestinatario nvarchar(30),
	@DireccionEnvio nvarchar(40),
	@Telefono nvarchar(20),
	@IdPais int,
	@IdDpto int,
	@IdCiudad int,
	@IdDireccion int
AS
UPDATE [dbo].[Direccion]
   SET [NombreDestinatario] = @NombreDestinatario
      ,[DireccionEnvio] = @DireccionEnvio
      ,[Telefono] = @Telefono
      ,[IdPais] = @IdPais
      ,[IdDepartamento] = @IdDpto
      ,[IdCiudad] = @IdCiudad
 WHERE [IdDireccion] = @IdDireccion
GO

CREATE PROCEDURE [dbo].[DireccionConsultarPorIdDireccion]
@IdDireccion int
AS
SELECT 
	  [IdDireccion],
	  [IdCliente],
	  [NombreDestinatario],
      [DireccionEnvio],
      [Telefono],
	  [dbo].[Direccion].[IdPais],
	  [dbo].[Direccion].[IdDepartamento],
	  [dbo].[Direccion].[IdCiudad],
	  [dbo].[Pais].Nombre,
	  [dbo].[Departamento].Nombre,
	  [dbo].[Ciudad].Nombre
	  FROM [dbo].[Direccion]
	  INNER JOIN [dbo].[Pais] ON [dbo].[Direccion].[IdPais] = [dbo].[Pais].[IdPais]
	  INNER JOIN [dbo].[Departamento] ON [dbo].[Direccion].[IdDepartamento] = [dbo].[Departamento].[IdDepartamento]
	  INNER JOIN [dbo].[Ciudad] ON [dbo].[Direccion].[IdCiudad] = [dbo].[Ciudad].[IdCiudad]
	  WHERE [IdDireccion] = @IdDireccion
GO

CREATE PROCEDURE [dbo].[DireccionDelete]
@IdDireccion int
AS
DELETE FROM [dbo].[Direccion]
      WHERE IdDireccion = @IdDireccion
GO

CREATE PROCEDURE [dbo].[DireccionSelectDocCliente]
@IdCliente int
AS
	SELECT [dbo].[Direccion].[IdDireccion]
	,[dbo].[Direccion].[NombreDestinatario]
	,[dbo].[Direccion].[DireccionEnvio]
	,[dbo].[Direccion].[Telefono]
	,[dbo].[Direccion].[IdPais]
	,[dbo].[Direccion].[IdDepartamento]
	,[dbo].[Direccion].[IdCiudad]
	,[dbo].[Direccion].[IdCliente]
	,[dbo].[Pais].[Nombre]
	,[dbo].[Departamento].[Nombre]
	,[dbo].[Ciudad].[Nombre]
	FROM [dbo].[Direccion]
	INNER JOIN [dbo].[Pais] ON [dbo].[Direccion].IdPais = [dbo].[Pais].IdPais
	INNER JOIN [dbo].[Departamento] ON [dbo].[Direccion].IdDepartamento = [dbo].[Departamento].IdDepartamento
	INNER JOIN [dbo].[Ciudad] ON [dbo].[Direccion].IdCiudad = [dbo].[Ciudad].IdCiudad
	INNER JOIN [dbo].[Cliente] ON [dbo].[Cliente].IdCliente = [dbo].[Direccion].IdCliente
	 WHERE [dbo].[Cliente].DocCliente = @IdCliente
GO
