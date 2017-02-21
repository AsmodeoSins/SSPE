using System;
using System.Collections.Generic;
using System.Text;

namespace SSPE.Tools.iCam7000Wrapper
{
    static class Constants
    {
        public const string API_UNSUPPORTED_ERROR = @"Esta API carece de soporte";
        public const string TIMEOUT_ERROR = @"La captura de iris actual ha expirado";
        public const string LICENSE_ERROR = @"Error en la licencia";
        public const string IMP_VERSION_ERROR = @"Error en la version de IMP";
        public const string PARAMETER_ERROR = @"Error de parametros";
        public const string ICAM_FAILURE = @"Ha ocurrido un error mientras iCam capturaba las iris";
        public const string AUTHENTICATION_ERROR = @"Error de autenticacion";
        public const string SOCKET_ERROR = @"Error de socket";
        public const string CLOSE_ERROR = @"Error al intentar cerrar iCam";
        public const string OPEN_ERROR = @"No se puede conectar a iCam";
        public const string WIEGAND_OUT_DISABLED_ERROR = @"Wiegand out esta deshabilitado";
        public const string RELAY_ALREADY_OPEN_ERROR = @"El relay ya se encuentra abierto";
        public const string LOW_ICAM_VERSION_ERROR = @"Se encontro una version antigua del software de iCAM y/o el sistema de archivos";
        public const string UPGRADE_NOT_REQUIRE = @"iCam ya esta usando la ultima version de software";
        public const string UPGRADE_FAILED = @"Error al actualizar";
        public const string UPGRADE_OBSOLETE_DAT_FILES_ERROR = @"Archivos DAT obsoletos";
        public const string UPGRADE_ALREADY_OPEN_ERROR = @"No se puede actualizar por que iCam esta en uso";
        public const string UNKNOWN_ERROR = @"Error desconocido";
    }
}
