using Phoenix.Interfaces;

namespace Phoenix.DAL.Entityes.Base
{
    public abstract class EntityBase : IEntity
    {
        public int Id { get; set; }
    }
}
