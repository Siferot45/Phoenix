using Phoenix.DAL.Entityes.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Phoenix.DAL.Entityes
{
    public  class Visit : EntityBase
    {
        [Column(TypeName ="decimal(18,2)")]
        public decimal Price { get; set; }
        public Massage Massage { get; set; }
        public Client Client { get; set; }
        public Master Master { get; set; }
        public override string ToString() => $"Посещение {Massage}: {Master}, {Client}, {Price:C}";
    }
}
