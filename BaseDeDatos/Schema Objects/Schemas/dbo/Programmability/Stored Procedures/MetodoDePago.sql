CREATE PROCEDURE MetodoDePagoDelete
	@IdMetodoDePago INT
AS
DELETE FROM MetodoDePago
      WHERE IdMetodoDePago = @IdMetodoDePago
GO

CREATE PROCEDURE MetodoDePagoUpdate
	@IdMetodoDePago int,
	@Nombre NVARCHAR(60),
	@Descripcion NVARCHAR(250)
AS
UPDATE MetodoDePago
   SET Nombre = @Nombre,
      Descripcion = @Descripcion
 WHERE IdMetodoDePago = @IdMetodoDePago
GO

CREATE PROCEDURE MetodoDePagoInsert
	@Nombre NVARCHAR(60),
	@Descripcion NVARCHAR(250)
AS
INSERT INTO MetodoDePago
           (Nombre
           ,Descripcion)
     VALUES
           (@Nombre,
           @Descripcion)
GO

CREATE PROCEDURE MetodoDePagoSelect
AS
SELECT [IdMetodoDePago]
      ,[Nombre]
      ,[Descripcion]
  FROM [dbo].[MetodoDePago]
GO