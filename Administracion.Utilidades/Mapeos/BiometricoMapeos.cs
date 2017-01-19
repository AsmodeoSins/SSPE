using Administracion.OTD;
using Administracion.Modelos.Entidades;
using AutoMapper;
using System.Collections.Generic;
using Administracion.Utilidades.Controles;
using Administracion.Enum;

namespace Administracion.Utilidades.Mapeos
{
    public static class BiometricoMapeos
    {
        public static PERSONA_BIOMETRICO MapearPersonaEntidad(BiometricoOtd biometrico)
        {
            return Mapper.Map<PERSONA_BIOMETRICO>(biometrico);
        }

        public static IMPUTADO_BIOMETRICO MapearImputadoEntidad(BiometricoOtd biometrico)
        {
            return Mapper.Map<IMPUTADO_BIOMETRICO>(biometrico);
        }

        public static void MapearEmpleadoBiometrias(IList<PERSONA_BIOMETRICO> biometricos, PersonaOtd persona)
        {
            var biometrias = Mapper.Map<IList<BiometricoOtd>>(biometricos);

            persona.Biometricos = biometrias;

            foreach (var biometrico in biometrias)
            {
                if (biometrico.Tipo == TipoBiometrico.FotoFrenteRegistro)
                {
                    persona.Foto = Convertidor.ConvertirBinarioImagen(biometrico.Biometrico);
                }

                if (biometrico.Tipo == TipoBiometrico.OjoDerecho || biometrico.Tipo == TipoBiometrico.OjoIzquierdo)
                {
                    persona.BiometriaRegistrada = true;
                }
            }
        }
    }
}
