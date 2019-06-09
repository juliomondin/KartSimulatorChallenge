using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace KartSimulator.Infrastructure
{
    /// <summary>
    /// Service that returns the file content.
    /// </summary>
    public class FileReader : IFileReader
    {
        /// <summary>
        /// Get the raw file content.
        /// </summary>
        /// <param name="path">File location</param>
        /// <returns>List of lines from raw file content</returns>
        public List<string> GetLines(string path)
        {
            if (File.Exists(path))
            {
                var lines = System.IO.File.ReadAllLines(path).ToList();
                lines.RemoveAt(0);
                return lines;
            }
            else
                throw new FileLoadException();
        }
    }
}