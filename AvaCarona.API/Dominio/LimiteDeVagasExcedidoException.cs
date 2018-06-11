using System;

namespace AvaCarona.API.Dominio
{

    public class LimiteDeVagasExcedidoException : Exception
    {
        private int _vagas;
        private int _limite;

        public LimiteDeVagasExcedidoException(int vagas, int limite)
        {
            _vagas = vagas;
            _limite = limite;
        }

        public override string Message => 
            $" Limite de vagas excedido! Limite permitido: { _limite }, vagas solicitadas { _vagas }. ";

    }

}