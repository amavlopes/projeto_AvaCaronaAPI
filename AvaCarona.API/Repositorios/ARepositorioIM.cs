using AvaCarona.API.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace AvaCarona.API.Repositorios
{

    //Apenas implementará ARepositorioIM[ que implementa IRepositorio ],
    //quem for AEntidadeBase [where T : AEntidadeBase] = [Carona, Colaborador, Endereco]
    public abstract class ARepositorioIM<T> : IRepositorio<T> where T : AEntidadeBase
    {

        private List<T> _entidades = new List<T>();

        public int Count
        {
            get
            {
                return _entidades.Count;
            }
        }

        private int GerarID()
        {
            if (_entidades.Count == 0) return 1; //ID inicia com 1
            int _ID = (_entidades[_entidades.Count - 1].ID) += 1; //Pega o ID do último elemento, incrementa um e gera o ID
            return _ID;
        }

        public T Adicionar(T _entidade)
        {
            if (_entidade == null)
                throw new ArgumentNullException("ARepositorioIM[Adicionar]", "Entidade de parâmetro nula.");

            _entidade.ID = GerarID(); //Gerando ID para entidade adicionada
            _entidades.Add(_entidade);

            return _entidade;
        }

        public int Remover(T _entidade)
        {
            if (_entidade == null)
                throw new ArgumentNullException("ARepositorioIM[Remover]", "Entidade de parâmetro nula.");

            //Se não encontrar entidade lança exceção através do GetPorID
            _entidade = GetPorID(_entidade.ID);
            if (_entidade == null)
                throw new ArgumentNullException("ARepositorioIM[GetPorID]", "Entidade com ID não encontrada.");

            _entidades.Remove(_entidade);
            return _entidade.ID;
        }

        public T Get( Expression<Func<T, bool>> predicate )
        {
            return _entidades.AsQueryable().Where( predicate ).FirstOrDefault();
        }

        public T GetPorID(int ID)
        {
            int p = 0;
            bool encontrada = false;

            while ( !encontrada && ( p < _entidades.Count ) )
            {
                if ( _entidades[p].ID == ID )
                {
                    encontrada = true;
                    return _entidades[p]; //Retornando a Entidade com o ID informado
                }
                p++;
            }

            return null;
        }

        public IEnumerable<T> Listar()
        {
            return _entidades;
        }

        public IEnumerable<T> Listar(Expression<Func<T, bool>> predicate)
        {
            return _entidades.AsQueryable().Where( predicate );
        }
    }

}
