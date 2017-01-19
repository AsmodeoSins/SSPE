
namespace Administracion.Utilidades.ClasesAuxiliares
{
    public static class CodificadorBase64
    {
        /// <summary>
        /// Codifica un string a base 64
        /// </summary>
        /// <param name="stringACodificar">String que se codificara a formato base64</param>
        /// <returns>String base64</returns>
        public static string CodificarABase64(string stringACodificar)
        {
            byte[] bytes
                  = System.Text.ASCIIEncoding.ASCII.GetBytes(stringACodificar);
            string valorARegresar
                  = System.Convert.ToBase64String(bytes);
            return valorARegresar;
        }

        /// <summary>
        /// Decodifica un string base64
        /// </summary>
        /// <param name="stringADecodificar">String que se decodificara</param>
        /// <returns>String decodificado</returns>
        public static string DecodificarDeBase64(string stringADecodificar)
        {
            byte[] bytes
                = System.Convert.FromBase64String(stringADecodificar);
            string valorARegresar =
               System.Text.ASCIIEncoding.ASCII.GetString(bytes);
            return valorARegresar;
        }
    }
}
