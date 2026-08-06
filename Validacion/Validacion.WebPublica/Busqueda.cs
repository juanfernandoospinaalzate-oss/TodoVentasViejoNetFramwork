// -----------------------------------------------------------------------
// <copyright file="Busqueda.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace Validacion.WebPublica
{
    using System;

    public class Busqueda : ContratosWeb.IBusqueda
    {
        public System.Collections.ObjectModel.ReadOnlyCollection<string> Listar(string texto)
        {
            ReglasDENegocio.WebPublica.Busqueda Busqueda = new ReglasDENegocio.WebPublica.Busqueda();
            return Busqueda.Listar(texto);
        }


        public void Insertar(string texto)
        {
            ReglasDENegocio.WebPublica.Busqueda Busqueda = new ReglasDENegocio.WebPublica.Busqueda();
            Busqueda.Insertar(texto);
        }


        public System.Collections.ObjectModel.ReadOnlyCollection<double> Buscar(string texto)
        {
            ReglasDENegocio.WebPublica.Busqueda Busqueda = null;

            try
            {
                Busqueda = new ReglasDENegocio.WebPublica.Busqueda();

                // TODO: QUITAR PALABRAS RESERVADAS

                // Quitar caracteres reservados
                texto = ValidacionesComunes.Limpieza.EliminarCaracteresReservados(texto);

                // Remover los espacios en blanco al inicio y al final de la cadena
                texto = texto.Trim();

                // Remover los excesos de despacios en blanco
                texto = System.Text.RegularExpressions.Regex.Replace(texto, @"\s+", " "); 

                return Busqueda.Buscar(texto);
            }
            catch (Exception ex)
            {
                Logging.ErrorGeneral.Guardar(ex);
            }

            return null;
        }

        public string GenerarConsultaSQL(string textoBusqueda)
        {
            ReglasDENegocio.WebPublica.Busqueda Busqueda = new ReglasDENegocio.WebPublica.Busqueda();
            return Busqueda.GenerarConsultaSQL(textoBusqueda);
        }
    }
}
