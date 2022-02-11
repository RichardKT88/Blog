using Blog.DAO;
using Blog.Infra;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            PostDAO dao = new PostDAO();
            IList<Post> publicados = dao.ListaPublicados();
            return View(publicados);
        }

        public IList<Post> BuscaPeloTermo(string termo) 
        {
            using (var contexto = new BlogContext())
            {
                return contexto.Posts
                    .Where(p => (p.Publicado) && (p.Titulo.Contains(termo) || p.Resumo.Contains(termo)))
                    .ToList();

            }
        }
    }
}