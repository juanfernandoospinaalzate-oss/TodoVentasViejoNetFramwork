CREATE PROCEDURE [dbo].[ConfiguracionPieDePaginaUpdate]
(
 @Id int
,@AtencionSkype nvarchar(MAX)
,@LineaTelefonica nvarchar(MAX)
,@LineaCelular nvarchar(MAX)
,@CorreoElectronico nvarchar(MAX)
,@Devoluciones nvarchar(MAX)
,@ComoPagar nvarchar(MAX)
,@Envios nvarchar(MAX)
,@MensajeInicialWhatsapp nvarchar(MAX)
)
AS
UPDATE [dbo].[ConfiguracionPieDePagina]
   SET [AtencionSkype] = @AtencionSkype
      ,[LineaTelefonica] = @LineaTelefonica
      ,[LineaCelular] = @LineaCelular
      ,[CorreoElectronico] = @CorreoElectronico
      ,[Devoluciones] = @Devoluciones
      ,[ComoPagar] = @ComoPagar
      ,[Envios]  = @Envios
	  ,[MensajeInicialWhatsapp] = @MensajeInicialWhatsapp
 WHERE [Id] = @Id
 GO

CREATE PROCEDURE [dbo].[ConfiguracionPieDePaginaSelect]
AS
SELECT [Id]
      ,[AtencionSkype]
      ,[LineaTelefonica]
      ,[LineaCelular]
      ,[CorreoElectronico]
      ,[Devoluciones]
      ,[ComoPagar]
      ,[Envios]
	  ,[MensajeInicialWhatsapp]
FROM [dbo].[ConfiguracionPieDePagina]
GO

CREATE PROCEDURE [dbo].[ConfiguracionPieDePaginaInsert]
	@AtencionSkype NVARCHAR(4000),
	@LineaTelefonica NVARCHAR(4000),
	@LineaCelular NVARCHAR(4000),
	@CorreoElectronico NVARCHAR(4000),
	@Devoluciones NVARCHAR(4000),
	@ComoPagar NVARCHAR(4000),
	@Envios NVARCHAR(4000),
	@MensajeInicialWhatsapp nvarchar(MAX)
AS
INSERT INTO [dbo].[ConfiguracionPieDePagina]
(
	 [AtencionSkype]
	,[LineaTelefonica]
	,[LineaCelular]
	,[CorreoElectronico]
	,[Devoluciones]
	,[ComoPagar]
	,[Envios]
	,[MensajeInicialWhatsapp]
)
VALUES(
	 @AtencionSkype
	,@LineaTelefonica
	,@LineaCelular
	,@CorreoElectronico
	,@Devoluciones
	,@ComoPagar
	,@Envios
	,@MensajeInicialWhatsapp
)