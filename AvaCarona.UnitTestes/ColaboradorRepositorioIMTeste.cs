using AvaCarona.API.Dominio;
using AvaCarona.API.Repositorios;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvaCarona.UnitTestes
{

    [TestClass]
    public class ColaboradorRepositorioIMTeste
    {

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetPorEID_EIDNuloTeste()
        {
            //Criando repositorio
            var repositorio = new ColaboradorRepositorioIM();
            repositorio.GetPorEID(null);
        }

        [TestMethod]
        public void GetPorEID_EIDExistenteTeste()
        {
            //Criando repositorio
            var repositorio = new ColaboradorRepositorioIM();

            //Criando Colaborador e adicionando no repositorio
            Colaborador colaborador = Colaborador.CriarColaborador( "amanda.avelino.lopes" );
            repositorio.Adicionar( colaborador );

            //Retornado
            Colaborador colaborador_retornado = repositorio.GetPorEID( colaborador.EID );

            //Compara se o EID do colaborador criado é de fato o EID retornado
            Assert.AreEqual( colaborador.EID, colaborador_retornado.EID );
        }

        [TestMethod]
        public void GetPorEID_ListaVaziaEIDInexistenteTeste()
        {
            // Criando repositorio
            var repositorio = new ColaboradorRepositorioIM();

            // Procurando por EID Inexistente
            Colaborador resultado = repositorio.GetPorEID("joao.victor");

            //Resultado NULO
            Assert.IsNull( resultado );
        }

        [TestMethod]
        public void GetPorEID_ListaPreenchidaEIDInexistenteTeste()
        {
            // Criando repositorio
            var repositorio = new ColaboradorRepositorioIM();

            //Criando Colaborador e adicionando no repositorio
            Colaborador colaborador = Colaborador.CriarColaborador("amanda.avelino.lopes");
            repositorio.Adicionar(colaborador);

            // Procurando por EID Inexistente
            Colaborador resultado = repositorio.GetPorEID("joao.victor");

            //Resultado NULO
            Assert.IsNull(resultado);
        }

        [TestMethod]
        public void GetPorPID_PIDExistenteTeste()
        {
            //Criando repositorio
            var repositorio = new ColaboradorRepositorioIM();

            //Criando Colaborador e adicionando no repositorio
            Colaborador colaborador = Colaborador.CriarColaborador("amanda.avelino.lopes", 123456);
            repositorio.Adicionar(colaborador);

            //Retornado
            Colaborador colaborador_retornado = repositorio.GetPorPID( colaborador.PID );

            //Compara se o EID do colaborador criado é de fato o EID retornado
            Assert.AreEqual(colaborador.PID, colaborador_retornado.PID);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetPorPID_ListaVaziaPIDInexistenteTeste()
        {
            //Criando repositorio
            var repositorio = new ColaboradorRepositorioIM();
            repositorio.GetPorPID(123456);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetPorPID_ListaPreenchidaPIDInexistenteTeste()
        {
            //Criando repositorio
            var repositorio = new ColaboradorRepositorioIM();

            //Criando Colaborador e adicionando no repositorio
            Colaborador colaborador = Colaborador.CriarColaborador("amanda.avelino.lopes", 123456);
            repositorio.Adicionar(colaborador);

            repositorio.GetPorPID(789052);
        }

    }

}
