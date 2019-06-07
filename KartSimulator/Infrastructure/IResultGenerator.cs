using System;
using System.Collections.Generic;
using System.Text;
using Domain.Classes;

namespace KartSimulator.Infrastructure
{
    public interface IResultGenerator<TEntity>
    {
        List<TEntity> GetAllLaps();
        TEntity FindLap(int id);
    }
}
