using System.Collections.Generic;

namespace KartSimulator.Infrastructure
{
    /// <summary>
    /// Interface to access the file reader service.
    /// </summary>
    public interface IFileReader
    {
        /// <summary>
        /// Returns file's line inside a list.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        List<string> GetLines(string path);
    }
}