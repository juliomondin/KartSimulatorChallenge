using System.Collections.Generic;

namespace KartSimulator.Infrastructure
{
    /// <summary>
    /// Implementation of pattern repository, to avoid coupling in the application.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity>
    {
        List<TEntity> GetAll();

        TEntity Find(int id);
    }
}