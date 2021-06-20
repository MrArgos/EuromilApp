using Microsoft.EntityFrameworkCore;
using ServidorApostas.Models;

#nullable disable

namespace ServidorApostas.Data
{
    public partial class ApostasServerContext : DbContext
    {
        public ApostasServerContext()
        {
        }

        public ApostasServerContext(DbContextOptions<ApostasServerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bet> Bets { get; set; }
        public virtual DbSet<User> Users { get; set; }

    }
}
