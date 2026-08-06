// -----------------------------------------------------------------------
// <copyright file="Sabor.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// ----------------------------------------------------------------------
namespace Fachada.TablasMaestras
{
    /// <summary>
    /// Formulario para la administración de sabores en la base de datos por operaciones CRUD
    /// </summary>
    public class Sabor : Contratos.ISabor
    {
        public Entidades.ResultadoTransaccion Insertar(Entidades.Sabor sabor)
        {
            ServicioSabor.SaborClient Sabor = new ServicioSabor.SaborClient();
            return Sabor.Insertar(sabor);
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Sabor> Listar()
        {
            ServicioSabor.SaborClient Sabor = new ServicioSabor.SaborClient();
            return Sabor.Listar();
        }

        public Entidades.ResultadoTransaccion Eliminar(int idsabor)
        {
            ServicioSabor.SaborClient Sabor = new ServicioSabor.SaborClient();
            return Sabor.Eliminar(idsabor);
        }

        public Entidades.ResultadoTransaccion Actualizar(Entidades.Sabor sabor)
        {
            ServicioSabor.SaborClient Sabor = new ServicioSabor.SaborClient();
            return Sabor.Actualizar(sabor);
        }
    }
}
