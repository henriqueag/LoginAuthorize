using System.ComponentModel.DataAnnotations;

namespace LoginAuthorize.ViewModel
{
    public class CadastroUsuarioViewModel
    {
        [Required(ErrorMessage = "Informe o nome")]
        [MaxLength(80, ErrorMessage = "O nome poderá ter até 80 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o nome de usuário")]
        [MaxLength(30, ErrorMessage = "O nome de usuário poderá ter até 30 caracteres")]
        [Display(Name ="Usuário")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "A senha deve ter pelo menos 6 caracteres")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Confirme a senha")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "A senha deve ter pelo menos 6 caracteres")]
        [Display(Name = "Confirmar senha")]
        [Compare(nameof(Senha), ErrorMessage = "A senha e a confirmação estão diferentes")]
        public string ConfirmacaoSenha { get; set; }
    }
}