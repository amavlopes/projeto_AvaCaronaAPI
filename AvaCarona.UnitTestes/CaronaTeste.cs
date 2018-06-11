using AvaCarona.API.Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AvaCarona.UnitTestes
{
    [TestClass]
    public class CaronaTeste
    {

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CriarCarona_NaoPermitirCriarSemOfertanteTeste()
        {
            Carona.CriarCarona( 1, null );
        }

        [TestMethod]
        [ExpectedException(typeof(LimiteDeVagasExcedidoException))]
        public void CriarCarona_NaoPermitirCriarMaisQueLimiteVagasPermitidoTeste()
        {
            Carona.CriarCarona( 7, Colaborador.CriarColaborador( "amanda.avelino.lopes" ) );
        }

        [TestMethod]
        public void OcuparVaga_VagasSuficientesTeste()
        {
            //Criando Carona: VagasDisponiveis = VagasTotais = 1
            var colaborador = Colaborador.CriarColaborador("amanda.avelino.lopes");
            var carona = Carona.CriarCarona( 1,  colaborador);
            
            //Ocupando uma vaga: VagasDisponiveis -= 1
            carona.OcuparVaga( colaborador );

            //Teste: esperado -> VagasDisponiveis -= 1 = 0 vagas
            //Teste: real: carona.VagasDisponiveis [0 vagas]
            Assert.AreEqual( 0, carona.VagasDisponiveis );
        }

        [TestMethod]
        [ExpectedException(typeof(VagasInsuficientesException))]
        public void OcuparVaga_VagasInsuficientesTeste()
        {
            //Criando Carona: VagasDisponiveis = VagasTotais = 0
            var colaborador = Colaborador.CriarColaborador("amanda.avelino.lopes");
            var carona = Carona.CriarCarona( 0, colaborador );

            //Ocupando uma vaga: !(VagasDisponiveis > 0) - Lança exceção: VagasInsuficientesException
            carona.OcuparVaga( colaborador );
        }

        [TestMethod]
        public void DesocuparVaga_Teste()
        {
            //Criando Carona e Colaborador
            var colaborador = Colaborador.CriarColaborador("amanda.avelino.lopes");
            var carona = Carona.CriarCarona( 1, colaborador );

            //Ocupando e Desocupando Vaga
            var ocupante = Colaborador.CriarColaborador("joao.victor");
            carona.OcuparVaga( ocupante );
            carona.DesocuparVaga( ocupante );

            //esperado : 1, atual: VagasDisponiveis
            Assert.AreEqual( 1, carona.VagasDisponiveis );
        }

    }
}
