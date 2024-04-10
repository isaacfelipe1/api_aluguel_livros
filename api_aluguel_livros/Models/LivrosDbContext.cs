using Microsoft.EntityFrameworkCore;

namespace api_aluguel_livros.Models
{
    //Classe
    public class LivrosDbContext : DbContext
    {
        //Metodo Construtor
        public LivrosDbContext(DbContextOptions<LivrosDbContext> options) : base(options) { }
        //Representa a tabela Livros
        public DbSet<Livro> Livros { get; set; }
        //Representa a tabela Usuarios
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Aluguel> Aluguel { get; set; }
    }


}
