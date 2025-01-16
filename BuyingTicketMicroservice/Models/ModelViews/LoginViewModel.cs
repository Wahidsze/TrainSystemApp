using System.ComponentModel.DataAnnotations;

namespace BuyingTicketMicroservice.Models.ModelViews
{
    public class LoginViewModel
    {
        public String Email { get; set; }

        public String Password { get; set; }
    }
}
