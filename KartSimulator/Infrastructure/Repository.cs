using System;
using System.Collections.Generic;

namespace KartSimulator.Infrastructure
{
    /// <summary>
    /// Implementation of pattern to avoid coupling in the application.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Repository<T> : IRepository<T>
    {
        private readonly IResultGenerator<T> _publicGenerator;

        /// <summary>
        /// Constructor to resolve IOC implementation.
        /// </summary>
        /// <param name="publicGenerator"></param>
        public Repository(IResultGenerator<T> publicGenerator)
        {
            _publicGenerator = publicGenerator ?? throw new ArgumentNullException(nameof(publicGenerator));
        }

        /// <summary>
        /// Returns all the laps.
        /// </summary>
        /// <returns></returns>
        public List<T> GetAll()
        {
            return _publicGenerator.GetAllLaps();
        }

        /// <summary>
        /// Returns a lap using a racer's id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T Find(int id)
        {
            return _publicGenerator.FindLap(id);
        }
    }
}