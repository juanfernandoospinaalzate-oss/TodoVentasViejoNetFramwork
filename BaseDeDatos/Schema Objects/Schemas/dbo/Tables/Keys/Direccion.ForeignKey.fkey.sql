ALTER TABLE [dbo].[Direccion]
	ADD CONSTRAINT [ForeignKeyCliente] 
	FOREIGN KEY (IdCliente)
	REFERENCES Cliente (IdCliente)
GO
ALTER TABLE [dbo].[Direccion]
	ADD CONSTRAINT [ForeignKeyIdPais] 
	FOREIGN KEY (IdPais)
	REFERENCES Pais (IdPais)
GO
ALTER TABLE [dbo].[Direccion]
	ADD CONSTRAINT [ForeignKeyIdDepartamento] 
	FOREIGN KEY (IdDepartamento)
	REFERENCES Departamento (IdDepartamento)
GO
ALTER TABLE [dbo].[Direccion]
	ADD CONSTRAINT [ForeignKeyIdCiudades] 
	FOREIGN KEY (IdCiudad)
	REFERENCES Ciudad (IdCiudad)

