using AvaCarona.API.Dominio;
using AvaCarona.API.Repositorios;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvaCarona.UnitTestes
{

    [TestClass]
    public class ARepositorioIMTeste
    {

        [TestMethod]
        public void AdicionarEntidade_EntidadeExistenteTeste()
        {
            //Criando o repositório Carona || Colaborador
            var repositorio = new CaronaRepositorioIM();

            //Criando Carona || Colaborador
            Carona carona = Carona.CriarCarona(1, Colaborador.CriarColaborador("amanda.avelino.lopes"));

            //Adicionando no repositorio
            Carona caronaRetornada = repositorio.Adicionar(carona);

            int IDEsperado = 1;
            Assert.AreEqual(IDEsperado, caronaRetornada.ID);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AdicionarEntidade_EntidadeNulaTeste()
        {
            //Criando o repositório
            var repositorio = new CaronaRepositorioIM();
            repositorio.Adicionar( null );
        }

        [TestMethod]
        public void RemoverEntidade_EntidadeExistenteTeste()
        {
            //Criando o repositório Carona || Colaborador
            var repositorio = new ColaboradorRepositorioIM();

            //Criando Carona || Colaborador
            Colaborador colaborador_1 = Colaborador.CriarColaborador("amanda.avelino.lopes");
            Colaborador colaborador_2 = Colaborador.CriarColaborador("marcos.aurelio");
            Colaborador colaborador_3 = Colaborador.CriarColaborador("paulo.siqueira");

            //Adicionando no repositorio
            repositorio.Adicionar(colaborador_1);
            repositorio.Adicionar(colaborador_2);
            repositorio.Adicionar(colaborador_3);

            //Removendo do repositorio e retornando o ID Removido
            int IDRemovido = repositorio.Remover(colaborador_2);

            //Compara o esperado: IDRemovido com o atual colaborador.ID
            Assert.AreEqual(colaborador_2.ID, IDRemovido);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RemoverEntidade_EntidadeNulaTeste()
        {
            //Criando o repositório 
            var repositorio = new CaronaRepositorioIM();
            repositorio.Remover( null );
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RemoverEntidade_EntidadeNaoEncontradaTeste()
        {
            // Criando o repositório 
            var repositorio = new ColaboradorRepositorioIM();
            // Tenta remover Entidade inexistente [em GetPorID]
            Colaborador colaborador_inexistente = Colaborador.CriarColaborador("amanda.avelino.lopes");
            repositorio.Remover( colaborador_inexistente );
        }

        [TestMethod]
        public void ListarEntidade_ListaVaziaTeste()
        {
            //Criando Repositorio
            var repositorio = new CaronaRepositorioIM();
            //Checa Count. esperado: 0, atual: repositorio.Count
            Assert.AreEqual(0, repositorio.Count);
        }

        [TestMethod]
        public void ListarEntidade_ListaPreenchidaTeste()
        {
            //Criando Repositorio
            var repositorio = new ColaboradorRepositorioIM();

            //Adicionando Colaboradores no repositorio
            repositorio.Adicionar(Colaborador.CriarColaborador("amanda.avelino.lopes"));
            repositorio.Adicionar(Colaborador.CriarColaborador("marcos.aurelio"));

            //Checa Count. esperado: 2, atual: repositorio.Count
            Assert.AreEqual(2, repositorio.Count);
        }

        [TestMethod]
        public void GetPorID_EntidadeExistenteTeste()
        {
            //Criando o repositório Carona 
            var repositorio = new CaronaRepositorioIM();

            //Criando Caronas 
            Carona carona_1 = Carona.CriarCarona(1, Colaborador.CriarColaborador("amanda.avelino.lopes"));
            Carona carona_2 = Carona.CriarCarona(1, Colaborador.CriarColaborador("marcos.aurelio"));
            Carona carona_3 = Carona.CriarCarona(1, Colaborador.CriarColaborador("joao.victor"));

            //Adicionando no repositorio
            repositorio.Adicionar(carona_1);
            repositorio.Adicionar(carona_2);
            repositorio.Adicionar(carona_3);

            //Pega carona por ID
            Carona caronaRetornada = repositorio.GetPorID(carona_2.ID);

            //Verifica se de fato o ID da carona gerado, é igual da caronaRetornada
            Assert.AreEqual(carona_2.ID, caronaRetornada.ID);
        }

        [TestMethod]
        public void GetPorID_EntidadeInexistenteTeste()
        {
            //Criando repositorio
            var repositorio = new ColaboradorRepositorioIM();

            //Criando entidade - ID 1
            Colaborador colaborador_inexistente = Colaborador.CriarColaborador("amanda.avelino.lopes");

            /* Teste se GetPorID lançar exceção. */
            Colaborador resultado = repositorio.GetPorID( colaborador_inexistente.ID );

            Assert.IsNull( resultado );
        }

    }

}
