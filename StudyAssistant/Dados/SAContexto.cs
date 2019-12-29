using Microsoft.EntityFrameworkCore;
using StudyAssistant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyAssistant.Dados
{
    public class SAContexto:DbContext
    {

        public SAContexto(DbContextOptions<SAContexto> options): base(options)
        {
        }

        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<TypeOfQuestion> TypeOfQuestions { get; set; }
    }
}
