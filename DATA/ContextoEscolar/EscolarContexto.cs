using DATA.Modelos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.ContextoEscolar
{
     public partial class EscolarContexto : DbContext
    {
        
        public EscolarContexto()
            : base("name=EscolarContexto")
        {
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ProxyCreationEnabled = true;
        }

       
        public virtual DbSet<Usuarios> usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Usuarios>()
                .Property(e => e.nome)
                .IsUnicode(false);
            modelBuilder.Entity<Usuarios>()
              .Property(e => e.cidade)
              .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.senha)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.cpf)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.telefone)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.sexo)
                .IsFixedLength()
                .IsUnicode(false);
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


