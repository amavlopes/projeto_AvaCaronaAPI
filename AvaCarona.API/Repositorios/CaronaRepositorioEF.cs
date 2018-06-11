using AvaCarona.API.Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvaCarona.API.Repositorios
{

    //Se comunica com o Context (DB) através de ARepositorioEF
    public class CaronaRepositorioEF : ARepositorioEF<Carona>
    {

        // Passando o Contexto de CaronaContext para o ctor pai ARepositorioEF
        public CaronaRepositorioEF( ContextApp context ) : base( context )
        { }

    }

}
