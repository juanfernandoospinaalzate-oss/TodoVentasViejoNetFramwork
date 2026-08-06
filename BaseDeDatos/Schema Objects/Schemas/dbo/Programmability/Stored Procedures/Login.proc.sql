CREATE PROCEDURE LoginSignIn
@Email nvarchar(50),
@Contrasena nvarchar(50)
AS
SELECT [Nombre],[Apellido]
FROM [dbo].[Cliente]
WHERE [eMail] = @Email AND [Contrasena] = @Contrasena