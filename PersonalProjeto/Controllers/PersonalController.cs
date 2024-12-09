using Microsoft.AspNetCore.Mvc;
using PersonalProjeto.Aplicacao;
using System;
using PersonalProjeto.Models;

namespace PersonalProjeto.Controllers
{
    public class PersonalController : Controller
    {
        private readonly PersonalAplicacao _personalAplicacao;

        public PersonalController(PersonalAplicacao personalAplicacao)
        {
            _personalAplicacao = personalAplicacao;
        }

        public IActionResult Index()
        {
            var lista = _personalAplicacao.ListarPersonal();
            return View(lista);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult CreatePersonal(Personal personal)
        {
            _personalAplicacao.CreatePersonal(personal);

            return RedirectToAction("Index");


        }

        public IActionResult Remove(int id)
        {
            _personalAplicacao.RemovePersonal(id);

            return RedirectToAction("Index");


        }
        public IActionResult Edit(int id)
        {
            var personal = _personalAplicacao.ObterPersonalPorId(id);

            if (personal == null)
            {
                return NotFound(); // Caso não encontre o personal
            }

            return View(personal); // Retorna a view de edição com os dados do personal
        }

        public IActionResult AtualizarPersonal(Personal personal)
        {
            if (ModelState.IsValid)
            {
                // Chama o método para atualizar os dados do "personal"
                _personalAplicacao.AtualizarPersonal(personal);
                return RedirectToAction("Index"); // Redireciona para a lista após a atualização
            }

            // Caso o modelo não seja válido, retorna à página de edição com os dados inseridos
            return View(personal);
        }

        public IActionResult Details (int id)
        {
            var personal = _personalAplicacao.ObterPersonalPorId(id);

            if (personal == null)
            {
                return NotFound(); // Se não encontrar, retorna um erro 404
            }

            return View(personal); // Retorna a view com os detalhes do "personal"
        
         }
    }
}