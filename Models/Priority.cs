using System.ComponentModel.DataAnnotations;
namespace dotnet_ticket.Models
{
    public class Priority
    {
       [Key] 
        public int IdPriority { get; set; }
        
        public string Name { get; set; }
    }
}