namespace ServiciosWeb.TablasMaestras
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Departamento" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Departamento.svc o Departamento.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Departamento : Contratos.IDepartamento
    {

        public Entidades.ResultadoTransaccion Insertar(Entidades.Departamento departamento)
        {
            Validacion.TablasMaestras.Departamento Departamento = new Validacion.TablasMaestras.Departamento();
            return Departamento.Insertar(departamento);
        }


        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Departamento> Listar(int idPais)
        {
            Validacion.TablasMaestras.Departamento Departamento = new Validacion.TablasMaestras.Departamento();
            return Departamento.Listar(idPais);
        }


        public Entidades.ResultadoTransaccion Actualizar(Entidades.Departamento departamento)
        {
            Validacion.TablasMaestras.Departamento Departamento = new Validacion.TablasMaestras.Departamento();
            return Departamento.Actualizar(departamento);
        }


        public Entidades.ResultadoTransaccion Eliminar(int idDepartamento)
        {
            Validacion.TablasMaestras.Departamento Departamento = new Validacion.TablasMaestras.Departamento();
            return Departamento.Eliminar(idDepartamento);
        }
    }
}
