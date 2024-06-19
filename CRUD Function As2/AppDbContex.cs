using Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Function_As2
{
    public class AppDbContex:DbContext
    {
        internal object Persons;

        public string DbPath { get; set; }

        public AppDbContex()
        {
            var path = AppContext.BaseDirectory;
            DbPath = Path.Combine(path, "TestDatabase.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
        public DbSet<Person> person { get; set; }
    }
}
