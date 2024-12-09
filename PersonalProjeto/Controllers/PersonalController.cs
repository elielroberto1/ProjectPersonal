using Microsoft.AspNetCore.Mvc;
using PersonalProjeto.Aplicacao;
using System;
using PersonalProjeto.Models;

namespace PersonalProjeto.Controllers
{
    public class PersonalController : Controller
    {
        public readonly PersonalAplicacao _personalaplicacao = new PersonalAplicacao();

        public IActionResult Index()
        {
            List<Personal> result  = _personalaplicacao.ListarPersonal();
            return View(result);
        }
    }
}
