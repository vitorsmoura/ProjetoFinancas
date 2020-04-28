using ProjData.Models.DadosTabela;
using ProjData.Models.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjData.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ResetSenha()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session["StatusLogin"] = "ERRO";
            Session["ClienteLogado"] = null;
            return RedirectToAction("Index", "Home");
        }

        clTesteLogin tLogin = new clTesteLogin();


        [HttpPost]
        public ActionResult Index(Models.DadosTabela.Login login)
        {
            UserLogado cl = tLogin.testeLogin(login);
            //string acesso = tLogin.testeAcesso(login);

            if (cl.Login1.Loguin == login.Loguin && cl.Login1.Senha == login.Senha)
                {
                    Session["StatusLogin"] = "LOGADO";
                    Session["ClienteLogado"] = cl;

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["ErroLogin"] = "true";
                    return View();
                }
            }
        }

    }