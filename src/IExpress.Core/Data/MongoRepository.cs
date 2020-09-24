using IExpress.Core.DomainObjects;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
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
                _repo.InsertOne(entity);
            }

            public async Task Atualizar(T entity)
            {
                _repo.ReplaceOne(e => e.Id == entity.Id, entity);
            }

            public void Dispose()
            {
                GC.SuppressFinalize(this);
            }

            public async Task<IEnumerable<T>> ObterPor(Expression<Func<T, bool>> predicate)
            {
                return _repo.Find(filter: predicate).ToList();
            }

            public async Task<T> ObterPorId(Guid id)
            {
                return await _repo.Find(c => c.Id == id).FirstOrDefaultAsync();
            }

            public async Task<T> ObterPorId(int id)
            {
                throw new NotImplementedException();
            }

            public async Task<IEnumerable<T>> ObterTodos()
            {
                return _repo.Find(e => true).ToList();
            }
        }
    }

