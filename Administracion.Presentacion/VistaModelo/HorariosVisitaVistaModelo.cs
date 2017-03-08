using Administracion.Contratos;
using Administracion.OTD;
using Administracion.Servicio;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Linq;

namespace Administracion.Presentacion.VistaModelo
{
    public class HorariosVisitaVistaModelo : ViewModelBase, IHorariosVisitaVistaModelo
    {
        #region Miembros Privados

        private TipoVisitaOtd _visita;
        private IList<TipoVisitaOtd> _visitas;
        private IList<string> _horas;
        private HorariosServicio _HorariosServicio;
        private IList<HorarioVisitaOtd> _horarios;
        private string _domingoInicio;
        private string _domingoFin;
        private string _lunesInicio;
        private string _lunesFin;
        private string _martesInicio;
        private string _martesFin;
        private string _miercolesInicio;
        private string _miercolesFin;
        private string _juevesInicio;
        private string _juevesFin;
        private string _viernesInicio;
        private string _viernesFin;
        private string _sabadoInicio;
        private string _sabadoFin;

        #endregion Miembros Privados

        public HorariosVisitaVistaModelo()
        {
            InicializarObjetos();
        }

        #region Propiedades

        public TipoVisitaOtd Visita
        {
            get
            {
                return _visita;
            }
            set
            {
                _visita = value;
                CargarHorario();
                RaisePropertyChanged("Visita");
            }
        }

        public IList<HorarioVisitaOtd> Horarios
        {
            get
            {
                return _horarios;
            }
            set
            {
                _horarios = value;
                RaisePropertyChanged("Horarios");
            }
        }

        public IList<TipoVisitaOtd> Visitas
        {
            get
            {
                return _visitas;
            }
            set
            {
                _visitas = value;
                RaisePropertyChanged("Visitas");
            }
        }

        public IList<string> Horas
        {
            get
            {
                return _horas;
            }
            set
            {
                _horas = value;
                RaisePropertyChanged("Horas");
            }
        }

        public string DomingoInicio
        {
            get
            {
                return _domingoInicio;
            }
            set
            {
                _domingoInicio = value;
                RaisePropertyChanged("DomingoInicio");
            }
        }
        public string DomingoFin
        {
            get
            {
                return _domingoFin;
            }
            set
            {
                _domingoFin = value;
                RaisePropertyChanged("DomingoFin");
            }
        }

        public string LunesInicio
        {
            get
            {
                return _lunesInicio;
            }
            set
            {
                _lunesInicio = value;
                RaisePropertyChanged("LunesInicio");
            }
        }
        public string LunesFin
        {
            get
            {
                return _lunesFin;
            }
            set
            {
                _lunesFin = value;
                RaisePropertyChanged("LunesFin");
            }
        }

        public string MartesInicio
        {
            get
            {
                return _martesInicio;
            }
            set
            {
                _martesInicio = value;
                RaisePropertyChanged("MartesInicio");
            }
        }
        public string MartesFin
        {
            get
            {
                return _martesFin;
            }
            set
            {
                _martesFin = value;
                RaisePropertyChanged("MartesFin");
            }
        }

        public string MiercolesInicio
        {
            get
            {
                return _miercolesInicio;
            }
            set
            {
                _miercolesInicio = value;
                RaisePropertyChanged("MiercolesInicio");
            }
        }
        public string MiercolesFin
        {
            get
            {
                return _miercolesFin;
            }
            set
            {
                _miercolesFin = value;
                RaisePropertyChanged("MiercolesFin");
            }
        }

        public string JuevesInicio
        {
            get
            {
                return _juevesInicio;
            }
            set
            {
                _juevesInicio = value;
                RaisePropertyChanged("JuevesInicio");
            }
        }
        public string JuevesFin
        {
            get
            {
                return _juevesFin;
            }
            set
            {
                _juevesFin = value;
                RaisePropertyChanged("JuevesFin");
            }
        }

        public string ViernesInicio
        {
            get
            {
                return _viernesInicio;
            }
            set
            {
                _viernesInicio = value;
                RaisePropertyChanged("ViernesInicio");
            }
        }
        public string ViernesFin
        {
            get
            {
                return _viernesFin;
            }
            set
            {
                _viernesFin = value;
                RaisePropertyChanged("ViernesFin");
            }
        }

        public string SabadoInicio
        {
            get
            {
                return _sabadoInicio;
            }
            set
            {
                _sabadoInicio = value;
                RaisePropertyChanged("SabadoInicio");
            }
        }
        public string SabadoFin
        {
            get
            {
                return _sabadoFin;
            }
            set
            {
                _sabadoFin = value;
                RaisePropertyChanged("SabadoFin");
            }
        }

        #endregion Propiedades

        #region Commands
        public RelayCommand GrabarHorarioCommand
        {
            get
            {
                return new RelayCommand(GrabarHorario);
            }
        }
        #endregion Commands

        #region Metodos Privados

        private void InicializarObjetos()
        {
            _HorariosServicio = new HorariosServicio();
            InicializarHoras();
            Visitas = _HorariosServicio.ObtenerTipoVisitas();
            Visita = Visitas.FirstOrDefault();
            CargarHorario();
        }

        private void InicializarHoras()
        {
            List<string> result = new List<string>();
            for (int i = 0; i < 24; i++)
            {
                result.Add(i + ":00");
            }
            Horas = result;
        }

        private void CargarHorario()
        {
            ReiniciarHoras();
            if (Visita != null)
            {
                Horarios = _HorariosServicio.ObtenerHorarioPorVisita(s => true);
                var horarios = Horarios.Where(s => s.IdTipoVisita == Visita.IdTipoVisita);
                foreach (var horario in horarios)
                {
                    switch (horario.IdDia)
                    {
                        case 1:
                            DomingoInicio = horario.HoraInicio.Trim();
                            DomingoFin = horario.HoraFin.Trim();
                            break;
                        case 2:
                            LunesInicio = horario.HoraInicio.Trim();
                            LunesFin = horario.HoraFin.Trim();
                            break;
                        case 3:
                            MartesInicio = horario.HoraInicio.Trim();
                            MartesFin = horario.HoraFin.Trim();
                            break;
                        case 4:
                            MiercolesInicio = horario.HoraInicio.Trim();
                            MiercolesFin = horario.HoraFin.Trim();
                            break;
                        case 5:
                            JuevesInicio = horario.HoraInicio.Trim();
                            JuevesFin = horario.HoraFin.Trim();
                            break;
                        case 6:
                            ViernesInicio = horario.HoraInicio.Trim();
                            ViernesFin = horario.HoraFin.Trim();
                            break;
                        case 7:
                            SabadoInicio = horario.HoraInicio.Trim();
                            SabadoFin = horario.HoraFin.Trim();
                            break;
                    }
                }
            }
        }

        private void ReiniciarHoras()
        {
            DomingoInicio = "4:00";
            DomingoFin = "";
            LunesInicio = "";
            LunesFin = "";
            MartesInicio = "";
            MartesFin = "";
            MiercolesInicio = "";
            MiercolesFin = "";
            JuevesInicio = "";
            JuevesFin = "";
            ViernesInicio = "";
            ViernesFin = "";
            SabadoInicio = "";
            SabadoFin = "";
        }

        private void GrabarHorario()
        {
            List<HorarioVisitaOtd> horarios = new List<HorarioVisitaOtd>()
            {
                new HorarioVisitaOtd()
                {
                    IdTipoVisita = (short)Visita.IdTipoVisita,
                    IdDia = 1,
                    HoraInicio = DomingoInicio,
                    HoraFin = DomingoFin
                },
                new HorarioVisitaOtd()
                {
                    IdTipoVisita = (short)Visita.IdTipoVisita,
                    IdDia = 2,
                    HoraInicio = LunesInicio,
                    HoraFin = LunesFin
                },
                new HorarioVisitaOtd()
                {
                    IdTipoVisita = (short)Visita.IdTipoVisita,
                    IdDia = 3,
                    HoraInicio = MartesInicio,
                    HoraFin = MartesFin
                },
                new HorarioVisitaOtd()
                {
                    IdTipoVisita = (short)Visita.IdTipoVisita,
                    IdDia = 4,
                    HoraInicio = MiercolesInicio,
                    HoraFin = MiercolesFin
                },
                new HorarioVisitaOtd()
                {
                    IdTipoVisita = (short)Visita.IdTipoVisita,
                    IdDia = 5,
                    HoraInicio = JuevesInicio,
                    HoraFin = JuevesFin
                },
                new HorarioVisitaOtd()
                {
                    IdTipoVisita = (short)Visita.IdTipoVisita,
                    IdDia = 6,
                    HoraInicio = ViernesInicio,
                    HoraFin = ViernesFin
                },
                new HorarioVisitaOtd()
                {
                    IdTipoVisita = (short)Visita.IdTipoVisita,
                    IdDia = 7,
                    HoraInicio = SabadoInicio,
                    HoraFin = SabadoFin
                }
            };
            foreach(var horario in horarios)
            {
                var existente = Horarios.First(s => s.IdDia == horario.IdDia && s.IdTipoVisita == horario.IdTipoVisita);
                if(existente != null)
                {
                    horario.Id = existente.Id;
                    _HorariosServicio.AcutalizarHorario(horario);
                }
                else
                {
                    _HorariosServicio.InsertarHorario(horario);
                }
            }
        }

        #endregion Metodos Privados
    }
}