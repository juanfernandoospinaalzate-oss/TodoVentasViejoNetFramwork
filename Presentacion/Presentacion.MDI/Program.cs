// -----------------------------------------------------------------------
// <copyright file="Program.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace Presentacion.Mdi
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Representa el programa principal Winforms
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += ApplicationThreadException;
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainUnhandledException;
            Application.Run(new PadreMdi());
        }

        /// <summary>
        /// Maneja los errores no controlados en la aplicación
        /// </summary>
        /// <param name="sender">Objeto que dispara el evento</param>
        /// <param name="e">Argumentos del evento</param>
        public static void CurrentDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Maneja los errores no controlados en la aplicación
        /// </summary>
        /// <param name="sender">Objeto que dispara el evento</param>
        /// <param name="e">Argumentos del evento</param>
        public static void ApplicationThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
           // Logging.LinqToXML.Guardar(
            Logging.ErrorGeneral.Guardar(e.Exception);
        }
    }
}
