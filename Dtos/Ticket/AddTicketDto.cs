using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_ticket.Dtos.Ticket
{
    public class AddTicketDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int IdWorker { get; set; }
        public int IdStatus { get; set; }
        public int IdPriority { get; set; }
        public DateTime Date { get; set; }


    }
}