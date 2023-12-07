namespace Week11_Assignment.Domain.Common
{
    public interface IEntityBase<TKey>
    {
        public TKey Id { get; set; }
    }
}
