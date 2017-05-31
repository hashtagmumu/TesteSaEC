
using DATA.Modelos;
using DATA.RepositorioClass;
using RazorPDF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aplicação.Controllers
{
    public class CidadeController : Controller
    {

        public ActionResult Index()
        {
            if (Session["nome"] == null)
            {
                return RedirectToAction("Autemticar", "usuario");
            }
            else
            {
                var _Repository = new RepositoryClass<Cidades>();
                List<Cidades> listadecidades = _Repository.GetTudo().ToList();
                return View(listadecidades);
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
                var _Repository = new RepositoryClass<Estados>();
                List<Estados> estados = _Repository.GetTudo().ToList();
                ViewBag.estadolista = estados;
                return View();
            }
        }
        [HttpPost]
        public ActionResult Create(Cidades model)
        {
            try
            {

                EscolarClass db = new EscolarClass();
                model.codigouf = Convert.ToInt32(Request.Form["codigouf"]);
                model.dtcad = DateTime.Now.Date;
                db.cidades.Add(model);
                db.SaveChanges();

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
        public ActionResult editar(int id)
        {
            if (Session["nome"] == null)
            {
                return RedirectToAction("Autemticar", "usuario");
            }
            else
            {
                var _Repository = new RepositoryClass<Cidades>();
                Cidades cidade = _Repository.Get(item => item.codigo == id);
                var _Repositorylista = new RepositoryClass<Estados>();
                List<Estados> estados = _Repositorylista.GetTudo().ToList();
                ViewBag.estadolista = estados;
                return View(cidade);
            }

        }

        //
        // POST: /Blogs/Edit/5
        [HttpPost]
        public ActionResult editar(Cidades model)
        {
            try
            {
                EscolarClass db = new EscolarClass();
                model.codigouf = Convert.ToInt32(Request.Form["codigouf"]);

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
                var _Repository = new RepositoryClass<Cidades>();
                Cidades cidade = _Repository.Get(item => item.codigo == id);
                return View(cidade);
            }
           
    }
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
            EscolarClass db = new EscolarClass();
            Cidades cidade = db.cidades.Find(id);
            db.cidades.Remove(cidade);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
}
}