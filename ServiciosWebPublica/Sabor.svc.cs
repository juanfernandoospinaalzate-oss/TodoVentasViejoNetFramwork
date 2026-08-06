namespace ServiciosWebPublica
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Sabor" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Sabor.svc o Sabor.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Sabor : ContratosWeb.ISabor
    {
        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Sabor> ListaSabores()
        {
            Validacion.WebPublica.Sabor Sabor = new Validacion.WebPublica.Sabor();
            return Sabor.ListaSabores();
        }
    }
}
