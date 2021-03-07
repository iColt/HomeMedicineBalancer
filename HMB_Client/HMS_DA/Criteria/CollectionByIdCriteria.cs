﻿using System.Collections.Generic;

namespace HMS_DA.Criteria
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