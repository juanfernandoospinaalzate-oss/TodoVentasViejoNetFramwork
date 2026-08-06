// -----------------------------------------------------------------------
// <copyright file="Program.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace Presentacion.Inventario
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Representa una instancia de software de inventario
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Application.Run(new Form1());
        }
    }
}
