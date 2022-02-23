using Microsoft.EntityFrameworkCore;
using SindTech.Business.Interfaces.Repositories;
using SindTech.Business.Models;
using SindTech.Data.Context;
using System.Linq.Expressions;

namespace SindTech.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly DatabaseContext Db;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(DatabaseContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public async Task Adicionar(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public async Task Atualizar(TEntity entity)
        {
            Db.Entry(entity).State = EntityState.Modified;
            DbSet.Update(entity);
            await SaveChanges();
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task Excluir(Guid id)
        {
            var entity = await ObterPorId(id);
            Db.Entry(entity).State = EntityState.Modified;
            DbSet.Update(new TEntity { Id = id, Ativo = false });
            await SaveChanges();
        }

        public async Task<TEntity> ObterPorId(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<IList<TEntity>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            //Db?.Dispose();
        }
    }
}
