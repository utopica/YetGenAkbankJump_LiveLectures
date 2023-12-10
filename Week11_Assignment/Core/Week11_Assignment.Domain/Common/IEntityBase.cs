namespace Week11_Assignment.Persistence.Domain.Common
{
    public interface IEntityBase<TKey>
    {
        public TKey Id { get; set; }
    }
}
