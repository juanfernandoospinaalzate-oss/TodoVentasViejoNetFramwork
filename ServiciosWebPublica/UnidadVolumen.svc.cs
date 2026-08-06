namespace ServiciosWebPublica
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "UnidadVolumen" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione UnidadVolumen.svc o UnidadVolumen.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class UnidadVolumen : ContratosWeb.IUnidadVolumen
    {

        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.UnidadVolumen> ListaUnidadVolumen()
        {
            Validacion.WebPublica.UnidadVolumen UnidadVolumen = new Validacion.WebPublica.UnidadVolumen();
            return UnidadVolumen.ListaUnidadVolumen();
        }
    }
}
