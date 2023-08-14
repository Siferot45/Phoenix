using Phoenix.DAL.Entityes.Base;
using System.Collections.Generic;

namespace Phoenix.DAL.Entityes
{
    public class Category : NamedEntity
    {
        public ICollection<Massage> Massage { get; set; }
    }
}
