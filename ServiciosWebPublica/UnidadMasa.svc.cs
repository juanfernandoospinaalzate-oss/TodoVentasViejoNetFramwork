namespace ServiciosWebPublica
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "UnidadMasa" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione UnidadMasa.svc o UnidadMasa.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class UnidadMasa : ContratosWeb.IUnidadMasa
    {
        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.UnidadMasa> ListaUnidadMasa()
        {
            Validacion.WebPublica.UnidadMasa UnidadMasa = new Validacion.WebPublica.UnidadMasa();
            return UnidadMasa.ListaUnidadMasa();
        }
    }
}
