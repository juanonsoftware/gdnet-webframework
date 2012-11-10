namespace GDNET.Base.DomainAbstraction
{
    public abstract class AbstractEntityT<TId> : IEntityT<TId>
    {
        protected TId id = default(TId);

        public virtual TId Id
        {
            get { return id; }
        }

        public virtual string Signature
        {
            get { return string.Format("{0}|{1}", this.GetType().Name, this.id.ToString()); }
        }
    }
}
