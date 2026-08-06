namespace ServiciosWeb.TablasMaestras
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Ciudad" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Ciudad.svc o Ciudad.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Ciudad : Contratos.ICiudad
    {
        public Entidades.ResultadoTransaccion Insertar(Entidades.Ciudad ciudad)
        {
            Validacion.TablasMaestras.Ciudad Ciudad = new Validacion.TablasMaestras.Ciudad();
            return Ciudad.Insertar(ciudad);
        }


        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Ciudad> Listar(int idDpto)
        {
            Validacion.TablasMaestras.Ciudad Ciudad = new Validacion.TablasMaestras.Ciudad();
            return Ciudad.Listar(idDpto);
        }


        public Entidades.ResultadoTransaccion Eliminar(int idCiudad)
        {
            Validacion.TablasMaestras.Ciudad Ciudad = new Validacion.TablasMaestras.Ciudad();
            return Ciudad.Eliminar(idCiudad);
        }


        public Entidades.ResultadoTransaccion Actualizar(Entidades.Ciudad ciudad)
        {
            Validacion.TablasMaestras.Ciudad Ciudad = new Validacion.TablasMaestras.Ciudad();
            return Ciudad.Actualizar(ciudad);
        }
    }
}
