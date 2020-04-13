using Aplicacao.Servidor.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Aplicacao.Servidor.Infra.Repository.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().ToTable("Cliente");

            modelBuilder.Entity<Cliente>()
                .HasKey(x => x.Id);
                

            modelBuilder.Entity<Cliente>()
                .Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnType("varchar(150)");
            
            modelBuilder.Entity<Cliente>()
                .Property(x => x.CpfCnpj)
                .IsRequired()
                .HasMaxLength(14)
                .HasColumnType("varchar(14)");

            modelBuilder.Entity<Cliente>()
                .Property(x => x.Sexo)
                .HasColumnType("bit");

            modelBuilder.Entity<Cliente>()
                .Property(x => x.EstadoCivil)
                .HasColumnType("bit");

            modelBuilder.Entity<Cliente>()
                .Property(x => x.Rg)
                .HasMaxLength(20)
                .HasColumnType("varchar(20)");

            modelBuilder.Entity<Cliente>()
                .Property(x => x.DataNascimento)
                .IsRequired()
                .HasColumnType("datetime");

            modelBuilder.Entity<Cliente>()
                .Property(x => x.Idade)
                .IsRequired();

            modelBuilder.Entity<Cliente>()
                .Property(x => x.Salario)
                .HasColumnType("numeric(15,2)")
                .IsRequired();

            modelBuilder.Entity<Cliente>()
                .Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnType("varchar(150)");

            modelBuilder.Entity<Cliente>()
                .Property(x => x.Ddd)
                .IsRequired()
                .HasMaxLength(2)
                .HasColumnType("varchar(2)");

            modelBuilder.Entity<Cliente>()
                .Property(x => x.Fone)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnType("varchar(10)");

            modelBuilder.Entity<Cliente>()
                .Property(x => x.Logradouro)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnType("varchar(150)");

            modelBuilder.Entity<Cliente>()
                .Property(x => x.Numero)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnType("varchar(10)");

            modelBuilder.Entity<Cliente>()
                .Property(x => x.Complemento)
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            modelBuilder.Entity<Cliente>()
                .Property(x => x.Bairro)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnType("varchar(150)");

            modelBuilder.Entity<Cliente>()
                .Property(x => x.Cidade)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnType("varchar(150)");

            modelBuilder.Entity<Cliente>()
                .Property(x => x.Estado)
                .IsRequired()
                .HasMaxLength(2)
                .HasColumnType("varchar(2)");


            modelBuilder.Entity<Cliente>()
                .Property(x => x.Cep)
                .IsRequired()
                .HasMaxLength(8)
                .HasColumnType("varchar(8)");

            modelBuilder.Entity<Cliente>()
                .Property(x => x.Termo)
                .IsRequired();

            modelBuilder.Entity<Cliente>()
                .Property(x => x.Senha)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnType("varchar(30)");

            modelBuilder.Entity<Cliente>()
                .Property(x => x.Observacao)
                .HasMaxLength(150)
                .HasColumnType("varchar(150)");

            modelBuilder.Entity<Cliente>()
               .Ignore(x => x.ValidationResult);

            modelBuilder.Entity<Cliente>()
                .Ignore(x => x.IsValid);

            modelBuilder.Entity<Cliente>()
                .HasIndex(b => b.CpfCnpj);
        }
    }
}


