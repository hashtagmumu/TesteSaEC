using DATA.Modelos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Modelos
{

    public partial class EscolarClass : DbContext
    {
        public EscolarClass()
            : base("name=EscolarClass")
        {
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Alunos> alunos { get; set; }
        public virtual DbSet<AuxMaes> AuxMae { get; set; }
        public virtual DbSet<AuxPais> AuxPai { get; set; }
        public virtual DbSet<Cidades> cidades { get; set; }
        public virtual DbSet<Estados> Estado { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alunos>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<Alunos>()
                .Property(e => e.email)
                .IsUnicode(false);



            modelBuilder.Entity<Alunos>()
                .Property(e => e.matricula)
                .IsUnicode(false);

            modelBuilder.Entity<Alunos>()
                .Property(e => e.endcompleto)
                .IsUnicode(false);

            modelBuilder.Entity<Alunos>()
                .Property(e => e.rg)
                .IsUnicode(false);

            modelBuilder.Entity<Alunos>()
                .Property(e => e.cpf)
                .IsUnicode(false);

            modelBuilder.Entity<Alunos>()
                .Property(e => e.telefone)
                .IsUnicode(false);

            modelBuilder.Entity<Alunos>()
               .Property(e => e.sexo)
                .IsUnicode(false);





            modelBuilder.Entity<AuxMaes>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<AuxMaes>()
                .Property(e => e.profissao)
                .IsUnicode(false);

            modelBuilder.Entity<AuxMaes>()
                .Property(e => e.cpf)
                .IsUnicode(false);

            modelBuilder.Entity<AuxMaes>()
                .Property(e => e.rg)
                .IsUnicode(false);

            modelBuilder.Entity<AuxMaes>()
                .Property(e => e.telefone)
                .IsUnicode(false);

            modelBuilder.Entity<AuxMaes>()
                .HasMany(e => e.aluno)
                .WithOptional(e => e.AuxMae)
                .HasForeignKey(e => e.idmae);

            modelBuilder.Entity<AuxPais>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<AuxPais>()
                .Property(e => e.profissao)
                .IsUnicode(false);

            modelBuilder.Entity<AuxPais>()
                .Property(e => e.cpf)
                .IsUnicode(false);

            modelBuilder.Entity<AuxPais>()
                .Property(e => e.rg)
                .IsUnicode(false);

            modelBuilder.Entity<AuxPais>()
                .Property(e => e.telefone)
                .IsUnicode(false);

            modelBuilder.Entity<AuxPais>()
                .HasMany(e => e.aluno)
                .WithOptional(e => e.AuxPai)
                .HasForeignKey(e => e.idpai);

            modelBuilder.Entity<Cidades>()
                .Property(e => e.cidade)
                .IsUnicode(false);

            modelBuilder.Entity<Cidades>()
                .Property(e => e.Cep)
                .IsUnicode(false);

            modelBuilder.Entity<Cidades>()
                .HasMany(e => e.alunos)
                .WithOptional(e => e.cidades)
                .HasForeignKey(e => e.idcidade);

            modelBuilder.Entity<Estados>()
                .Property(e => e.UF)
                .IsUnicode(false);

            modelBuilder.Entity<Estados>()
                .Property(e => e.SIgla)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Estados>()
                .HasMany(e => e.cidade)
                .WithOptional(e => e.Estado)
                .HasForeignKey(e => e.codigouf);
        }
        public override int SaveChanges()
        {

            foreach (var entry in ChangeTracker.Entries().Where(el => el.Entity.GetType().GetProperty("dtcad") != null))
            {
                if (entry.State == EntityState.Added)
                    entry.Property("dtcad").CurrentValue = DateTime.Now;

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataAlteracao").CurrentValue = DateTime.Now;
                    entry.Property("DataAlteracao").IsModified = false;
                }
            }

            return base.SaveChanges();
        }
    }
}

