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
    public class AnswerToQuestionMap : IEntityTypeConfiguration<AnswerQuestion>
    {
        public void Configure(EntityTypeBuilder<AnswerQuestion> builder)
        {
            // Primary Key
            builder.HasKey(t => t.Id);
            builder.HasOne(t => t.Answer).WithMany(t => t.AnswerToQuestions).HasForeignKey(t => t.AnswerID);
            builder.HasOne(t => t.Question).WithMany(t => t.AnswersFromQuestion).HasForeignKey(t => t.QuestionID);
        }
    }
}
