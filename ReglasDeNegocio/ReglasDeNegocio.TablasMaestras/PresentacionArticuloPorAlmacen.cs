namespace ReglasDENegocio.TablasMaestras
{
    public class PresentacionArticuloPorAlmacen : Contratos.IPresentacionArticuloPorAlmacen
    {
        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.PresentacionArticuloPorAlmacen> Listar()
        {
            AccesoDatos.TablasMaestras.PresentacionArticuloPorAlmacen PresentacionArticuloPorAlmacen = new AccesoDatos.TablasMaestras.PresentacionArticuloPorAlmacen();
            return PresentacionArticuloPorAlmacen.Listar();
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.PresentacionArticuloPorAlmacen> ListarPresentacionArticulo()
        {
            AccesoDatos.TablasMaestras.PresentacionArticuloPorAlmacen PresentacionArticuloPorAlmacen = new AccesoDatos.TablasMaestras.PresentacionArticuloPorAlmacen();
            return PresentacionArticuloPorAlmacen.ListarPresentacionArticulo();
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.PresentacionArticuloPorAlmacen> ListarPresentacionArticuloPorAlmacen(int idAlmacen)
        {
            AccesoDatos.TablasMaestras.PresentacionArticuloPorAlmacen PresentacionArticuloPorAlmacen = new AccesoDatos.TablasMaestras.PresentacionArticuloPorAlmacen();
            return PresentacionArticuloPorAlmacen.ListarPresentacionArticuloPorAlmacen(idAlmacen);
        }

        public Entidades.ResultadoTransaccion Actualizar(Entidades.PresentacionArticuloPorAlmacen presentacionArticuloPorAlmacen, Entidades.PresentacionArticuloPorAlmacen presentacionArticuloPorAlmacenDestino, int unidadesTransferidas)
        {
            AccesoDatos.TablasMaestras.PresentacionArticuloPorAlmacen PresentacionArticuloPorAlmacen = new AccesoDatos.TablasMaestras.PresentacionArticuloPorAlmacen();

            if (unidadesTransferidas > presentacionArticuloPorAlmacen.Existencia)
            {
                // Mostrar mensaje indicando que no se puede realizar dicha accion. la cantidad a transferir ha sido excedida.
            }
            else
            {
                presentacionArticuloPorAlmacen.Existencia -= unidadesTransferidas;
                presentacionArticuloPorAlmacenDestino.Existencia += unidadesTransferidas;
            }

            return PresentacionArticuloPorAlmacen.Actualizar(presentacionArticuloPorAlmacen, presentacionArticuloPorAlmacenDestino, unidadesTransferidas);
        }

        public Entidades.ResultadoTransaccion Eliminar(int idPresentacionArticuloPorAlmacen)
        {
            AccesoDatos.TablasMaestras.PresentacionArticuloPorAlmacen PresentacionArticuloPorAlmacen = new AccesoDatos.TablasMaestras.PresentacionArticuloPorAlmacen();
            return PresentacionArticuloPorAlmacen.Eliminar(idPresentacionArticuloPorAlmacen);
        }

        public Entidades.ResultadoTransaccion Insertar(Entidades.PresentacionArticuloPorAlmacen presentacionArticuloPorAlmacen, Entidades.PresentacionArticuloPorAlmacen presentacionArticuloPorAlmacenDestino, int unidadesTransferidas)
        {
            AccesoDatos.TablasMaestras.PresentacionArticuloPorAlmacen PresentacionArticuloPorAlmacen = new AccesoDatos.TablasMaestras.PresentacionArticuloPorAlmacen();

            if (unidadesTransferidas > presentacionArticuloPorAlmacen.Existencia)
            {
                // Mostrar mensaje indicando que no se puede realizar dicha accion. la cantidad a transferir ha sido excedida.
            }
            else
            {
                int totalDespuesDescuento = presentacionArticuloPorAlmacen.Existencia - unidadesTransferidas;
                presentacionArticuloPorAlmacen.Existencia = totalDespuesDescuento;

                int totalDespuesIncremento = unidadesTransferidas;
                presentacionArticuloPorAlmacenDestino.Existencia = totalDespuesIncremento;
            }



            return PresentacionArticuloPorAlmacen.Insertar(presentacionArticuloPorAlmacen, presentacionArticuloPorAlmacenDestino, unidadesTransferidas);
        }

        public Entidades.ResultadoTransaccion ActualizarII(Entidades.PresentacionArticuloPorAlmacen presentacionArticuloPorAlmacen, Entidades.PresentacionArticuloPorAlmacen presentacionArticuloPorAlmacenDestino, int unidadesTransferidas)
        {
            AccesoDatos.TablasMaestras.PresentacionArticuloPorAlmacen PresentacionArticuloPorAlmacen = new AccesoDatos.TablasMaestras.PresentacionArticuloPorAlmacen();
            if (unidadesTransferidas > presentacionArticuloPorAlmacen.Existencia)
            {
                // Mostrar mensaje indicando que no se puede realizar dicha accion. la cantidad a transferir ha sido excedida.
            }
            else
            {
                int totalDespuesDescuento = presentacionArticuloPorAlmacen.Existencia - unidadesTransferidas;
                presentacionArticuloPorAlmacen.Existencia = totalDespuesDescuento;

                int totalDespuesIncremento = presentacionArticuloPorAlmacenDestino.Existencia + unidadesTransferidas;
                presentacionArticuloPorAlmacenDestino.Existencia = totalDespuesIncremento;
            }


            return PresentacionArticuloPorAlmacen.ActualizarII(presentacionArticuloPorAlmacen, presentacionArticuloPorAlmacenDestino, unidadesTransferidas);
        }

        public Entidades.ResultadoTransaccion InsertarII(Entidades.PresentacionArticuloPorAlmacen presentacionArticuloPorAlmacen, Entidades.PresentacionArticuloPorAlmacen presentacionArticuloPorAlmacenDestino, int unidadesTransferidas)
        {
            AccesoDatos.TablasMaestras.PresentacionArticuloPorAlmacen PresentacionArticuloPorAlmacen = new AccesoDatos.TablasMaestras.PresentacionArticuloPorAlmacen();

            if (unidadesTransferidas > presentacionArticuloPorAlmacen.Existencia)
            {
                // Mostrar mensaje indicando que no se puede realizar dicha accion. la cantidad a transferir ha sido excedida.
            }
            else
            {
                int totalDespuesDescuento = presentacionArticuloPorAlmacen.Existencia - unidadesTransferidas;
                presentacionArticuloPorAlmacen.Existencia = totalDespuesDescuento;

                int totalDespuesIncremento = unidadesTransferidas;
                presentacionArticuloPorAlmacenDestino.Existencia = totalDespuesIncremento;
            }


            return PresentacionArticuloPorAlmacen.InsertarII(presentacionArticuloPorAlmacen, presentacionArticuloPorAlmacenDestino, unidadesTransferidas);
        }
    }
}
