using System.ComponentModel.DataAnnotations;

namespace Cartools.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email obrigatório")]
        [Display(Name = "Email")] 
        public string UserName { get; set; }


        [Required(ErrorMessage ="Senha obrigatória")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
        public string SelectedRole { get; set; }

    }
}
