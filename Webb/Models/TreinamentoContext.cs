using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Web.Models
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
                    .HasName("PK__aluno__30962D1488DC819E");

                entity.ToTable("aluno");

                entity.Property(e => e.Matricula).HasColumnName("matricula");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Nome)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.HasKey(e => e.IdEndereco)
                    .HasName("PK__endereco__324B959E8D24ED9F");

                entity.ToTable("endereco");

                entity.Property(e => e.IdEndereco).HasColumnName("id_endereco");

                entity.Property(e => e.Logradouro)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("logradouro");

                entity.Property(e => e.Matricula).HasColumnName("matricula");

                entity.Property(e => e.Uf)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("uf");

                entity.HasOne(d => d.MatriculaNavigation)
                    .WithMany(p => p.Enderecos)
                    .HasForeignKey(d => d.Matricula)
                    .HasConstraintName("FK__endereco__matric__35BCFE0A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
