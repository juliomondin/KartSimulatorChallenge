using System;
using System.Collections.Generic;
using System.Text;

namespace KartSimulator.Infrastructure
{
    public interface IFileReader
    {
        List<string> GetLines(string path);
    }
}
