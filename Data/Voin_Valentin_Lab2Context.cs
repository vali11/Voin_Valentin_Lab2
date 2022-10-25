using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Voin_Valentin_Lab2.Models;

namespace Voin_Valentin_Lab2.Data
{
    public class Voin_Valentin_Lab2Context : DbContext
    {
        public Voin_Valentin_Lab2Context (DbContextOptions<Voin_Valentin_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Voin_Valentin_Lab2.Models.Book> Book { get; set; } = default!;

        public DbSet<Voin_Valentin_Lab2.Models.Publisher> Publisher { get; set; }

        public DbSet<Voin_Valentin_Lab2.Models.Author> Author { get; set; }

        public DbSet<Voin_Valentin_Lab2.Models.Category> Category { get; set; }
    }
}
