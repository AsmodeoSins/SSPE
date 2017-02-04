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
using Administracion.Presentacion.Utilidades;

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
            AutoMapperConfiguracion.Configurar();

            servicio = kernel.Get<PersonaServicio>();
        }
        #endregion

        [TestMethod]
        public void BusquedaGlobalEnPersonasTest()
        {
            PersonaFiltroOtd filtro = new PersonaFiltroOtd();
            filtro.Folio = "0/304081114";
            int expected = 1;
            IList<PersonaOtd> lstResultados = servicio.BusquedaGlobal(filtro);

            Assert.IsNotNull(lstResultados);
            Assert.AreEqual(expected, lstResultados.Count);
        }

        [TestMethod]
        public void BusquedaGlobalEnImputadosTest()
        {
            PersonaFiltroOtd filtro = new PersonaFiltroOtd();
            filtro.Folio = "2015/124";
            int expected = 1;
            IList<PersonaOtd> lstResultados = servicio.BusquedaGlobal(filtro);

            Assert.IsNotNull(lstResultados);
            Assert.AreEqual(expected, lstResultados.Count);
        }
    }
}