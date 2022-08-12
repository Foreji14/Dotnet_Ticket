using System.ComponentModel.DataAnnotations;

namespace dotnet_ticket.Models
{
    public class Status
    {
         [Key] 
        public int IdStatus { get; set; }
        
        public string Name { get; set; }

    }
}