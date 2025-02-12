using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingApplication.Data.Entities.Mapping
{
    internal class AnswerToQuestionMap : IEntityTypeConfiguration<AnswerToQuestion>
    {
        public void Configure(EntityTypeBuilder<AnswerToQuestion> builder)
        {
            // Primary Key
            builder.HasKey(t => t.Id);
            builder.HasOne(t => t.Answer).WithMany(t => t.AnswerToQuestions).HasForeignKey(t => t.AnswerID);
            builder.HasOne(t => t.Question).WithMany(t => t.AnswersFromQuestion).HasForeignKey(t => t.QuestionID);
        }
    }
}
