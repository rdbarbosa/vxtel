using System.ComponentModel.DataAnnotations;
using VxTel.Entities.Notifications;

namespace VxTel.Entities.Entities
{
    public class Base : Notify
    {
        public int Id { get; set; }
     
        public string Nome { get; set; }
    }
}
