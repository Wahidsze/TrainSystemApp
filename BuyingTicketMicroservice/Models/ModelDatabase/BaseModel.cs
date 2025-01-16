using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BuyingTicketMicroservice.Models.ModelDatabase
{
    [PrimaryKey(nameof(Id))]
    public class BaseModel
    {
        public Guid Id { get; set; }
    }
}
