using AvaCarona.API.Dominio;
using AvaCarona.API.Negocio;
using AvaCarona.API.Repositorios;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvaCarona.UnitTestes
{

    [TestClass]
    public class CaronaNegocioTeste
    {

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CadastrarCarona_CaronaNullTeste()
        {

            // Camada de negócio para verificar se pode ou não adicionar, injetando um IRepositorio
            var carona_negocio = new CaronaNegocio( new CaronaRepositorioIM() );

            // Carona null lança exceção
            carona_negocio.CadastrarCarona( null );
        }

        [TestMethod]
        [ExpectedException(typeof(CaronaJaExistenteException))]
        public void CadastrarCarona_CaronaExistenteTeste()
        {

            //Criando a carona
            Carona carona = Carona.CriarCarona( 1, Colaborador.CriarColaborador("amanda.avelino.lopes") );

            // Camada de negócio para verificar se pode ou não adicionar, injetando um IRepositorio<Carona>
            var carona_negocio = new CaronaNegocio( new CaronaRepositorioIM() );

            //Cadastrando Carona pela primeira vez
            carona_negocio.CadastrarCarona( carona );

            //Tentando cadastrar Carona de novo
            carona_negocio.CadastrarCarona(carona);

        }

        [TestMethod]
        public void CadastrarCarona_CaronaInexistenteTeste()
        {

            //Criando a carona
            Carona carona = Carona.CriarCarona(1, Colaborador.CriarColaborador("amanda.avelino.lopes"));

            //Repositorio para checar o Count
            var repositorio = new CaronaRepositorioIM();

            // Camada de negócio para verificar se pode ou não adicionar, injetando um IRepositorio<Carona>
            var carona_negocio = new CaronaNegocio( repositorio );

            //Cadastrando Carona
            carona_negocio.CadastrarCarona(carona);

            //Espera que tenha um registro em repositorio
            Assert.AreEqual( 1, repositorio.Count);

        }

    }

}
