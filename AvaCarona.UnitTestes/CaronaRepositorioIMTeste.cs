using AvaCarona.API.Dominio;
using AvaCarona.API.Repositorios;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvaCarona.UnitTestes
{

    [TestClass]
    public class CaronaRepositorioIMTeste
    {

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetCaronasPorOfertante_OfertanteNuloTeste()
        {
            var repositorio = new CaronaRepositorioIM();
            repositorio.GetCaronasPorOfertante( null );
        }

        [TestMethod]
        public void GetCaronasPorOfertante_OfertanteExistenteTeste()
        {
            //Criando repositorio
            var repositorio = new CaronaRepositorioIM();

            //Criando colaboradores
            Colaborador colaborador_amanda = Colaborador.CriarColaborador("amanda.avelino.lopes");
            Colaborador colaborador_joaovictor = Colaborador.CriarColaborador("joao.victor"); 

            //Criando Caronas
            Carona carona_1 = Carona.CriarCarona( 4, colaborador_amanda );
            Carona carona_2 = Carona.CriarCarona( 2, colaborador_joaovictor );
            Carona carona_3 = Carona.CriarCarona( 1, colaborador_amanda );

            //Adicionando Caronas na Lista
            repositorio.Adicionar( carona_1 );
            repositorio.Adicionar( carona_2 );
            repositorio.Adicionar( carona_3 );

            List<Carona> resultado = repositorio.GetCaronasPorOfertante(colaborador_amanda);

            //Teste: esperado -> 2 registros, atual: resultado.Count
            Assert.AreEqual( 2, resultado.Count );

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetCaronasPorOfertante_ListaVaziaOfertanteInexistenteTeste()
        {
            //Criando repositorio
            var repositorio = new CaronaRepositorioIM();

            Colaborador colaborador = Colaborador.CriarColaborador( "amanda.avelino.lopes" );
            repositorio.GetCaronasPorOfertante( colaborador );
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetCaronasPorOfertante_ListaPreenchidaOfertanteInexistenteTeste()
        {
            //Criando repositorio
            var repositorio = new CaronaRepositorioIM();

            Colaborador colaborador_joaovictor = Colaborador.CriarColaborador("joao.victor");
            Carona carona_2 = Carona.CriarCarona(2, colaborador_joaovictor);
            repositorio.Adicionar(carona_2);

            Colaborador colaborador = Colaborador.CriarColaborador("amanda.avelino.lopes");
            repositorio.GetCaronasPorOfertante(colaborador);
        }

    }

}
