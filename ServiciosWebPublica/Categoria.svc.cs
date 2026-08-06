

namespace ServiciosWebPublica
{
    using System.Collections.ObjectModel;

    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Categoria" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Categoria.svc o Categoria.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Categoria : ContratosWeb.ICategoria
    {

        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Categoria> Listar()
        {
            Validacion.WebPublica.Categoria Categoria = new Validacion.WebPublica.Categoria();
            return Categoria.Listar();
        }

        public ReadOnlyCollection<EntidadesWeb.Categoria> ListarCategoriasUsadas()
        {
            Validacion.WebPublica.Categoria Categoria = new Validacion.WebPublica.Categoria();
            return Categoria.ListarCategoriasUsadas();
        }
    }
}
