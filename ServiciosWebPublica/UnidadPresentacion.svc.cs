namespace ServiciosWebPublica
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "UnidadPresentacion" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione UnidadPresentacion.svc o UnidadPresentacion.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class UnidadPresentacion : ContratosWeb.IUnidadPresentacion
    {

        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.UnidadPresentacion> Listar()
        {
            Validacion.WebPublica.UnidadPresentacion unidadPresentacion = new Validacion.WebPublica.UnidadPresentacion();
            return unidadPresentacion.Listar();
        }
    }
}
