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
    public class AnswerQuestionMap : IEntityTypeConfiguration<AnswerQuestion>
    {
        public void Configure(EntityTypeBuilder<AnswerQuestion> builder)
        {
            // Primary Key
            builder.HasKey(t => t.Id);
            builder.HasOne(t => t.Answer).WithMany(t => t.AnswerQuestions).HasForeignKey(t => t.AnswerId);
            builder.HasOne(t => t.Question).WithMany(t => t.AnswerQuestions).HasForeignKey(t => t.QuestionId);

            builder.HasIndex(t => new { t.AnswerId, t.QuestionId });
            builder.HasAlternateKey(t => new { t.AnswerId, t.QuestionId });

            builder.Property(t => t.IsTrue).HasDefaultValue(false);
        }
    }
}
