using System;

namespace AvaCarona.API.Negocio
{
    public class ColaboradorJaExistenteException : Exception
    {
        private string _EID;

        public ColaboradorJaExistenteException( string EID )
        {
            _EID = EID;
        }

        public override string Message => $" Já existe Colaborador cadastrado com EID: { _EID }! ";
    }
}