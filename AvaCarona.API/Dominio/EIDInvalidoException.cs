using System;

namespace AvaCarona.API.Dominio
{
    public class EIDInvalidoException : Exception
    {
        private int _length;

        public EIDInvalidoException(int length)
        {
            _length = length;
        }

        public override string Message => 
            $" EID Inválido com { _length } caracteres! O EID deve ter no mínimo 3 caracteres, e no máximo 20.";

    }
}