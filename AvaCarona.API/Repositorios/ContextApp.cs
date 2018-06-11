using AvaCarona.API.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvaCarona.API.Repositorios
{
    public class ContextApp : DbContext
    {
        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<Carona> Carona { get; set; }

        public ContextApp()
        {
            // Toda vez que este Contexto é criado, garante que o db foi criado e faz conexão com a string abaixo
            Database.EnsureCreated(); 
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var conexao = @"Server=(localdb)\mssqllocaldb;Database=Turma01_Amanda;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer( conexao );
        }

        //Criando Tabela de Relacionamento 1 : n
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<CaronaColaborador>()
                .HasKey(s => new { s.ColaboradorID, s.CaronaID });

           // modelBuilder.Entity<CaronaColaborador>()
               // .HasOne(cc => cc.Colaborador)
               // .WithMany(co => co.ColaboradorCaronas)
               // .HasForeignKey(cc => ColaboradorID)
               // .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CaronaColaborador>()
                .HasOne( cc => cc.Carona )
                .WithMany( ca => ca.Ocupantes )
                .HasForeignKey( cc => cc.CaronaID )
                .OnDelete( DeleteBehavior.Restrict );

            base.OnModelCreating( modelBuilder );

        }

    }
}
