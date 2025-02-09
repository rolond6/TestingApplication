using Avalonia.Controls;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingApplication.Data.Entities;

namespace TestingApplication.Data.DataContexts
{
    internal class SQLiteDataContext: DbContext
    {
        public DbSet<Answer> Answers { get; set; } = null!;
        public DbSet<AnswerToQuestion> AnswerToQuestions { get; set; } = null!;
        public DbSet<Question> Questions { get; set; } = null!;
        public DbSet<QuestionsType> QuestionsTypes { get; set; } = null!;

        public SQLiteDataContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=TestingData.db");
            optionsBuilder.LogTo(SendMessage);
        }

        private void SendMessage(string message)
        {
            Trace.WriteLine(message);
        }
    }
}
