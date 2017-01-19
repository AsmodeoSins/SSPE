using Administracion.OTD;
using Administracion.Modelos.Entidades;
using AutoMapper;
using System.Collections.Generic;

namespace Administracion.Utilidades.Mapeos
{
    public static class ImputadoBiometricoMapeos
    {
        public static IMPUTADO_BIOMETRICO MapearEntidad(ImputadoBiometricoOtd imputadoBiometrico)
        {
            return Mapper.Map<IMPUTADO_BIOMETRICO>(imputadoBiometrico);
        }

        public static ImputadoBiometricoOtd MapearModelo(IMPUTADO_BIOMETRICO imputadoBiometrico)
        {
            return Mapper.Map<ImputadoBiometricoOtd>(imputadoBiometrico);
        }

        public static IList<ImputadoBiometricoOtd> MapearListaDeModelos(IList<IMPUTADO_BIOMETRICO> imputadosBiometricos)
        {
            return Mapper.Map<IList<IMPUTADO_BIOMETRICO>, IList<ImputadoBiometricoOtd>>(imputadosBiometricos);
        }
    }
}
