using AvaCarona.API.Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace AvaCarona.API.Repositorios
{

    public abstract class ARepositorioEF<T> : IRepositorio<T> where T : AEntidadeBase
    {

        private DbContext _context;

        public ARepositorioEF( DbContext context )
        {
            _context = context;
        }

        public T Adicionar(T _entidade)
        {
            // Retorna posicao da entrada e Salva na memória
            var entrada = _context.Add(_entidade);

            // Persistindo no DB
            _context.SaveChanges();

            // Retorna entrada adicionada
            return entrada.Entity;
        }

     public T Get(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().AsNoTracking().Where( predicate ).FirstOrDefault();
        }

        public T GetPorID(int _ID)
        {
            return  _context.Set<T>().AsNoTracking().Where( c => c.ID == _ID ).FirstOrDefault();
        }

        public IEnumerable<T> Listar()
        {
            return _context.Set<T>().AsNoTracking().ToList();
        }

        public IEnumerable<T> Listar(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().AsNoTracking().Where( predicate ).ToList();
        }

        public int Remover(T _entidade)
        {
            // Retorna posicao da entrada e Salva na memória
            var entrada = _context.Remove(_entidade);

            // Persistindo no DB
            _context.SaveChanges();

            // Retorna entrada adicionada
            return entrada.Entity.ID;
        }

    }

}
