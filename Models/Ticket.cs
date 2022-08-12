using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_ticket.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Description { get; set; } 
        public User Owner { get; set; } 
        public int OwnerId { get; set; } 
        public User Worker { get; set; }
        public int WorkerId { get; set; }
        public Status Status { get; set; } 
        public int StatusId { get; set; } 
        public Priority Priority { get; set; } 
        public int PriorityId { get; set; } 
        public DateTime Date { get; set; }

    }
}