using AvaCarona.API.Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvaCarona.UnitTestes
{

    [TestClass]
    public class AEntidadeBaseBloqueavelTeste
    {

        [TestMethod]
        public void BloquearEntidadeTeste()
        {
            Colaborador colaborador = Colaborador.CriarColaborador( "amanda.avelino.lopes" );
            colaborador.Bloquear();

            Assert.IsTrue(colaborador.IsBloqueado());
        }

        [TestMethod]
        public void DesbloquearEntidadeTeste()
        {
            Carona carona = Carona.CriarCarona( 1, Colaborador.CriarColaborador("amanda.avelino.lopes") );
            carona.Bloquear();
            carona.Desbloquear();

            Assert.IsFalse(carona.IsBloqueado());
        }

    }

}
