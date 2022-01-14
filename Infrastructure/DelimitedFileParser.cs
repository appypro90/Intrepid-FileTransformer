using FileHelpers;
using System.Collections.Generic;

namespace Infrastructure
{
    public class DelimitedFileParser<T> : IDelimitedFileParser<T> where T : class
    {
        private readonly IFileHelperAsyncEngine<T> _engine;

        public DelimitedFileParser(IFileHelperAsyncEngine<T> engine)
        {
            _engine = engine;
        }

        public IEnumerable<T> ReadFile(string fileName)
        {
            var items = new List<T>();
            using (_engine.BeginReadFile(fileName))
            {
                items.AddRange(_engine);
            }
            return items;
        }

        public void WriteFile(List<T> records, string fileName)
        {
            using (_engine.BeginWriteFile(fileName))
            {
                foreach (var record in records)
                {
                    _engine.WriteNext(record);
                }
            }
        }
    }
}
