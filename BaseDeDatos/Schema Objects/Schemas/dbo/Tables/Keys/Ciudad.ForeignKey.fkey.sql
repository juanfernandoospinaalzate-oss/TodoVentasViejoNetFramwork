ALTER TABLE [dbo].[Ciudad]
	ADD CONSTRAINT [ForeignKeyCiudad] 
	FOREIGN KEY (IdDepartamento)
	REFERENCES Departamento (IdDepartamento)	

