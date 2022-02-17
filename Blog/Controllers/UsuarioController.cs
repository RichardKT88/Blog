﻿using Blog.DAO;
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

        [HttpPost]
        public IActionResult Autentica(LoginViewModel model)
        {
            Usuario usuario = this.usuarioDAO.Busca(model.LoginName, model.Password);
            if (usuario != null) 
            {
                HttpContext.Session.SetString("usuario", JsonConvert.SerializeObject(usuario));
                return RedirectToAction("Index", "Post", new { area = "Admin" });
            }
            else
            {
                ModelState.AddModelError("login Inválido", "Login ou senha incorretos");
            }
            return View("Login", model);
        }
    }
}
