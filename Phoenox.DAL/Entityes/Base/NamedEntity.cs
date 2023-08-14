using Phoenix.DAL.Entityes.Base;

namespace Phoenix.DAL.Entityes.Base
{
    public abstract class NamedEntity : EntityBase
    {
        public string Name { get; set; }
    }
}
