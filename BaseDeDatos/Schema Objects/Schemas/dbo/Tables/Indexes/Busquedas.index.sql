CREATE INDEX [indexTexto]
	ON [dbo].[Busquedas]
	(Texto)
GO

CREATE INDEX [indexEliminado]
	ON [dbo].[Busquedas]
	(Eliminado)
GO

CREATE INDEX [indexAprobado]
	ON [dbo].[Busquedas]
	(Aprobado)
GO