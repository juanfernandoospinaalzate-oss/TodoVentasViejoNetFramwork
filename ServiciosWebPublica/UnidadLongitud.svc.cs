namespace ServiciosWebPublica
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "UnidadLongitud" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione UnidadLongitud.svc o UnidadLongitud.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class UnidadLongitud : ContratosWeb.IUnidadLongitud
    {
        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.UnidadLongitud> ListaUnidadLongitud()
        {
            Validacion.WebPublica.UnidadLongitud UnidadLongitud = new Validacion.WebPublica.UnidadLongitud();
            return UnidadLongitud.ListaUnidadLongitud();
        }
    }
}
