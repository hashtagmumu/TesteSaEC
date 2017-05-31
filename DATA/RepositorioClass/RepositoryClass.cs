using DATA.RepositorioClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using DATA.Modelos;

namespace DATA.RepositorioClass
{
    public class RepositoryClass<T> : IRepositoryClass<T> where T : class
    {
        private EscolarClass m_Context = null;

        DbSet<T> m_DbSet;

        public RepositoryClass()
        {
            m_Context = new EscolarClass();
            m_DbSet = m_Context.Set<T>();
        }

        public RepositoryClass(EscolarClass context)
        {
            m_Context = context;
            m_DbSet = m_Context.Set<T>();
        }
        public void Adicionar(T entity)
        {
            m_DbSet.Add(entity);
        }

        public void Atualizar(T entity)
        {
            m_DbSet.Attach(entity);
            ((IObjectContextAdapter)m_Context).ObjectContext.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
        }

        public int Contar()
        {
            return m_DbSet.Count();
        }

        public void Deletar(T entity)
        {
            m_DbSet.Remove(entity);
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return m_DbSet.FirstOrDefault(predicate);
        }

        public IEnumerable<T> GetTudo(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return m_DbSet.Where(predicate);
            }

            return m_DbSet.AsEnumerable();
        }
    }
}
