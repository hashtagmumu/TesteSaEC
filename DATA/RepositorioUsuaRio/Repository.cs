using DATA.ContextoEscolar;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Repositorio
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly EscolarContexto _db;
        DbSet<T> db_DbSet;
        public Repository(EscolarContexto db)
        {
            _db = db;
            db_DbSet = _db.Set<T>();
        }

   


        public void Inserir(T entity)
        {
            _db.Set<T>().Add(entity);
        }
        
        public T Get(Expression<Func<T, bool>> predicate)
        {
            return db_DbSet.FirstOrDefault(predicate);
        }
      
    }
}
