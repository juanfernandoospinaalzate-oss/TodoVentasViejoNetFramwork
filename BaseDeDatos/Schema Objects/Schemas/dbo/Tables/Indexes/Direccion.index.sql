CREATE INDEX [IndexIdClientes]
    ON [dbo].[Direccion]
	(IdCliente)
GO
CREATE INDEX [IndexIdPais]
    ON [dbo].[Direccion]
	(IdPais)
GO
CREATE INDEX [IndexIdDepartamento]
    ON [dbo].[Direccion]
	(IdDepartamento)
GO
CREATE INDEX [IndexIdCiudad]
    ON [dbo].[Direccion]
	(IdCiudad)
GO