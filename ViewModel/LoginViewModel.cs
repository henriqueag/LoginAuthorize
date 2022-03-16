using System.ComponentModel.DataAnnotations;

namespace LoginAuthorize.ViewModel
{
    public class LoginViewModel
    {
        public string UrlRemota { get; set; }

        [Required(ErrorMessage = "Informe o nome de usuário")]
        [MaxLength(30, ErrorMessage = "O nome de usuário poderá ter até 30 caracteres")]
        [Display(Name = "Usuário")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "A senha deve ter pelo menos 6 caracteres")]
        public string Senha { get; set; }
    }
}