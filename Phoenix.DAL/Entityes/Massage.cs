using Phoenix.DAL.Entityes.Base;

namespace Phoenix.DAL.Entityes
{
    public class Massage : NamedEntity
    {
        public int? Duration { get; set; }
        public string? Description { get; set; }
        public Category? Category { get; set; }
        public override string ToString() => $"Массаж {Name}";
    }
}
