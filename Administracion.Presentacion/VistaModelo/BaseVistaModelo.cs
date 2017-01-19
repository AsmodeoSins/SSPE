using Administracion.Contratos;
using Administracion.Enum;
using Administracion.OTD;
using Administracion.Presentacion.Utilidades;
using Administracion.Utilidades.Constantes;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;

namespace Administracion.Presentacion.VistaModelo
{
    public class BaseVistaModelo : ViewModelBase, IBaseVistaModelo
    {
        private string tabPadreActual;

        public BaseVistaModelo()
        {

        }

        public RelayCommand<TabItem> CargarTabPadreCommand
        {
            get
            {
                return new RelayCommand<TabItem>(CargarTabPadre);
            }
        }

        private void CargarTabPadre(TabItem tab)
        {
            switch (tab.Header.ToString().ToUpper())
            {
                case SSPConst.TabCatalogos:
                    EnviarMensaje(TipoDeMensajeEnum.CargarCatalogos);
                    break;
                case SSPConst.TabProgramacion:
                    EnviarMensaje(TipoDeMensajeEnum.CargarProgramacionPaseLista);
                    break;
                case SSPConst.TabReportes:
                    EnviarMensaje(TipoDeMensajeEnum.CargarReportes);
                    break;
            }
        }

        private void EnviarMensaje(TipoDeMensajeEnum tipoMensaje)
        {
            Mensajero.EnviarMensaje<TipoDeMensajeEnum>(tipoMensaje);
        }
    }
}