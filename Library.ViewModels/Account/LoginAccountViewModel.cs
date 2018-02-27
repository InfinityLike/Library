using System.ComponentModel.DataAnnotations;

namespace Library.ViewModels.Account
{
    public class LoginAccountViewModel
    {
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}