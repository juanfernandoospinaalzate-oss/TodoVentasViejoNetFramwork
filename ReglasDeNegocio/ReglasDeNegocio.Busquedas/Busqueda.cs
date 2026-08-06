// -----------------------------------------------------------------------
// <copyright file="Busqueda.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace ReglaDENegocio.Busquedas
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Entidades;
    using Entidades.Enumeraciones;

    public class Busqueda : Contratos.IBusqueda
    {
        public Entidades.ResultadoTransaccion Aprobar()
        {
            throw new NotImplementedException();
        }

        public ReadOnlyCollection<Entidades.Articulo> Buscar(string texto, System.Collections.ObjectModel.ReadOnlyCollection<double> idArticulos)
        {
            AccesoDatos.Busquedas.Busqueda Busqueda = null;
            System.Collections.ObjectModel.ReadOnlyCollection<double> idArticulosRecortadoSoloLectura = null;

            try
            {
                Busqueda = new AccesoDatos.Busquedas.Busqueda();
                idArticulosRecortadoSoloLectura = this.RecortarListadoArticulos(idArticulos);
                return Busqueda.Buscar(string.Empty, idArticulosRecortadoSoloLectura);
            }
            catch (Exception ex)
            {
                Logging.ErrorGeneral.Guardar(ex);
            }

            return null;
        }

        public ReadOnlyCollection<Articulo> BuscarPorEstado(string texto, ReadOnlyCollection<double> idArticulos, Estado estado)
        {
            AccesoDatos.Busquedas.Busqueda Busqueda = null;
            System.Collections.ObjectModel.ReadOnlyCollection<double> idArticulosRecortadoSoloLectura = null;

            try
            {
                Busqueda = new AccesoDatos.Busquedas.Busqueda();
                idArticulosRecortadoSoloLectura = this.RecortarListadoArticulos(idArticulos);
                return Busqueda.BuscarPorEstado(string.Empty, idArticulosRecortadoSoloLectura, estado);
            }
            catch (Exception ex)
            {
                Logging.ErrorGeneral.Guardar(ex);
            }

            return null;
        }

        private System.Collections.ObjectModel.ReadOnlyCollection<double> RecortarListadoArticulos(ReadOnlyCollection<double> idArticulos)
        {
            int i = 0;
            int cantidadArticulos = idArticulos.Count;
            List<double> idArticulosRecortado = new List<double>();

            while (i < 50 && i < cantidadArticulos)
            {
                idArticulosRecortado.Add(idArticulos[i]);
                i++;
            }

            return new ReadOnlyCollection<double>(idArticulosRecortado);
        }

        public Entidades.ResultadoTransaccion Eliminar()
        {
            throw new NotImplementedException();
        }

        public ReadOnlyCollection<Entidades.Busqueda> Listar(bool Eliminado, bool Aprobado)
        {
            throw new NotImplementedException();
        }
    }
}
