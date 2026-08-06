// -----------------------------------------------------------------------
// <copyright file="ControlTransparente.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// ----------------------------------------------------------------------

namespace Controles.WinForms
{
    /// <summary>
    /// Cubre otros controles previniendo al usuario interactuar con el control protegido
    /// </summary>
    public class ControlTransparente : System.Windows.Forms.Control
    {
        /// <summary>
        /// Solo lectura obtiene la configuración del control
        /// </summary>
        protected override System.Windows.Forms.CreateParams CreateParams
        {
            get
            {
                System.Windows.Forms.CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x20;
                return cp;
            }
        }

        /// <summary>
        /// Procedimiento que no hace nada
        /// </summary>
        /// <param name="pevent">el parámetro no es utilizado</param>
        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs pevent)
        {
            // base.OnPaintBackground(pevent);
        }

        /// <summary>
        /// Dispara cuando el control es "Dibujado"
        /// </summary>
        /// <param name="e">El argumento del evento se utiliza para especificar el suavizado de contorno</param>
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        }
    }
}
