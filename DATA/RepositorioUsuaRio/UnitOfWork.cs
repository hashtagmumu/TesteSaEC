using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATA.Modelos;
using DATA.ContextoEscolar;

namespace DATA.Repositorio
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool _disposed;

     
        private EscolarContexto _db = null;
     
        private Repository<Usuarios> usuariorepositorio = null;

      
        public UnitOfWork()
        {
            _db = new EscolarContexto();
        }
       
       
        

        public IRepository<Usuarios> _usuariorepositorio
        {
            get
            {
                if (usuariorepositorio == null)
                {
                    usuariorepositorio = new Repository<Usuarios>(_db);
                }
                return usuariorepositorio;
            }
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void SalvarAlteracoes()
        {
            _db.SaveChanges();
        }
    }
}
