ALTER TABLE [dbo].[Departamento]
	ADD CONSTRAINT [ForeignKeyDepartamento] 
	FOREIGN KEY (IdPais)
	REFERENCES Pais (IdPais)	

