namespace ServiciosWebPublica
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "PaisDepartamentoCiudad" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione PaisDepartamentoCiudad.svc o PaisDepartamentoCiudad.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class PaisDepartamentoCiudad : ContratosWeb.IPaisDepartamentoCiudad
    {

        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Pais> ListarPais()
        {
            Validacion.WebPublica.PaisDepartamentoCiudad PaisDepartamentoCiudad = new Validacion.WebPublica.PaisDepartamentoCiudad();
            return PaisDepartamentoCiudad.ListarPais();
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Departamento> ListarDepartamento(int idPais)
        {
            Validacion.WebPublica.PaisDepartamentoCiudad PaisDepartamentoCiudad = new Validacion.WebPublica.PaisDepartamentoCiudad();
            return PaisDepartamentoCiudad.ListarDepartamento(idPais);
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Ciudad> ListarCiudad(int IdDpto)
        {
            Validacion.WebPublica.PaisDepartamentoCiudad PaisDepartamentoCiudad = new Validacion.WebPublica.PaisDepartamentoCiudad();
            return PaisDepartamentoCiudad.ListarCiudad(IdDpto);
        }
    }
}
