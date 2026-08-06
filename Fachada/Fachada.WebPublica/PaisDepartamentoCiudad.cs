

namespace Fachada.WebPublica
{
    using System;

    public class PaisDepartamentoCiudad : ContratosWeb.IPaisDepartamentoCiudad
    {
        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Pais> ListarPais()
        {
            ServicioPaisDepartamentoCiudad.PaisDepartamentoCiudadClient PaisDepartamentoCiudad = new ServicioPaisDepartamentoCiudad.PaisDepartamentoCiudadClient();
            return PaisDepartamentoCiudad.ListarPais();
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Departamento> ListarDepartamento(int idPais)
        {
            ServicioPaisDepartamentoCiudad.PaisDepartamentoCiudadClient PaisDepartamentoCiudad = null;
            System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Departamento> listaReadOnlyDepartamento = null;
            EntidadesWeb.ResultadoTransaccion resultadoTransaccion = new EntidadesWeb.ResultadoTransaccion();

            try
            {
                PaisDepartamentoCiudad = new ServicioPaisDepartamentoCiudad.PaisDepartamentoCiudadClient();
                listaReadOnlyDepartamento = PaisDepartamentoCiudad.ListarDepartamento(idPais);
            }
            catch (System.Data.SqlClient.SqlException)
            {
                Logging.ErrorGeneral.Guardar(new EntidadesWeb.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
            }
            catch (EntidadesWeb.Excepciones.ExceptionErrorTransaccion)
            {
                resultadoTransaccion.Mensaje = MensajesWeb.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new EntidadesWeb.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
            }
            finally
            {
                if (PaisDepartamentoCiudad != null)
                {
                    ((IDisposable)PaisDepartamentoCiudad).Dispose();
                }
            }

            return listaReadOnlyDepartamento;
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Ciudad> ListarCiudad(int IdDpto)
        {
            ServicioPaisDepartamentoCiudad.PaisDepartamentoCiudadClient PaisDepartamentoCiudad = null;
            System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Ciudad> listaReadOnlyCiudad = null;
            EntidadesWeb.ResultadoTransaccion resultadoTransaccion = new EntidadesWeb.ResultadoTransaccion();

            try
            {
                PaisDepartamentoCiudad = new ServicioPaisDepartamentoCiudad.PaisDepartamentoCiudadClient();
                listaReadOnlyCiudad = PaisDepartamentoCiudad.ListarCiudad(IdDpto);
            }
            catch (System.Data.SqlClient.SqlException)
            {
                Logging.ErrorGeneral.Guardar(new EntidadesWeb.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
            }
            catch (EntidadesWeb.Excepciones.ExceptionErrorTransaccion)
            {
                resultadoTransaccion.Mensaje = MensajesWeb.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new EntidadesWeb.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
            }
            finally
            {
                if (PaisDepartamentoCiudad != null)
                {
                    ((IDisposable)PaisDepartamentoCiudad).Dispose();
                }
            }

            return listaReadOnlyCiudad;
        }
    }
}
