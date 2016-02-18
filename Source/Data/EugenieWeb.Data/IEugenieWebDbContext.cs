namespace Eugenie.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using EugenieWeb.Data.Models;

    public interface IEugenieWebDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        void Dispose();

        int SaveChanges();

        IDbSet<Store> Stores { get; set; }
    }
}