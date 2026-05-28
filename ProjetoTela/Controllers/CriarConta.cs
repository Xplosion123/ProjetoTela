using Microsoft.AspNetCore.Mvc;
using ProjetoTela.Models;
using ProjetoTela.Repositorio;
using BCrypt.Net; 

namespace ProjetoTela.Controllers
{
    public class CriarConta : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepo;

        public CriarConta(IUsuarioRepositorio usuarioRepo)
        {
            _usuarioRepo = usuarioRepo;
        }

        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Criar(Login model)
        {
            if (!ModelState.IsValid)
                return View(model);

            model.Nivel = "Operador";
            model.Senha = BCrypt.Net.BCrypt.HashPassword(model.Senha);

            _usuarioRepo.Adicionar(model);

            return RedirectToAction("Index", "Login");
        }
    }
}