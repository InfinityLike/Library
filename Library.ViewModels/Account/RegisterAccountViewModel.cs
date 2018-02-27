using System.ComponentModel.DataAnnotations;

namespace Library.ViewModels.Account
{
    public class RegisterAccountViewModel
    {
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        public string Name { get; set; }
    }
}