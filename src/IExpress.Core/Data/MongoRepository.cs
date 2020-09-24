using IExpress.Core.DomainObjects;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IExpress.Core.Data
{

    public class MongoRepository<T> : IMongoRepository<T> where T : Entity
    {

        private readonly MongoDbContext<T> _context;
        private readonly IMongoCollection<T> _repo;

        public MongoRepository(MongoDbContext<T> context)
        {
            _context = context;

            _repo = _context.Collection;
        }

        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        public async Task Adicionar(T entity)
        {
            await Task.Run(() => _repo.InsertOne(entity));
        }

        public async Task Atualizar(T entity)
        {
           await Task.Run(()=> _repo.ReplaceOne(e => e.Id == entity.Id, entity));
        }

        public async Task<IEnumerable<T>> ObterPor(Expression<Func<T, bool>> predicate)
        {
            return await _repo.Find(filter: predicate).ToListAsync();
        }

        public async Task<T> ObterPorId(Guid id)
        {
            return await _repo.Find(c => c.Id == id).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<T>> ObterTodos()
        {
            return await _repo.Find(e => true).ToListAsync();
        }
    }
}

