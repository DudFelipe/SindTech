using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SindTech.Business.Models;

namespace SindTech.Data.Mappings
{
    public class ContatoMapping : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property("ValorContato")
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.ToTable("Contatos");
        }
    }
}
