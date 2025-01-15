using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace UserMicroservice.Models.ModelDatabase
{
    public class PlaceModel : BaseModel
    {
        public Guid WagonId { get; set; }
        public string PlaceName { get; set; }
    }
}
