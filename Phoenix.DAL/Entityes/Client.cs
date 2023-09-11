using Phoenix.DAL.Entityes.Base;

namespace Phoenix.DAL.Entityes
{
    public class Client : Person
    {
        public string? Description { get; set; }
        public long? Phone { get; set; }
        public override string ToString() => $"Клиент {Surname} {Name} {Patronymic}";
    }
}
