using ProjData.Models.DadosTabela;
using ProjData.Models.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjData.Controllers
{
    public class RegistroUsuarioController : Controller
    {
        // GET: RegistroUsuario
        public ActionResult Index()
        {


            return View();
        }

        CadastraUsuario cadastraUser  = new CadastraUsuario();
        [HttpPost]
        public ActionResult Index(Usuario usuario)
        {

            if (cadastraUser.insertCadastro(usuario) == false)
            {


                //TempData["error"] = "true";
                // TempData["StatusCadastro"] = "ERRO";
                ModelState.Clear();
                return View();
            }
            else
            {
                // TempData["StatusCadastro"] = "OK";
                ModelState.Clear();
                return RedirectToAction("Index", "Home");
            }
        }
    }
}