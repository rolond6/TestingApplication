using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingApplication.Data.Entities;

namespace TestingApplication.Data.DataContexts.Mapping
{
    public class QuestionMap : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            // Primary Key
            builder.HasKey(t => t.Id);

            builder.HasOne(t => t.Type).WithMany(t => t.Questions).HasForeignKey(t => t.TypeId);
            builder.HasOne(t => t.Test).WithMany(t => t.Questions).HasForeignKey(t => t.TestId);

            builder.HasAlternateKey(t => t.Name);

            builder.Property(t => t.Id).HasColumnType("BLOB");

            builder.Property(t => t.Name).HasMaxLength(255);
            builder.Property(t => t.Description).HasMaxLength(2048);
        }
    }
}
