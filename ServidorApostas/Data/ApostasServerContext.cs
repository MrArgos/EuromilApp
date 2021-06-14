using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
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

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("name=ApostasServerContext");
        //    }
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

        //    modelBuilder.Entity<Bet>(entity =>
        //    {
        //        entity.Property(e => e.Chave).IsUnicode(false);

        //        entity.Property(e => e.DataRegisto).IsUnicode(false);

        //        entity.HasOne(d => d.User)
        //            .WithMany()
        //            .HasForeignKey(d => d.UserId)
        //            .HasConstraintName("FK__Bets__UserId__37A5467C");
        //    });

        //    modelBuilder.Entity<User>(entity =>
        //    {
        //        entity.Property(e => e.UserId).ValueGeneratedNever();

        //        entity.Property(e => e.Nome).IsUnicode(false);
        //    });

        //    OnModelCreatingPartial(modelBuilder);
        //}

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
