namespace ServiciosWebPublica
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Talla" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Talla.svc o Talla.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Talla : ContratosWeb.ITalla
    {
        public void DoWork()
        {
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Talla> ListaTallas()
        {
            Validacion.WebPublica.Talla Talla = new Validacion.WebPublica.Talla();
            return Talla.ListaTallas();
        }
    }
}
