using Blog.DAO;
using Blog.Infra;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private PostDAO dao;
        public HomeController(PostDAO dao)
        {
            this.dao = dao;
        }
        
        public ActionResult Index()
        {
            IList<Post> publicados = dao.ListaPublicados();
            return View(publicados);
        }

        public ActionResult Busca(string termo)
        {
            IList<Post> posts = dao.BuscaPeloTermo(termo);
            return View("Index", posts);
        }
       
    }
}