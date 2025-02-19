using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TestingApplication.Data.Entities;

namespace TestingApplication.Data.DataContexts.Mapping
{
    public class QuestionsTypeMap : IEntityTypeConfiguration<QuestionsType>
    {
        public void Configure(EntityTypeBuilder<QuestionsType> builder)
        {
            // Primary Key
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id).ValueGeneratedNever();
            builder.Property(t => t.Name).HasMaxLength(64);

            builder.HasData(
                 QuestionsType.CHOICE_ONE,
                 QuestionsType.CHOICE_MANY
                );
        }
    }
}
