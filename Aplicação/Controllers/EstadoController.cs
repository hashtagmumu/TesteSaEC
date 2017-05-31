
using DATA.RepositorioClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DATA.Modelos;
using System.Data.Entity;

namespace Aplicação.Controllers
{
    public class EstadoController : Controller
    {
       public ActionResult Index()
        {
            if (Session["nome"] == null)
            {
                return RedirectToAction("Autemticar", "usuario");
            }
            else
            {
                var _Repository = new RepositoryClass<Estados>();
                List<Estados> listadeestados = _Repository.GetTudo().ToList();
                return View(listadeestados);
            }
          
         }

        public ActionResult Create()
        {
            if (Session["nome"] == null)
            {
                return RedirectToAction("Autemticar", "usuario");
            }
            else
            {

                return View();
            }
        }
        [HttpPost]
        public ActionResult Create(Estados model)
        {
            try
            {

                EscolarClass db = new EscolarClass();
                db.Estado.Add(model);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
               
                ViewBag.Message = string.Format("Erro ao criar o Cidade !");
                
                return View();
            }
        }
        public ActionResult editar(int id)
        {
            if (Session["nome"] == null)
            {
                return RedirectToAction("Autemticar", "usuario");
            }
            else
            {
                var _Repository = new RepositoryClass<Estados>();
                Estados estado = _Repository.Get(item => item.codigo == id);
                return View(estado);
            }

        }

     
        [HttpPost]
        public ActionResult editar(Estados model)
        {
            try
            {
                EscolarClass db = new EscolarClass();
               

                if (ModelState.IsValid)
                {
                    db.Entry(model).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }


                return RedirectToAction("Index");
            }
            catch
            {
                var _Repositorylista = new RepositoryClass<Estados>();
                ViewBag.Message = string.Format("Erro ao criar o Cidade !");
                List<Estados> estados = _Repositorylista.GetTudo().ToList();
                ViewBag.estadolista = estados;
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            if (Session["nome"] == null)
            {
                return RedirectToAction("Autemticar", "usuario");
            }
            else
            {
                var _Repository = new RepositoryClass<Estados>();
                Estados estado = _Repository.Get(item => item.codigo == id);
                return View(estado);
            }

        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            EscolarClass db = new EscolarClass();
            Estados estado = db.Estado.Find(id);
            db.Estado.Remove(estado);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}