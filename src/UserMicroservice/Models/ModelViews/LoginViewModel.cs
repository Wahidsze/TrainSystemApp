using System.ComponentModel.DataAnnotations;

namespace UserMicroservice.Models.ModelViews
{
    public class LoginViewModel
    {
        public String Email { get; set; }

        public String Password { get; set; }
    }
}
