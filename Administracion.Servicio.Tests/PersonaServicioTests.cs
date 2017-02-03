using Microsoft.VisualStudio.TestTools.UnitTesting;
using Administracion.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Administracion.Contratos;
using Administracion.OTD;
using Ninject;
using Administracion.Presentacion.Ninject;

namespace Administracion.Servicio.Tests
{
    [TestClass()]
    public class PersonaServicioTests
    {
        IKernel kernel;
        IPersonaServicio servicio;

        #region Metodos
        private void InitializeKernel()
        {
            if (kernel == null)
            {
                var bootstrapper = new NinjectBootstrapper();
                bootstrapper.CargarModulos();

                kernel = bootstrapper.Nucleo;
            }
        }
        #endregion

        #region Constructores
        public PersonaServicioTests()
        {
            InitializeKernel();

            servicio = kernel.Get<PersonaServicio>();
        }
        #endregion

        [TestMethod]
        public void BuscarPersonaPorFiltroVisitasTest()
        {
            PersonaFiltroOtd filtro = new PersonaFiltroOtd();
            filtro.EsImputado = false;
            filtro.Nombre = "COSME";
            IList<PersonaOtd> lstResultados = servicio.BuscarPersonaPorFiltro(filtro, true);
        }
    }
}