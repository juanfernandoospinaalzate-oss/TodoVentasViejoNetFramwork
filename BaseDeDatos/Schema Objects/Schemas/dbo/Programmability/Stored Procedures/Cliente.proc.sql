CREATE PROCEDURE ClienteInsert
	(@DocCliente int,
	@Nombre nvarchar(30),
	@Apellido nvarchar(30),
	@Telefono1 nvarchar(20),
	@Telefono2 nvarchar(20),
	@eMail nvarchar(50),
	@Contrasena nvarchar(50),
	@OutIdCliente int OUTPUT)
AS
	INSERT INTO [dbo].[Cliente]
		([DocCliente]
		,[Nombre]
		,[Apellido]
		,[Telefono1]
		,[Telefono2]
		,[eMail]
		,[Contrasena])
	VALUES
		(@DocCliente
		,@Nombre
		,@Apellido
		,@Telefono1
		,@Telefono2
		,@eMail
		,@Contrasena)

	SET @OutIdCliente = SCOPE_IDENTITY();
	GO

CREATE PROCEDURE [dbo].[ClienteSelect]
AS
SELECT 
	[IdCliente]
	,[DocCliente]
	,[Nombre]
	,[Apellido]
	,[Telefono1]
	,[Telefono2]
	,[eMail]
FROM [dbo].[Cliente]
GO

CREATE PROCEDURE [dbo].[ClienteSelectPorIdCliente]
@IdCliente int
AS
SELECT 
	[IdCliente]
	,[DocCliente]
	,[Nombre]
	,[Apellido]
	,[Telefono1]
	,[Telefono2]
	,[eMail]
FROM [dbo].[Cliente]
WHERE IdCliente = @IdCliente
GO

CREATE PROCEDURE ClienteUpdate
	@Nombre nvarchar(30),
	@Apellido nvarchar(30),
	@Telefono1 nvarchar(20),
	@Telefono2 nvarchar(20),
	@Email nvarchar(50),
	@IdCliente int
AS
UPDATE [dbo].[Cliente]
   SET [Nombre] = @Nombre
	  ,[Apellido] = @Apellido
	  ,[Telefono1] = @Telefono1
	  ,[Telefono2]= @Telefono2
	  ,[eMail] = @Email
 WHERE [IdCliente] = 1
 GO

CREATE PROCEDURE ClienteSelectPorEmail
@Email nvarchar(50)
AS 
SELECT
	[IdCliente]
	,[DocCliente]
	,[Nombre]
	,[Apellido]
	,[Telefono1]
	,[Telefono2]
	,[eMail]
FROM [dbo].[Cliente]
WHERE [dbo].[Cliente].eMail = @Email
GO

CREATE PROCEDURE ClienteCambioPassword
@PasswordNuevo nvarchar(50),
@IdCliente int
AS 
UPDATE [dbo].[Cliente]
	SET [Contrasena]=@PasswordNuevo
	WHERE [IdCliente] = @IdCliente
GO

CREATE PROCEDURE ClienteSelectPorDocCliente
@docCliente int
AS
SELECT 
	[IdCliente]
	,[DocCliente]
	,[Nombre]
	,[Apellido]
	,[Telefono1]
	,[Telefono2]
	,[eMail]
FROM [dbo].[Cliente]
WHERE [dbo].[Cliente].[DocCliente] = @docCliente