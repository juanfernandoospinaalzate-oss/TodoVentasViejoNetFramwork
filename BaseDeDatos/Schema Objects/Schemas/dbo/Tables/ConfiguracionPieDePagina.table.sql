CREATE TABLE [dbo].[ConfiguracionPieDePagina](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AtencionSkype] [nvarchar](max) NULL,
	[LineaTelefonica] [nvarchar](max) NULL,
	[LineaCelular] [nvarchar](max) NULL,
	[CorreoElectronico] [nvarchar](max) NULL,
	[Devoluciones] [nvarchar](max) NULL,
	[ComoPagar] [nvarchar](max) NULL,
	[Envios] [nvarchar](max) NULL,
	[MensajeInicialWhatsapp] [nvarchar](max) NULL,
 CONSTRAINT [PK_ConfiguracionPieDePagina] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


