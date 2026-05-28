using System.ComponentModel.DataAnnotations;

namespace ProjetoTela.Models
{
    public class Login
    {
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "Digite o e-mail")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Digite a senha")]
        [MinLength(6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres")]
        public string Senha { get; set; } = string.Empty;

        public string Nivel { get; set; } = "Operador";
    }
}