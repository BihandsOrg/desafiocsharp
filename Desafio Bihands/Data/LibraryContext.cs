using Microsoft.EntityFrameworkCore;

namespace Desafio_Bihands.Data
{
    /// <summary>
    /// Contexto do banco de dados para a aplicação de biblioteca.
    /// </summary>
    public class LibraryContext : DbContext
    {
        /// <summary>
        /// Conjunto de dados representando os livros na biblioteca.
        /// </summary>
        public DbSet<Book> Books { get; set; }

        /// <summary>
        /// Inicializa uma nova instância do <see cref="LibraryContext"/>.
        /// </summary>
        /// <param name="options">Opções para configurar o contexto.</param>
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

        /// <summary>
        /// Configura o modelo ao criar o contexto.
        /// </summary>
        /// <param name="modelBuilder">O construtor de modelos usado para configurar as entidades.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasIndex(b => b.Name).IsUnique();
        }
    }

    /// <summary>
    /// Representa um livro na biblioteca.
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Identificador único do livro.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome do livro.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Autor do livro.
        /// </summary>
        public string Author { get; set; } = string.Empty;

        /// <summary>
        /// ISBN do livro.
        /// </summary>
        public string ISBN { get; set; } = string.Empty;

        /// <summary>
        /// Ano de publicação do livro.
        /// </summary>
        public int Year { get; set; }
    }
}
