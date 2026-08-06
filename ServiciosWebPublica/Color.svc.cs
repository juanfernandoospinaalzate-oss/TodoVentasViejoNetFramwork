namespace ServiciosWebPublica
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Color" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Color.svc o Color.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Color : ContratosWeb.IColor
    {
        public void DoWork()
        {
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Color> ListaColores()
        {
            Validacion.WebPublica.Color Color = new Validacion.WebPublica.Color();
            return Color.ListaColores();
        }
    }
}
