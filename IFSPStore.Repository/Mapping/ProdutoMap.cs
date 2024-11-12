using IFSPStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFSPStore.Repository.Mapping
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(128);
            builder.Property(x => x.Preco);
            builder.Property(x => x.Quantidade);
            builder.Property(x => x.DataCompra);
            builder.Property(x => x.UnidadeVenda).HasMaxLength(10);
            builder.HasOne(x => x.Grupo).WithMany().HasConstraintName("nome_chave_estrangeira");

        }
    }
}
