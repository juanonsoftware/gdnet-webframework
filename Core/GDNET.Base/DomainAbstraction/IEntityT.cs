namespace GDNET.Base.DomainAbstraction
{
    public interface IEntityT<TId> : IEntity
    {
        TId Id { get; }
    }
}
