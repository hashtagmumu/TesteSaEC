using Aplicação.Models;
using DATA.Modelos;
using DATA.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Aplicação.Controllers
{
    public class UsuarioController : Controller
    {
      

   
        public ActionResult Register()
        {
            if (Session["nome"] != null)
            {
                return RedirectToAction("index", "home");
            }
            
            return View();

        }




        [HttpPost]
        public ActionResult Register(Usuarios usuario)
        {

            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    var vLogin = uow._usuariorepositorio.Get(p => p.email.Equals(usuario.email));

                    if (vLogin == null)
                    {
                        if (ModelState.IsValid)
                        {
                            try
                            {

                                uow._usuariorepositorio.Inserir(usuario);
                                uow.SalvarAlteracoes();
                              
                                return RedirectToAction("Autemticar");
                            }

                            catch
                            {
                                ViewBag.Message = "Registro falhou !";
                            }
                        }
                    }
                    else
                    {
                        ViewBag.Message = "Esse Email  ja Foi Cadastrado No Sistema Contate O Administrador  !";
                    }

                    return View(usuario);
                }
            }
        }




        public ActionResult Logout()
        {
            if (Session["nome"] != null)
            {
                Session.Abandon();
                return RedirectToAction("Autemticar");
            }
            {
                return RedirectToAction("Autemticar");
            }
        }
        public ActionResult Autemticar(string returnURL)
        {
            if (Session["nome"] != null)
            {
                return RedirectToAction("index", "home");
            }
            /*Recebe a url que o usuário tentou acessar*/
            ViewBag.ReturnUrl = returnURL;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Autemticar(LoginViewModel login, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                
                    using (UnitOfWork uow = new UnitOfWork())
                    {
                        var usuario = uow._usuariorepositorio.Get(item => item.senha == login.Senha && item.email == login.Email);

                        if (usuario != null)
                        {
                            if (Equals(usuario.senha, login.Senha))
                            {
                                FormsAuthentication.SetAuthCookie(usuario.email, false);

                                /*código abaixo cria uma session para armazenar o nome do usuário*/
                                Session["Nome"] = usuario.nome;
                                /*código abaixo cria uma session para armazenar o sobrenome do usuário*/
                                Session["codigo"] = usuario.codigo;
                                /*retorna para a tela inicial do Home*/
                                return RedirectToAction("Index", "Home");
                            }



                        }
                        else
                        {
                            ViewBag.Message = "Login inválido!";
                        }
                    }
                    }
                
             
            
            return View(login);
        }
    }
}