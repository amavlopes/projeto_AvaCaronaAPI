using AvaCarona.API.Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AvaCarona.UnitTestes
{

    [TestClass]
    public class ColaboradorTeste
    {

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CriarColaborador_NaoPermitirCriarSemEIDTeste()
        {
            Colaborador.CriarColaborador(null);
        }

        [TestMethod]
        [ExpectedException(typeof(EIDInvalidoException))]
        public void CriarColaborador_NaoPermitirCriarComEIDMenorQueTresCaracteresTeste()
        {
            Colaborador.CriarColaborador("am");
        }

        [TestMethod]
        [ExpectedException(typeof(EIDInvalidoException))]
        public void CriarColaborador_NaoPermitirCriarComEIDMaiorQueVinteCaracteresTeste()
        {
            Colaborador.CriarColaborador("amanda.avelino.lopes.de.souza");
        }

        [TestMethod]
        public void CriarColaborador_ComEIDValidoTeste()
        {
            //Criando Colaborador
            var colaborador = Colaborador.CriarColaborador("amanda.avelino.lopes");

            //Teste: Se Length >= 3 E <= 20 - true
            var condicao = colaborador.EID.Length >= 3 && colaborador.EID.Length <= 20;

            //Assert.AreEqual( true, condicao);
            Assert.IsTrue(condicao);
        }

    }

}
