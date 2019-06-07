using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Domain.Classes;

namespace KartSimulator.Infrastructure
{
    public interface IRepository<TEntity>
    {
        List<TEntity> GetAll();

        TEntity Find(int id);
    }

}
