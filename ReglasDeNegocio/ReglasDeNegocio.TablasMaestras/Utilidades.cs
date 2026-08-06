namespace ReglasDENegocio.TablasMaestras
{
    public static class Utilidades
    {
        public static string QuitaAcentos(string texto)
        {
            string con = "áàäéèëíìïóòöúùuñÁÀÄÉÈËÍÌÏÓÒÖÚÙÜÑ";
            string sin = "aaaeeeiiiooouuunAAAEEEIIIOOOUUUN";
            for (int i = 0; i < con.Length; i++)
            {
                texto = texto.Replace(con[i], sin[i]);
            }
            return texto;
        }
    }
}
