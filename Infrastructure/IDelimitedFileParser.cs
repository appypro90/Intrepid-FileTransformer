using System.Collections.Generic;

namespace Infrastructure
{
    public interface IDelimitedFileParser<T> where T : class
    {
        IEnumerable<T> ReadFile(string fileName);
        void WriteFile(List<T> records, string fileName);
    }
}
