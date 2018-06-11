using System;
using System.Collections.Generic;
using System.Text;

namespace AvaCarona.API.Dominio
{
    //Herda de AEntidadeBase [ID, DataDeCriacao] e IBloqueavel
    public abstract class AEntidadeBaseBloqueavel : AEntidadeBase, IBloqueavel
    {

        private bool Bloqueado { get; set; }

        //Gera uma DataDeCriacao ao criar um Obj deste tipo
        public AEntidadeBaseBloqueavel() : base()
        { }

        public void Bloquear()
        {
            Bloqueado = true;
        }

        public void Desbloquear()
        {
            Bloqueado = false;
        }

        public bool IsBloqueado()
        {
            return Bloqueado;
        }
    }
}
