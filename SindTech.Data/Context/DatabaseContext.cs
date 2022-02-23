using Microsoft.EntityFrameworkCore;
using SindTech.Business.Models;

namespace SindTech.Data.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Morador> Moradores { get; set; }
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Reclamacao> Reclamacoes { get; set; }

        //Esse método será chamado no momento da criação das tabelas
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Para cada propriedade string das entidades, deve ser apicado o tipo varchar(200) caso não seja informado o tamanho no data mapping
            foreach(var property in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
            {
                property.SetColumnType("varchar(200)");
            }

            //Aplicando as configurações desse assembly
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);

            //Para cada relacionamento, alterar o comportamento de deleção para ClientSetNull
            foreach(var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
