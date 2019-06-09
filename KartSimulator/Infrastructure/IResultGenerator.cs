using System.Collections.Generic;

namespace KartSimulator.Infrastructure
{
    /// <summary>
    /// The client to a service that receives the raw content from a file and transforms it into a list.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IResultGenerator<TEntity>
    {
        List<TEntity> GetAllLaps();

        TEntity FindLap(int id);
    }
}