using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Entities;

namespace DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Categoria> Categoria { get; set; }

        public DbSet<Egreso> Egreso { get; set; }

        public Contexto() : base("ConStr")
        {

        }
    }
}
