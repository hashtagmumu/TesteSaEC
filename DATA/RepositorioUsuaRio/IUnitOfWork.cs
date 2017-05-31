using DATA.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Repositorio
{
    public interface IUnitOfWork : IDisposable
    {
       
        IRepository<Usuarios> _usuariorepositorio { get; }
        void SalvarAlteracoes();
    }
}
