using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlunoAPI.models;
using Microsoft.EntityFrameworkCore;

namespace AlunoAPI.context
{
    public class AppContextDB:DbContext
    {
        public DbSet<AlunoModel> Alunos {get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if(!optionsBuilder.IsConfigured){
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=postgres");
            }
        }
    }
}