using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Domain.Entities;

#nullable disable

namespace Domain.Models
{
    public partial class TreinamentoContext : DbContext
    {
        public TreinamentoContext()
        {
        }

        public TreinamentoContext(DbContextOptions<TreinamentoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aluno> Alunos { get; set; }
        public virtual DbSet<Endereco> Enderecos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=RYZEN3600;Initial Catalog=Treinamento;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Aluno>(entity =>
            {
                entity.HasKey(e => e.Matricula)
                    .HasName("PK__aluno__30962D1494698B93");

                entity.ToTable("aluno");

                entity.Property(e => e.Matricula).HasColumnName("matricula");

                entity.Property(e => e.Email)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("email")
                    .IsFixedLength(true);

                entity.Property(e => e.EnderecoFk).HasColumnName("endereco_fk");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("nome")
                    .IsFixedLength(true);

                entity.HasOne<Endereco>(d => d.EnderecoFkNavigation)
                    .WithMany(p => p.Alunos)
                    .HasForeignKey(d => d.EnderecoFk)
                    .HasConstraintName("FK__aluno__endereco___4BAC3F29");
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.ToTable("endereco");

                entity.Property(e => e.EnderecoId).HasColumnName("endereco_id");

                entity.Property(e => e.Address)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("endereco")
                    .IsFixedLength(true);

                entity.Property(e => e.Uf)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("uf")
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }



        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


    }
}
