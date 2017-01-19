using Administracion.Modelos.Entidades;
using Administracion.OTD;
using AutoMapper;
using System.Collections.Generic;

namespace Administracion.Utilidades.Mapeos
{
    public static class UsuarioMapeos
    {
        public static IList<UsuarioOtd> MapearUsuarios(IEnumerable<USUARIO> usuarios)
        {
            return Mapper.Map<IList<UsuarioOtd>>(usuarios);
        }

        public static UsuarioOtd MapearUsuario(UsuarioOtd usuario)
        {
            return Mapper.Map<UsuarioOtd>(usuario);
        }
    }
}
