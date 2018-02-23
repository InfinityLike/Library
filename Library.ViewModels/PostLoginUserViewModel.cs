using System.ComponentModel.DataAnnotations;

namespace Library.ViewModels
{
    public class PostLoginUserViewModel
    {
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}