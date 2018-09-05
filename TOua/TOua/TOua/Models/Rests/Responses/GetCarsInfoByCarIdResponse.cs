using System.Collections;
using System.Collections.Generic;
using TOua.Models.DTOs;

namespace TOua.Models.Rests.Responses {
    public class GetCarsInfoByCarIdResponse : ICollection<CarinfoDTO>, IResponse {

        private ICollection<CarinfoDTO> _collection = new List<CarinfoDTO>();

        public int Count => _collection.Count;

        public bool IsReadOnly => _collection.IsReadOnly;

        public void Add(CarinfoDTO item) => _collection.Add(item);

        public void Clear() => _collection.Clear();

        public bool Contains(CarinfoDTO item) => _collection.Contains(item);

        public void CopyTo(CarinfoDTO[] array, int arrayIndex) => _collection.CopyTo(array, arrayIndex);

        public IEnumerator<CarinfoDTO> GetEnumerator() => _collection.GetEnumerator();

        public bool Remove(CarinfoDTO item) => _collection.Remove(item);

        IEnumerator IEnumerable.GetEnumerator() => _collection.GetEnumerator();
    }
}
