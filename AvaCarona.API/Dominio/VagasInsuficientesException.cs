using System;

namespace AvaCarona.API.Dominio
{
    public class VagasInsuficientesException : Exception
    {

        public override string Message => $" Não há vagas disponíveis! ";

    }
}