using System;
using System.Collections.Generic;
using Domain.Classes;


namespace KartSimulator.Infrastructure
{
    public class Repository<T> : IRepository<T>
    {
        private readonly IResultGenerator<T> _publicGenerator;

        public Repository(IResultGenerator<T> publicGenerator)
        {
            _publicGenerator = publicGenerator ?? throw new ArgumentNullException(nameof(publicGenerator));
        }

        public List<T> GetAll()
        {
            return _publicGenerator.GetAllLaps();
        }

        public T Find(int id)
        {
            return _publicGenerator.FindLap(id);
        }
    }
}

