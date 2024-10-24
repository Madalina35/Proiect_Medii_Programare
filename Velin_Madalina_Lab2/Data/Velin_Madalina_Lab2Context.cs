using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Velin_Madalina_Lab2.Models;

namespace Velin_Madalina_Lab2.Data
{
    public class Velin_Madalina_Lab2Context : DbContext
    {
        public Velin_Madalina_Lab2Context (DbContextOptions<Velin_Madalina_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Velin_Madalina_Lab2.Models.Book> Book { get; set; } = default!;
        public DbSet<Velin_Madalina_Lab2.Models.Publisher> Publisher { get; set; } = default!;
        public DbSet<Velin_Madalina_Lab2.Models.Author> Author { get; set; } = default!;
    }
}
