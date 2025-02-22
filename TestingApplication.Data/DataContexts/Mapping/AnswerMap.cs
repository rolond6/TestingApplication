﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingApplication.Data.Entities;

namespace TestingApplication.Data.DataContexts.Mapping
{
    public class AnswerMap : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            // Primary Key
            builder.HasKey(t => t.Id);

            builder.HasOne(t => t.Question).WithMany(t => t.Answers).HasForeignKey(t => t.QuestionId);

            builder.Property(t => t.Name).HasMaxLength(255);
            builder.Property(t => t.Description).HasMaxLength(1024);
            builder.Property(t => t.IsCorrect).HasDefaultValue(false);
        }
    }
}
