using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_aluguel_livros.Models
{
    [Table("Livros")]
    public class Livro
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o Titulo")]
        [StringLength(50)]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "Informe o Autor")]
        [StringLength(50)]
        public string Autor { get; set; }
        [Required(ErrorMessage = "Informe a Editora")]
        [StringLength(50)]
        public string Editora { get; set; }
        [Required(ErrorMessage = "Informe o Ano de Publicacao")]
       
        public int AnoPublicacao { get; set; }


    }
}
