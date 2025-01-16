using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.ModelDatabase
{
    [PrimaryKey(nameof(Id))]
    public class BaseModel
    {
        public Guid Id { get; set; }
    }
}
