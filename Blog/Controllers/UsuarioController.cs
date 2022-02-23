using Blog.DAO;
using Blog.Extensions;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Blog.Controllers
{
    public class UsuarioController : Controller
    {
        private UsuarioDAO usuarioDAO;
        public UsuarioController(UsuarioDAO usuarioDAO)
        {
            this.usuarioDAO = usuarioDAO;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Autentica(LoginViewModel model)
        {
            if (ModelState.IsValid) 
            {
                Usuario usuario = this.usuarioDAO.Busca(model.LoginName, model.Password);
                if (usuario != null)
                {
                    HttpContext.Session.Set<Usuario>("usuario", usuario);
                    return RedirectToAction("Index", "Post", new { area = "Admin" });
                }
                else
                {
                    ModelState.AddModelError("login Inválido", "Login ou senha incorretos");
                }
            }           
            return View("Login", model);
        }
        [HttpPost]
        public IActionResult Cadastra(RegistroViewModel model) 
        {
            if (ModelState.IsValid) 
            {
                Usuario usuario = new Usuario()
                {
                    Nome = model.LoginName,
                    Email = model.Email,
                    Senha = model.Senha,
                };
                usuarioDAO.Adiciona(usuario);
                return RedirectToAction("Login");
            }
            return View("Novo", model);
        }
    }
}
