using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingApplication.Data.Entities.Mapping
{
    internal class QuestionMap : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            // Primary Key
            builder.HasKey(t => t.Id);

            builder.HasOne(t => t.Type).WithMany(t => t.Questions).HasForeignKey(t => t.TypeId);
            builder.HasOne(t => t.Test).WithMany(t => t.Questions).HasForeignKey(t => t.TestId);
        }
    }
}
