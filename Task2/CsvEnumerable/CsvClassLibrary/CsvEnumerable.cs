using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CsvClassLibrary
{
    public class CsvEnumerable<T> : IEnumerable<T>, IEnumerator<T>
    {
        private int _position;
        private List<T> _collection;

        public CsvEnumerable(List<T> list)
        {
            _position = -1;
            _collection = list;
        }

        public T Current => _collection.ElementAt(_position);

        object IEnumerator.Current => _collection.ElementAt(_position);

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
            if (_position < _collection.Count - 1)
            {
                _position++;
                return true;
            }

            return false;
        }

        public void Reset()
        {
            _position = -1;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }
    }
}