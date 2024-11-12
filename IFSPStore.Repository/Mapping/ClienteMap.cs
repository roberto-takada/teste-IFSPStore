using IFSPStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFSPStore.Repository.Mapping
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nome);
            builder.Property(c => c.Documento);
            builder.Property(c => c.Bairro);
            builder.HasOne(c => c.Cidade);
        }
    }
}
