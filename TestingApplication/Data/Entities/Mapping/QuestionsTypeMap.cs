﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingApplication.Data.Entities.Mapping
{
    internal class QuestionsTypeMap : IEntityTypeConfiguration<QuestionsType>
    {
        public void Configure(EntityTypeBuilder<QuestionsType> builder)
        {
            // Primary Key
            builder.HasKey(t => t.Id);
        }
    }
}
