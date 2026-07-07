using Chapter.WebApi.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using Chapter.WebApi.Models;

namespace Chapter.WebApi.Contexts
{
        public class ChapterContext : DbContext
        {
        public ChapterContext()
        { 
        }
        public ChapterContext(DbContextOptions<ChapterContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured)
        {
            // Essa string de conexão depende da SUA máquina.
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;"
                         + "Database=Chapter;" + "Trusted_Connection=True;" + "TrustServerCertificate=True;" + "Encrypt=True;");

            // Exemplo 1 de string de conexão:
            // User ID=sa;Password=admin;Server=localhost;Database=Chapter;-
            // + Trusted_Connection=False;

            // Exemplo 2 de string de conexão:
            // Server=localhost\\SQLEXPRESS;Database=ExoApi;Trusted_Connection=True;
        }
    }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}