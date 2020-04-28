using ProjData.Models.DadosTabela;
using ProjData.Models.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjData.Controllers
{
    public class HomeController : Controller
    {

        string dataAtt;

        
        public ActionResult Index()
        {
            if(Session["StatusLogin"] == "LOGADO"){ 
                Usuario user = new Usuario();
                clBuscaDesc busca = new clBuscaDesc();


                if (Session["StatusLogin"] == "CLI")
                {
                    UserLogado cl = Session["ClienteLogado"] as UserLogado;

                    Session["NomeUser"] = cl.Usuario.Nomeuser;
                    Session["SobrenomeUser"] = cl.Usuario.Sobrenomeuser;

                }

                if(Session["ClienteLogado"] == null)
                {
                    return RedirectToAction("Index", "Login");

                }

                UserLogado us = Session["ClienteLogado"] as UserLogado;
                var listDesc = busca.buscaDesc(int.Parse(us.Usuario.Coduser));

                double total = 0;
                for (int i = 0; i < listDesc.Count; i++)
                {
                    total = total + listDesc[i].Preco;
                    dataAtt = listDesc[i].Datac;
                }

                Session["dataAtt"] = dataAtt;
                Session["TotalGasto"] = total;


                return View(listDesc);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }



        clCadastraDesc clCadDesc = new clCadastraDesc();

        public ActionResult PageForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PageForm(Descricao descricao)
        {
            UserLogado cl = Session["ClienteLogado"] as UserLogado;
            descricao.Coduser = cl.Usuario.Coduser;

            if (clCadDesc.insertCadastro(descricao) == false)
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