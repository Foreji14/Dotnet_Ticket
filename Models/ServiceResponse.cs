using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
namespace dotnet_ticket.Models
{
    public class ServiceResponse<T>
    {
        public T? Data { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;
    }
}