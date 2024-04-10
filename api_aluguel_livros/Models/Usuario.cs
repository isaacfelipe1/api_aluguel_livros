using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_aluguel_livros.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Informe o nome de Usuario")]
        [StringLength(50)]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Informe o E-mail de Usuario")]
        [StringLength(50)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Informe a Senha de Usuario")]
       
        public string Senha { get; set; }


    }
}
