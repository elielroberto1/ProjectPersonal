using Microsoft.AspNetCore.Mvc;
using PersonalProjeto.Aplicacao;
using PersonalProjeto.Models;

namespace PersonalProjeto.Controllers
{
    public class AlunoController : Controller
    {
        
        private readonly AlunoAplicacao _alunoAplicacao;

        public AlunoController(AlunoAplicacao alunoAplicacao)
        {
            _alunoAplicacao = alunoAplicacao;
        }

        public IActionResult Index()
        {
            var lista = _alunoAplicacao.ListarAluno();

            List<Personal> personal = new List<Personal>();

            Personal personal1 = new Personal(1,"Eliel","1234","2anos");
            Personal personal2 = new Personal(1, "Ademi", "1224", "3anos");

            personal.Add(personal1);
            personal.Add(personal2);

            ViewBag.ListaPersonal = personal;


            return View(lista);
        }


    }
}
