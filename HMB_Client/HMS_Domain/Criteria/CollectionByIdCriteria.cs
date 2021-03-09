using System.Collections.Generic;

namespace HMB_Domain.Criteria
{
    public class CollectionByIdCriteria<T, U> where T : IEnumerable<U>
    {
        public T Value { get; }

        public CollectionByIdCriteria(T value)
        {
            Value = value;
        }
    }
}
