using Blog.DAO;
using Blog.Infra;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private PostDAO _dao;
        public HomeController(PostDAO dao)
        {
            _dao = dao;
        }
        
        public ActionResult Index()
        {
            IList<Post> publicados = _dao.ListaPublicados();
            return View(publicados);
        }

        public ActionResult Busca(string termo)
        {
            IList<Post> posts = _dao.BuscaPeloTermo(termo);
            return View("Index", posts);
        }

        public IActionResult Categoria([Bind(Prefix ="id")] string categoria) 
        {
            IList<Post> posts = _dao.FiltraPorCategoria(categoria);
            return View("Index", posts);
        }
       
    }
}