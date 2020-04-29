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

                var dtHoje = DateTime.Today;

                if(dtHoje.Month == 1)
                {
                    Session["MesAtual"] = "Janeiro";
                }
                else if(dtHoje.Month == 2)
                {
                    Session["MesAtual"] = "Fevereiro";
                }
                else if (dtHoje.Month == 3)
                {
                    Session["MesAtual"] = "Março";
                }
                else if (dtHoje.Month == 4)
                {
                    Session["MesAtual"] = "Abril";
                }
                else if (dtHoje.Month == 5)
                {
                    Session["MesAtual"] = "Maio";
                }
                else if (dtHoje.Month == 6)
                {
                    Session["MesAtual"] = "Junho";
                }
                else if (dtHoje.Month == 7)
                {
                    Session["MesAtual"] = "Julho";
                }
                else if (dtHoje.Month == 8)
                {
                    Session["MesAtual"] = "Agosto";
                }
                else if (dtHoje.Month == 9)
                {
                    Session["MesAtual"] = "Setembro";
                }
                else if (dtHoje.Month == 10)
                {
                    Session["MesAtual"] = "Outubro";
                }
                else if (dtHoje.Month == 11)
                {
                    Session["MesAtual"] = "Novembro";
                }
                else if (dtHoje.Month == 12)
                {
                    Session["MesAtual"] = "Dezembro";
                }
                else
                {
                    Session["MesAtual"] = "ERRO";
                }

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

                var listMesAtual = busca.buscaMesAtual(dtHoje.Month,dtHoje.Year,int.Parse(us.Usuario.Coduser));

                double totalMesAtual = 0;

                for(int i = 0; i < listMesAtual.Count; i++)
                {
                    totalMesAtual = totalMesAtual + listMesAtual[i].Preco;
                }

                Session["dataAtt"] = dataAtt;
                Session["totalMesAtual"] = totalMesAtual;
                Session["TotalGasto"] = total;
                Session["anoAtual"] = dtHoje.Year;

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