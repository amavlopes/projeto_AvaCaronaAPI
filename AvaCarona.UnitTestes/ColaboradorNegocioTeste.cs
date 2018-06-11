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
    public class ColaboradorNegocioTeste
    {

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CadastrarColaborador_ColaboradorNullTeste()
        {

            // Camada de negócio para verificar se pode ou não adicionar, injetando um IRepositorio
            var colaborador_negocio = new ColaboradorNegocio(new ColaboradorRepositorioIM());

            // Colaborador null lança exceção
            colaborador_negocio.CadastrarColaborador(null);

        }

        [TestMethod]
        [ExpectedException(typeof(ColaboradorJaExistenteException))]
        public void CadastrarColaborador_EIDExistenteTeste()
        {
            // Colaborador
            Colaborador colaborador = Colaborador.CriarColaborador("amanda.avelino.lopes");

            // Repositorio
            var repositorio = new ColaboradorRepositorioIM();
            repositorio.Adicionar( colaborador );

            // Camada de negócio para verificar se pode ou não adicionar, injetando um IRepositorio<Carona>
            var colaborador_negocio = new ColaboradorNegocio( repositorio );

            colaborador_negocio.CadastrarColaborador( Colaborador.CriarColaborador("amanda.avelino.lopes") );

        }

        [TestMethod]
        public void CadastrarColaborador_EIDInexistenteTeste()
        {
            // Repositorio
            var repositorio = new ColaboradorRepositorioIM();

            // Camada de negócio para verificar se pode ou não adicionar, injetando um IRepositorio<Carona>
            var colaborador_negocio = new ColaboradorNegocio( repositorio );

            colaborador_negocio.CadastrarColaborador( Colaborador.CriarColaborador("amanda.avelino.lopes") );

            Assert.AreEqual( 1 , repositorio.Count );
        }

        [TestMethod]
        public void ListarColaboradoresTeste()
        {
            var repositorio = new ColaboradorRepositorioIM();
            repositorio.Adicionar( Colaborador.CriarColaborador("amanda.avelino.lopes") );

            var negocio = new ColaboradorNegocio( repositorio );
            var lista = negocio.Listar();

            Assert.AreEqual( 1, lista.Count );
        }

        [TestMethod]
        public void ListaVaziaColaboradoresTeste()
        {
            var repositorio = new ColaboradorRepositorioIM();
            var negocio = new ColaboradorNegocio( repositorio );
            var lista = negocio.Listar();

            Assert.AreEqual(0, lista.Count);
        }

        [TestMethod]
        public void RemoverColaborador_ExistenteTeste()
        {
            // Criando o Colaborador
            var repositorio = new ColaboradorRepositorioIM();
            Colaborador adicionado = repositorio.Adicionar( Colaborador.CriarColaborador("amanda.avelino.lopes") );

            // Acessando a camada de negócio
            var negocio = new ColaboradorNegocio(repositorio);

            //Colaborador a ser removido
            var colaborador_remover = Colaborador.CriarColaborador("amanda.avelino.lopes");
            colaborador_remover.ID = 1;

            int idRemovido = negocio.RemoverColaborador( colaborador_remover );

            Assert.AreEqual( adicionado.ID, idRemovido );
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RemoverColaborador_InexistenteTeste()
        {
            // Criando o Colaborador
            var repositorio = new ColaboradorRepositorioIM();
            Colaborador adicionado = repositorio.Adicionar(Colaborador.CriarColaborador("amanda.avelino.lopes"));

            // Acessando a camada de negócio
            var negocio = new ColaboradorNegocio(repositorio);

            //Colaborador a ser removido
            var colaborador_remover = Colaborador.CriarColaborador("amanda.avelino.lopes");
            colaborador_remover.ID = 2;

            negocio.RemoverColaborador(colaborador_remover);
        }

    }

}
