using Administracion.Contratos;
using Administracion.Contratos.Servicios;
using Administracion.Enum;
using Administracion.Modelos.Entidades;
using Administracion.OTD;
using Administracion.Utilidades;
using Administracion.Utilidades.ClasesAuxiliares;
using Administracion.Utilidades.Controles;
using Administracion.Utilidades.Mapeos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Administracion.Servicio
{
    public class PersonaServicio : ServicioBase, IPersonaServicio
    {
        private readonly IPersonaRepositorio _personaRepositorio;
        private readonly IImputadoRepositorio _imputadoRepositorio;
        private readonly IPersonaBiometricoRepositorio _personaBiometricoRepositorio;
        private readonly IImputadoBiometricoRepositorio _imputadoBiometricoRepositorio;
        private readonly IEmpleadoRepositorio _empleadoRepositorio;

        public PersonaServicio(IPersonaRepositorio personaRepositorio, IImputadoRepositorio imputadoRepositorio,
            IPersonaBiometricoRepositorio personaBiometricoRepositorio, IImputadoBiometricoRepositorio imputadoBiometricoRepositorio,
            IEmpleadoRepositorio empleadoRepositorio)
        {
            _personaRepositorio = personaRepositorio;
            _imputadoRepositorio = imputadoRepositorio;
            _personaBiometricoRepositorio = personaBiometricoRepositorio;
            _imputadoBiometricoRepositorio = imputadoBiometricoRepositorio;
            _empleadoRepositorio = empleadoRepositorio;
        }

        public IList<PersonaOtd> BuscarPersonaPorFiltro(PersonaFiltroOtd filtro, bool esVisita = false)
        {
            try
            {
                if (esVisita)
                    return BuscarPersonas(filtro);

                if (filtro.EsImputado)
                {
                    return BuscarImputado(filtro);
                }

                return BuscarPersonal(filtro);
            }
            catch (Exception ex)
            {
                throw ObtenerFalla(ex);
            }
        }

        public bool AsignarBiometria(PersonaOtd persona)
        {
            try
            {
                if (persona.EsImputado)
                {
                    return GuardarImputadoBiometrico(persona);
                }
                else
                {
                    return GuardarPersonaBiometrico(persona);
                }
            }
            catch (Exception ex)
            {
                throw ObtenerFalla(ex);
            }
        }

        public bool RemoverBiometrias(PersonaOtd persona)
        {
            try
            {
                if (persona.EsImputado)
                {
                    return RemoveImputadoBiometrico(persona);
                }
                else
                {
                    return RemoverPersonaBiometrico(persona);
                }
            }
            catch (Exception ex)
            {
                throw ObtenerFalla(ex);
            }
        }

        private bool RemoveImputadoBiometrico(PersonaOtd persona)
        {
            try
            {
                var biometricos = _imputadoBiometricoRepositorio.EncontrarPor(b => b.ID_ANIO == persona.IdAnio && b.ID_IMPUTADO == persona.Id);

                foreach (var biometrico in biometricos)
                {
                    if (biometrico.ID_TIPO_BIOMETRICO == (short)TipoBiometrico.OjoDerecho || biometrico.ID_TIPO_BIOMETRICO == (short)TipoBiometrico.OjoIzquierdo)
                    {
                        _imputadoBiometricoRepositorio.Eliminar(biometrico);
                        _imputadoBiometricoRepositorio.Guardar();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ObtenerFalla(ex);
            }
        }

        private bool RemoverPersonaBiometrico(PersonaOtd persona)
        {
            try
            {
                var biometricos = _personaBiometricoRepositorio.EncontrarPor(p => p.ID_PERSONA == persona.Id);

                foreach (var biometrico in biometricos)
                {
                    if (biometrico.ID_TIPO_BIOMETRICO == (short)TipoBiometrico.OjoDerecho || biometrico.ID_TIPO_BIOMETRICO == (short)TipoBiometrico.OjoIzquierdo)
                    {
                        _personaBiometricoRepositorio.Eliminar(biometrico);
                        _imputadoBiometricoRepositorio.Guardar();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ObtenerFalla(ex);
            }
        }

        private bool GuardarImputadoBiometrico(PersonaOtd persona)
        {
            try
            {
                foreach (var biometrico in persona.Biometricos)
                {
                    if (biometrico.Tipo == TipoBiometrico.OjoDerecho || biometrico.Tipo == TipoBiometrico.OjoIzquierdo)
                    {
                        var biometricoEntidad = BiometricoMapeos.MapearImputadoEntidad(biometrico);
                        biometricoEntidad.ID_IMPUTADO = persona.Id;
                        biometricoEntidad.ID_CENTRO = persona.IdCentro;
                        biometricoEntidad.ID_ANIO = persona.IdAnio;
                        _imputadoBiometricoRepositorio.Insertar(biometricoEntidad);
                        _imputadoBiometricoRepositorio.Guardar();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ObtenerFalla(ex);
            }
        }

        private bool GuardarPersonaBiometrico(PersonaOtd persona)
        {
            try
            {
                foreach (var biometrico in persona.Biometricos)
                {
                    if (biometrico.Tipo == TipoBiometrico.OjoDerecho || biometrico.Tipo == TipoBiometrico.OjoIzquierdo)
                    {
                        var biometricoEntidad = BiometricoMapeos.MapearPersonaEntidad(biometrico);
                        biometricoEntidad.ID_PERSONA = persona.Id;
                        _personaBiometricoRepositorio.Insertar(biometricoEntidad);
                        _personaBiometricoRepositorio.Guardar();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ObtenerFalla(ex);
            }
        }

        public IList<PersonaOtd> TraerCustodiosParaPaseLista()
        {
            try
            {
                var empleados = _empleadoRepositorio.EncontrarPor(e => e.ID_TIPO_EMPLEADO == (short)TipoEmpleado.Comandancia04);

                if (empleados != null && empleados.Count() > 0)
                {
                    return PersonaMapeos.MapearPersonas(empleados.ToList());
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ObtenerFalla(ex);
            }
        }

        private IList<PersonaOtd> BuscarImputado(PersonaFiltroOtd filtro)
        {
            var resultados = filtro.IdCentro > 0 ? _imputadoRepositorio.EncontrarPor(i => i.ID_CENTRO == filtro.IdCentro) : _imputadoRepositorio.ObtenerTodos();

            if (!string.IsNullOrWhiteSpace(filtro.Folio))
            {
                var folio = filtro.Folio.Split('/');

                if (folio.Count() > 0 && !string.IsNullOrWhiteSpace(folio[0]))
                {
                    var anio = short.Parse(folio[0]);
                    resultados = resultados.Where(i => i.ID_ANIO == anio);
                }

                if (folio.Count() > 1 && !string.IsNullOrWhiteSpace(folio[1]))
                {
                    var idImputado = int.Parse(folio[1]);
                    resultados = resultados.Where(i => i.ID_IMPUTADO == idImputado);
                }
            }

            if (!string.IsNullOrWhiteSpace(filtro.Nombre))
            {
                resultados = resultados.Where(i => i.NOMBRE.Contains(filtro.Nombre.ToUpper()));
            }

            if (!string.IsNullOrWhiteSpace(filtro.ApellidoPaterno))
            {
                resultados = resultados.Where(i => i.PATERNO.Contains(filtro.ApellidoPaterno.ToUpper()));
            }

            if (!string.IsNullOrWhiteSpace(filtro.ApellidoMaterno))
            {
                resultados = resultados.Where(i => i.MATERNO.Contains(filtro.ApellidoMaterno.ToUpper()));
            }

            if (filtro.FiltrarSoloEnrolados)
            {
                resultados = resultados.Where(i => i.IMPUTADO_BIOMETRICO.Any(b => b.ID_TIPO_BIOMETRICO == (short)TipoBiometrico.OjoDerecho || b.ID_TIPO_BIOMETRICO == (short)TipoBiometrico.OjoIzquierdo));
            }

            if (resultados != null && resultados.Count() > 0)
            {
                return PersonaMapeos.MapearImputados(resultados.ToList());
            }

            return null;
        }

        private IList<PersonaOtd> BuscarPersonal(PersonaFiltroOtd filtro)
        {
            var resultados = filtro.IdCentro > 0 ? _empleadoRepositorio.EncontrarPor(p => p.ID_CENTRO == filtro.IdCentro) : _empleadoRepositorio.ObtenerTodos();

            if (!string.IsNullOrWhiteSpace(filtro.Folio))
            {
                var folio = filtro.Folio.Split('/');

                if (folio.Count() > 1 && !string.IsNullOrWhiteSpace(folio[1]))
                {
                    filtro.PersonaId = int.Parse(folio[1]);
                }
            }

            if (filtro.PersonaId > 0)
            {
                resultados = resultados.Where(p => p.ID_EMPLEADO == filtro.PersonaId);
            }

            if (!string.IsNullOrWhiteSpace(filtro.Nombre))
            {
                resultados = resultados.Where(p => p.PERSONA.NOMBRE.Contains(filtro.Nombre.ToUpper()));
            }

            if (!string.IsNullOrWhiteSpace(filtro.ApellidoPaterno))
            {
                resultados = resultados.Where(p => p.PERSONA.PATERNO.Contains(filtro.ApellidoPaterno.ToUpper()));
            }

            if (!string.IsNullOrWhiteSpace(filtro.ApellidoMaterno))
            {
                resultados = resultados.Where(p => p.PERSONA.MATERNO.Contains(filtro.ApellidoMaterno.ToUpper()));
            }

            if (resultados != null && resultados.Count() > 0)
            {
                var personas = PersonaMapeos.MapearPersonas(resultados.ToList());

                foreach (var persona in personas)
                {
                    var biometricos = _personaBiometricoRepositorio.EncontrarPor(p => p.ID_PERSONA == persona.Id);

                    if (biometricos != null && biometricos.Count() > 0)
                    {
                        BiometricoMapeos.MapearEmpleadoBiometrias(biometricos.ToList(), persona);
                    }
                }

                if (filtro.FiltrarSoloEnrolados)
                {
                    return RegresarPersonalConIris(personas);
                }

                return personas;
            }

            return null;
        }

        private IList<PersonaOtd> BuscarPersonas(PersonaFiltroOtd filtro)
        {
            var resultados = _personaRepositorio.ObtenerTodos();

            if (!string.IsNullOrWhiteSpace(filtro.Folio))
            {
                var folio = filtro.Folio.Split('/');

                if (folio.Count() > 1 && !string.IsNullOrWhiteSpace(folio[1]))
                {
                    filtro.PersonaId = int.Parse(folio[1]);
                }
            }

            if (filtro.PersonaId > 0)
            {
                resultados = resultados.Where(p => p.ID_PERSONA == filtro.PersonaId);
            }

            if (!string.IsNullOrWhiteSpace(filtro.Nombre))
            {
                resultados = resultados.Where(p => p.NOMBRE.Contains(filtro.Nombre.ToUpper()));
            }

            if (!string.IsNullOrWhiteSpace(filtro.ApellidoPaterno))
            {
                resultados = resultados.Where(p => p.PATERNO.Contains(filtro.ApellidoPaterno.ToUpper()));
            }

            if (!string.IsNullOrWhiteSpace(filtro.ApellidoMaterno))
            {
                resultados = resultados.Where(p => p.MATERNO.Contains(filtro.ApellidoMaterno.ToUpper()));
            }

            if (resultados != null && resultados.Count() > 0)
            {
                var personas = PersonaMapeos.MapearPersonas(resultados.ToList());

                foreach (var persona in personas)
                {
                    var biometricos = _personaBiometricoRepositorio.EncontrarPor(p => p.ID_PERSONA == persona.Id);

                    if (biometricos != null && biometricos.Count() > 0)
                    {
                        BiometricoMapeos.MapearEmpleadoBiometrias(biometricos.ToList(), persona);
                    }
                }

                if (filtro.FiltrarSoloEnrolados)
                {
                    return RegresarPersonalConIris(personas);
                }

                return personas;
            }

            return null;
        }

        private IList<PersonaOtd> RegresarPersonalConIris(IList<PersonaOtd> personas)
        {
            var personasConIris = new List<PersonaOtd>();

            foreach (var persona in personas)
            {
                if (persona.Biometricos != null && persona.Biometricos.Count > 0 && persona.Biometricos.Any(b => b.Tipo == TipoBiometrico.OjoDerecho || b.Tipo == TipoBiometrico.OjoIzquierdo))
                {
                    personasConIris.Add(persona);
                }
            }

            return personasConIris;
        }
    }
}