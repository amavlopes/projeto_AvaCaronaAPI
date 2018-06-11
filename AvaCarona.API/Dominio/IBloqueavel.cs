using System;
using System.Collections.Generic;
using System.Text;

namespace AvaCarona.API.Dominio
{
    public interface IBloqueavel
    {

        void Bloquear();
        void Desbloquear();
        bool IsBloqueado();

    }
}
