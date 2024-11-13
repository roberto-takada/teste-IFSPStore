

namespace IFSPStore.Domain.Base
{
    public abstract class BaseEntity<TID> : IBaseEntity
    {

        protected BaseEntity(TID id)
        {
            Id = id;
        }

        protected BaseEntity()
        {

        }
        public TID? Id { get; set; }


    }
}
