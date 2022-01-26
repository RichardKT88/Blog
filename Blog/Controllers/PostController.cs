using Blog.DAO;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class PostController : Controller
    {
        
        public PostController()
        {
            
        }
        public IActionResult Index()
        {
            PostDAO dao = new PostDAO();
            IList<Post> lista = dao.Lista();
            return View(lista);
        }

        public IActionResult Novo()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Adiciona(Post post)
        {
            PostDAO dao = new PostDAO();
            dao.Adiciona(post);
            return RedirectToAction("Index");
        }
    }
}
