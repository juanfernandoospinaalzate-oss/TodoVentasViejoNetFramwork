namespace ServiciosWebPublica
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Busqueda" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Busqueda.svc o Busqueda.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Busqueda : ContratosWeb.IBusqueda
    {

        public System.Collections.ObjectModel.ReadOnlyCollection<string> Listar(string texto)
        {
            Validacion.WebPublica.Busqueda Busqueda = new Validacion.WebPublica.Busqueda();
            return Busqueda.Listar(texto);
        }


        public void Insertar(string texto)
        {
            Validacion.WebPublica.Busqueda Busqueda = new Validacion.WebPublica.Busqueda();
            Busqueda.Insertar(texto);
        }


        public System.Collections.ObjectModel.ReadOnlyCollection<double> Buscar(string texto)
        {
            Validacion.WebPublica.Busqueda ServicioBusqueda = null;

            try
            {
                ServicioBusqueda = new Validacion.WebPublica.Busqueda();
                return ServicioBusqueda.Buscar(texto);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Logging.ErrorGeneral.Guardar(ex);
                return null;
            }            
        }

        public string GenerarConsultaSQL(string textoBusqueda)
        {
            Validacion.WebPublica.Busqueda Busqueda = new Validacion.WebPublica.Busqueda();
            return Busqueda.GenerarConsultaSQL(textoBusqueda);
        }
    }
}
