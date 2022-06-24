using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSProject
{
    public class SQLiteContext : DbContext
    {
        public DbSet<Note> notes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(@"Data Source = db.sqlite");
            base.OnConfiguring(options);
        }
    }
}
