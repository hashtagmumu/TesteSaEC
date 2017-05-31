
using DATA.RepositorioClass;
using DATA.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Aplicação.Controllers
{
    public class alunoController : Controller
    {
       

        // GET: aluno
        public ActionResult Index()
        {
            if (Session["nome"] == null)
            {
                return RedirectToAction("Autemticar", "usuario");
            }
            else
            {
                var _Repository = new RepositoryClass<Alunos>();
                List<DATA.Modelos.Alunos> listadealunos = _Repository.GetTudo().ToList();
                return View(listadealunos);
            }
           
        }
       

       
      
       
        
      
     
       
    }
}