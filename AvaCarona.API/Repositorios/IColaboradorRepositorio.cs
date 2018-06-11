using AvaCarona.API.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvaCarona.API.Repositorios
{

    public interface IColaboradorRepositorio : IRepositorio<Colaborador>
    {

        Colaborador GetPorEID( string _EID );
        Colaborador GetPorPID( int _PID );

    }

}
