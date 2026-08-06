
namespace ServiciosWeb.Facturacion
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using Entidades;
    using Entidades.Enumeraciones;

    public class OrdenesCompra : Contratos.IOrdenesCompra
    {
        public Entidades.ResultadoTransaccion ConfirmarOrdenCompra(List<PresentacionArticulo> listaPresentacionArticulo, Cliente cliente, int IdAlbaran)
        {
            Validacion.Facturacion.OrdenesCompra objOrdenesCompra = new Validacion.Facturacion.OrdenesCompra();
            Entidades.ResultadoTransaccion resultado = new Entidades.ResultadoTransaccion();

            List<Entidades.Marca> ListaMarca = new List<Entidades.Marca>();
            Validacion.TablasMaestras.Marca Marca = new Validacion.TablasMaestras.Marca();
            ListaMarca = Marca.ListarOrdenadoPorIdMarca().ToList();

            return objOrdenesCompra.ConfirmarOrdenCompra(listaPresentacionArticulo, cliente, IdAlbaran);
        }

        public Entidades.ResultadoTransaccion EliminarOrdenCompraLogico(int IdAlbaran)
        {
            Validacion.Facturacion.OrdenesCompra objOrdenesCompra = new Validacion.Facturacion.OrdenesCompra();
            return objOrdenesCompra.EliminarOrdenCompraLogico(IdAlbaran);
        }

        public int GenerarOrdenCompra(List<PresentacionArticulo> listaPresentacionArticulo, Cliente cliente)
        {
            Validacion.Facturacion.OrdenesCompra objOrdenesCompra = new Validacion.Facturacion.OrdenesCompra();
            
            List<Entidades.Marca> ListaMarca = new List<Entidades.Marca>();
            Validacion.TablasMaestras.Marca Marca = new Validacion.TablasMaestras.Marca();
            ListaMarca = Marca.ListarOrdenadoPorIdMarca().ToList();

            // Recorrer las presentaciones
            int i = 0;
            while (i < listaPresentacionArticulo.Count)
            {
                int auxExistencias = listaPresentacionArticulo[i].Existencias;
                double auxPrecio = listaPresentacionArticulo[i].Precio;
                Validacion.TablasMaestras.PresentacionArticulo ObjPresentacionArticulo = new Validacion.TablasMaestras.PresentacionArticulo();
                listaPresentacionArticulo[i] = ObjPresentacionArticulo.ConsultarPorId(listaPresentacionArticulo[i].IdPresentacionArticulo);
                listaPresentacionArticulo[i].Existencias = auxExistencias; // Tocó sobre escribir campo una vez ejecuta el método ConsultarPorId ya que este trae todas las existencias y no las capturadas por pantalla.
                listaPresentacionArticulo[i].Precio = auxPrecio;
                i++;
            }

            return objOrdenesCompra.GenerarOrdenCompra(listaPresentacionArticulo, cliente);
        }


        public ReadOnlyCollection<Entidades.OrdenesCompra> ListarEncabezadoOrdenCompraPorIdentificador(OpcionConsultaOrdenCompra opcionBusqueda, string filtroBusqueda)
        {
            Validacion.Facturacion.OrdenesCompra objOrdenesCompra = new Validacion.Facturacion.OrdenesCompra();
            return objOrdenesCompra.ListarEncabezadoOrdenCompraPorIdentificador(opcionBusqueda, filtroBusqueda);
        }

        public ReadOnlyCollection<Entidades.OrdenesCompraDetalle> ListarOrdenesCompraDetallePorIdentificador(int IdAlbaran)
        {
            Validacion.Facturacion.OrdenesCompra objOrdenesCompra = new Validacion.Facturacion.OrdenesCompra();
            return objOrdenesCompra.ListarOrdenesCompraDetallePorIdentificador(IdAlbaran);
        }
    }
}
