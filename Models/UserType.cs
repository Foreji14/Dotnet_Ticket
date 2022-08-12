using System.ComponentModel.DataAnnotations;

namespace dotnet_ticket.Models
{
    public class UserType
    {
        [Key]
        public int IdUserType { get; set; }

        public string Name { get; set; }

    }
}