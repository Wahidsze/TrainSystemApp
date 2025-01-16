using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TicketMicroservice.Models.ModelDatabase
{
    [PrimaryKey(nameof(Id))]
    public class BaseModel
    {
        public Guid Id { get; set; }
    }
}
