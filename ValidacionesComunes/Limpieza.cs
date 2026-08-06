// -----------------------------------------------------------------------
// <copyright file="Limpieza.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace ValidacionesComunes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public static class Limpieza
    {
        /// <summary>
        /// Quita los caracteres reservados usados en código ejecutable
        /// </summary>
        /// <param name="texto"></param>
        /// <returns></returns>
        public static string EliminarCaracteresReservados(string texto)
        {
            List<char> caracteresReservados = "|!*'();:@&=+$,/?%#[]{}\\<>\"=".ToList();

            for (int i = 0; i < caracteresReservados.Count; i++)
            {
                texto = texto.Replace(caracteresReservados[i].ToString(), string.Empty);
            }

            return texto;
        }
        
        public static string EliminarPalabrasReservadas(string texto)
        {
            // TODO: IMPLEMENTAR
            // SELECT
            // ELSE
            // DBMS
            // WHEN
            // CAST
            // CHR
            // THEN
            // CHAR
            // CONCAT
            // DELETE
            // UPDATE
            // FROM
            // MESSAGE
            // ORDER
            // UNION
            // ANALYSE
            // ROW
            // HAVING
            // JSON
            // USING
            // utf8
            // sleep
            // drop table
            // waitfor
            // order
            throw new NotImplementedException();
        }
    }
}
