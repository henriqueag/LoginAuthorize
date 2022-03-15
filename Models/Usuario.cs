using System.ComponentModel.DataAnnotations;

namespace LoginAuthorize.Models
{    
    public class Usuario
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(80)]
        public string Nome { get; set; }
        [Required]
        [MaxLength(30)]
        public string Username { get; set; }
        [Required]
        [MaxLength(100)]
        public string Senha { get; set; }
    }
}