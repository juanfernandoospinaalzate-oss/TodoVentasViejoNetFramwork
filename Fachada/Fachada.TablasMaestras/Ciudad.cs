

namespace Fachada.TablasMaestras
{
    using System;

    public class Ciudad : Contratos.ICiudad
    {
        public Entidades.ResultadoTransaccion Insertar(Entidades.Ciudad ciudad)
        {
            ServicioCiudad.CiudadClient Ciudad = new ServicioCiudad.CiudadClient();
            return Ciudad.Insertar(ciudad);
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Ciudad> Listar(int idDpto)
        {
            ServicioCiudad.CiudadClient Ciudad = null;
            System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Ciudad> listaReadOnlyCiudad = null;
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

            try
            {
                Ciudad = new ServicioCiudad.CiudadClient();
                listaReadOnlyCiudad = Ciudad.Listar(idDpto);
            }
            catch (System.Data.SqlClient.SqlException)
            {
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
            }
            catch (Entidades.Excepciones.ExceptionErrorTransaccion)
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
            }
            finally
            {
                if (Ciudad != null)
                {
                    ((IDisposable)Ciudad).Dispose();
                }
            }

            return listaReadOnlyCiudad;
        }


        public Entidades.ResultadoTransaccion Eliminar(int idCiudad)
        {
            ServicioCiudad.CiudadClient Ciudad = new ServicioCiudad.CiudadClient();
            return Ciudad.Eliminar(idCiudad);
        }


        public Entidades.ResultadoTransaccion Actualizar(Entidades.Ciudad ciudad)
        {
            ServicioCiudad.CiudadClient Ciudad = new ServicioCiudad.CiudadClient();
            return Ciudad.Actualizar(ciudad);
        }
    }
}
