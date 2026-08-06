

namespace Fachada.TablasMaestras
{
    using System;

    public class Departamento : Contratos.IDepartamento
    {
        public Entidades.ResultadoTransaccion Insertar(Entidades.Departamento departamento)
        {             
            ServicioDepartamento.DepartamentoClient servicioDepartamento = null;
            try
            {
                servicioDepartamento = new ServicioDepartamento.DepartamentoClient();
                servicioDepartamento.Close();
            }
            catch (Exception)
            {

                throw new Entidades.Excepciones.ExceptionErrorTransaccion("0016");
            }

            return servicioDepartamento.Insertar(departamento);
        }


        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Departamento> Listar(int idPais)
        {
            ServicioDepartamento.DepartamentoClient servicioDepartamento = null;
            System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Departamento> listaReadOnlyDepartamento = null;
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

            try
            {
                servicioDepartamento = new ServicioDepartamento.DepartamentoClient();
                listaReadOnlyDepartamento = servicioDepartamento.Listar(idPais);
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
                if (servicioDepartamento != null)
                {
                    ((IDisposable)servicioDepartamento).Dispose();
                }
            }

            return listaReadOnlyDepartamento;
        }


        public Entidades.ResultadoTransaccion Actualizar(Entidades.Departamento departamento)
        {
            ServicioDepartamento.DepartamentoClient servicioDepartamento = null;
            try
            {
                servicioDepartamento = new ServicioDepartamento.DepartamentoClient();
                servicioDepartamento.Close();
            }
            catch (Exception)
            {

                throw new Entidades.Excepciones.ExceptionErrorTransaccion("0016");
            }

            return servicioDepartamento.Actualizar(departamento);
        }


        public Entidades.ResultadoTransaccion Eliminar(int idDepartamento)
        {
            ServicioDepartamento.DepartamentoClient servicioDepartamento = null;
            try
            {
                servicioDepartamento = new ServicioDepartamento.DepartamentoClient();
                servicioDepartamento.Close();
            }
            catch (Exception)
            {

                throw new Entidades.Excepciones.ExceptionErrorTransaccion("0016");
            }

            return servicioDepartamento.Eliminar(idDepartamento);
        }
    }
}
