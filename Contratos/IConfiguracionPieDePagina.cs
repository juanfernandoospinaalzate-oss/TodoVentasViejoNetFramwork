//-----------------------------------------------------------------------
// <copyright file="IConfiguracionPieDePagina.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace Contratos
{
    using System.ServiceModel;

    [ServiceContract]
    public interface IConfiguracionPieDePagina
    {
        [OperationContract]
        Entidades.ResultadoTransaccion Insertar(Entidades.ConfiguracionPieDePagina PieDePagina);

        [OperationContract]
        System.Collections.ObjectModel.ReadOnlyCollection<Entidades.ConfiguracionPieDePagina> Listar();

        [OperationContract]
        Entidades.ResultadoTransaccion Actualizar(Entidades.ConfiguracionPieDePagina PieDePagina);
    }
}
