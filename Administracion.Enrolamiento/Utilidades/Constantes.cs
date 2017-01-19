using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administracion.Enrolamiento
{
    public class Constantes
    {
        public const string BIOSERVER_NO_CONECTADO = "Servidor Biometrico No Conectado...";

        public const string BUSCANDO_PERSONAS = "Buscando Imputados o Custodios para Enrolar...";

        public const string ENROLADO = "Enrolado {0} {1} con Folio {2}";

        public const string IDENTIFICADO = "Identificado {0} {1} con Folio {2}";

        public const string CENTRO_REQUERIDO = "El Identificador del Centro es Requerido.";

        public const string CONEXION_BD_FALLIDA = "La Conexion a la Base de Datos Fallo. Verifique los Datos.";

        public const string BIOSERVER_NO_ENCONTRADO = "El Servicio {0} no se encontro. Verifique el servicio.";

        public const string NO_HAY_PERSONAS = "No se Encontraron Personas con Biometria de IRIS para Enrolar.";

        public const string VALIDANDO_BD = "Validando Conexion de Base de Datos...";

        public const string VALIDANDO_BIOSERVER = "Validando Conexion de Servidor Biometrico...";

        public const string CONECTANDO_BIOSERVER = "Conectando con el Servidor Biometrico...";

        public const string ENROLAMIENTO_COMPLETADO = "Proceso de Enrolamiento Completado Exitosamente !";

        public const string ERROR = "Ocurrio un error. Contacte a su Administrador. Error: {0}";
    }
}
