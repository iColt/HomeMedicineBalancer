namespace HMB_Domain.Criteria
{
    public class IdCriteria<T>
    {
        public T Value { get; }

        public IdCriteria(T value)
        {
            Value = value;
        }
    }
}
