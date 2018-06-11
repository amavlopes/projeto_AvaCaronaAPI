using AvaCarona.API.Dominio;
using AvaCarona.API.Negocio;
using AvaCarona.API.Repositorios;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AvaCarona.IntegracaoEFTeste
{
    [TestClass]
    public class CaronaServicoTeste
    {

        [TestMethod]
        public void CriaDBTeste()
        {
            using( var db = new API.Repositorios.ContextApp() )
            {
                Console.WriteLine(" DB Criado! ");
            }
        }

        [TestMethod]
        public void CadastrarColaboradorTeste()
        {
            using (var db = new ContextApp())
            {
                var repositorio = new ColaboradorRepositorioEF( db );
                var negocio = new ColaboradorNegocio( repositorio );

                var colaborador = Colaborador.CriarColaborador("amanda.avelino.lopes", 131095, "Amanda Avelino Lopes");

                negocio.CadastrarColaborador( colaborador );
            }
        }

    }
}
