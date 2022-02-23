using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SindTech.Business.Models;

namespace SindTech.Data.Mappings
{
    public class MoradorMapping : IEntityTypeConfiguration<Morador>
    {
        public void Configure(EntityTypeBuilder<Morador> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property("Nome")
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property("CPF")
                .IsRequired()
                .HasColumnType("varchar(11)");

            //1 : 1 => Morador : Contatos
            builder.HasOne(c => c.Contato)
                .WithOne(m => m.Morador);

            //1 : N => Morador : Reclamacoes
            builder.HasMany(r => r.Reclamacoes)
                .WithOne(m => m.Morador)
                .HasForeignKey(r => r.MoradorId);

            builder.ToTable("Moradores");
        }
    }
}
