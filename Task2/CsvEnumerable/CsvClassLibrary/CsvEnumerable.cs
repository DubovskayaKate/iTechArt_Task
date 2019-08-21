using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;


namespace CsvClassLibrary
{
    public class CsvEnumerable<T> : IEnumerable<T>, IEnumerator<T>
    {
        private bool _isFirstItem;
        private CsvReader _csvReader = null;
        private StreamReader _stream = null;
        private readonly string Path = "info.csv";

        public CsvEnumerable()
        {
            _isFirstItem = true;
        }

        public T Current => _csvReader.GetRecord<T>();

        object IEnumerator.Current => _csvReader.GetRecord<T>();

        public void Dispose()
        {
            ((IEnumerator<T>)this).Reset();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            if (_isFirstItem)
            {
                this._stream = new StreamReader(Path);
                this._csvReader = new CsvReader(_stream);
                this._isFirstItem = false;
            }
            return _csvReader.Read();
        }

        public void Reset()
        {
            _csvReader.Dispose();
            _stream.Dispose();
            _isFirstItem = true;

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }
    }
}