using AvaCarona.API.Dominio;
using AvaCarona.API.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace AvaCarona.API.Negocio
{

    public class ColaboradorNegocio
    {

        private IColaboradorRepositorio _repositorio;

        public ColaboradorNegocio(IColaboradorRepositorio repositorio )
        {
            _repositorio = repositorio;
        }

        public void CadastrarColaborador( Colaborador colaborador )
        {

            if (colaborador == null)
                throw new ArgumentNullException("ColaboradorNegocio[CadastrarColaborador]", "Colaborador nulo!");

            // EID
            string EID = colaborador.EID;

            // Se não Existir Colaborador com este EID
            if ( ExisteColaborador(EID) ) throw new ColaboradorJaExistenteException(EID);

            // Senão adiciona no repositório 
            _repositorio.Adicionar(colaborador);

        }

        private bool ExisteColaborador(string EID)
        {
            return _repositorio.GetPorEID(EID) != null;
        }

        public IList<Colaborador> Listar()
        {
            //Retorna um IEnumerable, converte para Lista .ToList()
            return _repositorio.Listar().ToList();
        }

        public IList<Colaborador> Listar( Expression<Func<Colaborador, bool>> predicate )
        {
            //Retorna um IEnumerable, converte para Lista .ToList()
            return _repositorio.Listar( predicate ).ToList();
        }
        
        public Colaborador GetPorEID( string _EID )
        {
            if( _EID == null )
                throw new ArgumentNullException("ColaboradorNegocio[GetPorEID]", "EID nulo!");

            return _repositorio.Get( c => c.EID == _EID );
        }

        public int RemoverColaborador(Colaborador colaborador)
        {
            if (colaborador == null)
                throw new ArgumentNullException("ColaboradorNegocio[RemoverColaborador]", "Colaborador nulo!");

            // Se não Existir Colaborador com este EID 
            if ( !ExisteColaborador( colaborador.EID ) )
                throw new ArgumentNullException("ColaboradorNegocio[RemoverColaborador]", "Colaborador inexistente!");

            return _repositorio.Remover(colaborador);
        }

    }

}
