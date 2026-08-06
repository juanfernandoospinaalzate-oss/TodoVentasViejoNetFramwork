CREATE PROCEDURE [dbo].[ColorInsert]
	(@Codigo nchar(6)
	,@Nombre nvarchar(25))
AS
INSERT INTO [dbo].[Color]
           ([Codigo]
           ,[Nombre])
     VALUES
           (@Codigo
           ,@Nombre)
GO

CREATE PROCEDURE [dbo].[ColorSelect]
AS
SELECT [IdColor]
      ,[Codigo]
      ,[Nombre]
  FROM [Color]
GO

CREATE PROCEDURE [dbo].[ColorVerificarRelacionArticulo]
@IdColor int
AS
SELECT TOP 1 IdColor FROM [dbo].[PresentacionArticulo] 
	WHERE [dbo].[PresentacionArticulo].IdColor = @IdColor
GO

CREATE PROCEDURE [dbo].[ColorVerificaUnicidadCodigo]
	@CodigoColor NCHAR(6)
AS
SELECT TOP 1 Codigo
	FROM [Color] 
	WHERE Codigo = @CodigoColor
GO

CREATE PROCEDURE [dbo].[ColorVerificaUnicidadNombre]
	@NombreColor NCHAR(6)
AS
SELECT TOP 1 Nombre
	FROM [Color] 
	WHERE Nombre = @NombreColor
GO

CREATE PROCEDURE [dbo].[ColorDelete]
@IdColor int
AS
DELETE FROM [dbo].[Color]
WHERE IdColor = @IdColor
GO

CREATE PROCEDURE ColorUpdate
@IdColor int
,@Codigo nchar(6)
,@Nombre nvarchar(25)
AS
UPDATE [dbo].[Color]
   SET [Codigo] = @Codigo
      ,[Nombre] = @Nombre
 WHERE IdColor = @IdColor
GO
