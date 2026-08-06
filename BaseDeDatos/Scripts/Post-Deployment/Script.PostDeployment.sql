/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

-- Llenado inicial de la tabla Pais
:r .\Pais.Llenado.sql
GO
-- Llenado inicial de la tabla Departamento
:r .\Departamento.Llenado.sql
GO
-- Llenado inicial de la tabla Ciudad
:r .\Ciudad.Llenado.sql
GO
-- Llenado inicial de la tabla Almacen
:r .\Almacen.Llenado.sql
GO 
-- Llenado inicial de la tabla Idioma
:r .\Idioma.Llenado.sql
GO
-- Llenado inicial de la tabla Contacto
:r .\Contacto.Llenado.sql
GO
-- Llenado inicial de la tabla ContactosPorAlmacen
:r .\ContactosPorAlmacen.Llenado.sql
GO
-- Llenado inicial de la tabla Color
:r .\Color.Llenado.sql
GO
-- Llenado inicial de la tabla Categoria
:r .\Categoria.Llenado.sql
GO
-- Llenado inicial de la tabla Talla
:r .\Talla.Llenado.sql
GO
-- Llenado inicial de la tabla Unidad Longitud
:r .\UnidadMasa.Llenado.sql
GO
-- Llenado inicial de la tabla Unidad Longitud
:r .\UnidadVolumen.Llenado.sql
GO
-- Llenado inicial de la tabla Unidad Longitud
:r .\UnidadLongitud.Llenado.sql
GO
-- Llenado inicial de la tabla Marca
:r .\Marca.Llenado.sql
GO
-- Llenado inicial de la tabla Articulo
:r .\Sabor.Llenado.sql
GO
-- Llena inicial de la tabla UnidadPresentacion
:r .\UnidadPresentacion.Llenado.sql
GO
-- Llenado configuración Medios de Pago para PayU
:r .\ConfiguracionMediosDePagoPayU.Llenado.sql
-- Llenado BannerPrincipal
:r .\BannerPrincipal.Llenado.sql
GO
-- Llenado Busquedas Inicial
:r .\Busquedas.Llenado.sql
GO
-- Llenado Dummy para Pruebas
:r .\AAA_Datos_Dummy.Llenado.sql
GO
-- Llenado Cliente (Cliente Anónimo para Ventas Anónimas)
:r .\Cliente.Llenado.sql
-- Creación de Catalogo Full Text Search
-- :r .\FullTextSearch.Llenado.sql
GO
