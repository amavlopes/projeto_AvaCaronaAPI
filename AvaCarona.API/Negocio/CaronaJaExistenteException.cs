using System;

namespace AvaCarona.API.Negocio
{
    public class CaronaJaExistenteException : Exception
    {

        private int ID;

        public CaronaJaExistenteException(int _ID)
        {
            ID = _ID;
        }

        public override string Message => $" Já existe Carona cadastrada com ID: { ID }! ";

    }
}