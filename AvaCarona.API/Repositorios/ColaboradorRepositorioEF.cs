using AvaCarona.API.Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AvaCarona.API.Repositorios
{

    //Se comunica com o Context (DB) através de ARepositorioEF
    public class ColaboradorRepositorioEF : ARepositorioEF<Colaborador>, IColaboradorRepositorio
    {

        private DbContext _context;

        // Passando o Contexto para o ctor pai ARepositorioEF
        public ColaboradorRepositorioEF( ContextApp context ) : base( context )
        {
            _context = context;
        }

        public Colaborador GetPorEID(string _EID)
        {

            if (_EID == null)
                throw new ArgumentNullException("ColaboradorRepositorio[GetPorEID]", "EID informado nulo!");

            return _context.Set<Colaborador>().Where(c => c.EID == _EID).FirstOrDefault();

        }

        public Colaborador GetPorPID( int _PID )
        {
            if (  _PID.ToString().Trim().Length == 0 )
                throw new ArgumentNullException("ColaboradorRepositorio[GetPorPID]", "PID informado nulo!");

            return _context.Set<Colaborador>().Where(c => c.PID == _PID).FirstOrDefault();
        }
    }

}
