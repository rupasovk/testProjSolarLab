using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace WinFormAfflineLesson
{
    class DbRepository : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public DbRepository() : base("Server=(localdb)\\mssqllocaldb;Database=SolarLabDATA;Trusted_Connection=True;") { }
    }
}
