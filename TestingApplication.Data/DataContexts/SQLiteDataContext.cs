using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingApplication.Data.Entities;
using TestingApplication.Data.DataContexts.Mapping;

namespace TestingApplication.Data.DataContexts
{
    public class SQLiteDataContext: DbContext
    {
        public DbSet<Answer> Answers { get; set; } = null!;
        public DbSet<Question> Questions { get; set; } = null!;
        public DbSet<Test> Tests { get; set; } = null!;
        public DbSet<QuestionsType> QuestionsTypes { get; set; } = null!;
        
        public SQLiteDataContext()
        {
            Database.EnsureCreated();
        }

        public static SQLiteDataContext Create()
        {
            return new SQLiteDataContext();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=TestingData.db");
            optionsBuilder.LogTo(SendMessage);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AnswerMap());
            modelBuilder.ApplyConfiguration(new QuestionMap());
            modelBuilder.ApplyConfiguration(new QuestionsTypeMap());
            modelBuilder.ApplyConfiguration(new TestMap());
        }

        private void SendMessage(string message)
        {
            Trace.WriteLine(message);
        }
    }
}
