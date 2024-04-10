using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_aluguel_livros.Models
{

    [Table("Aluguel")]
    public class Aluguel
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Livro")]
        [Required(ErrorMessage = "Informe o ID do Livro")]
        public int LivroId { get; set; }
        [ForeignKey("Usuario")]
        [Required(ErrorMessage = "Informe o ID do Usuário")]
        public int UsuarioId { get; set; }
        [Required(ErrorMessage = "Informe a Data de Inicio")]

        public DateTime DataInicio { get; set; }
        [Required(ErrorMessage = "Informe a Data de Termino")]
        public DateTime DataTermino { get; set; }

        // Propriedade de Navegação para os Relacionamentos de Livro e Usuario
        public Livro Livro { get; set; }
        public Usuario Usuario { get; set; }

    }
}
