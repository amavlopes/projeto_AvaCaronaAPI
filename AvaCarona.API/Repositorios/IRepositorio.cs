using AvaCarona.API.Dominio;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace AvaCarona.API.Repositorios
{

    //Apenas implementará IRepositorio quem for AEntidadeBase [where T : AEntidadeBase] = [Carona, Colaborador, Endereco]
    public interface IRepositorio<T> where T : AEntidadeBase
    {

        T Adicionar( T _entidade );
        int Remover( T _entidade );
        IEnumerable<T> Listar();
        IEnumerable<T> Listar( Expression<Func<T, bool>> predicate );
        T GetPorID( int id );
        T Get( Expression<Func<T, bool>> predicate );

    }

}
