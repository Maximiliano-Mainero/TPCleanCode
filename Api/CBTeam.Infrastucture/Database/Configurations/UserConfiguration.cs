using CBTeam.Domain.Entities;
using CBTeam.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBTeam.Infrastructure.Database.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("usuarios");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .HasColumnName("id_usuario");

            builder.Property(r => r.IdRol)
                .HasColumnName("id_rol");

            builder.Property(r => r.FirstName)
                .HasColumnName("Nombre");
        }
    }
}
