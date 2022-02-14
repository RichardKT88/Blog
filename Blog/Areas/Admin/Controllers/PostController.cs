using Blog.DAO;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PostController : Controller
    {
        private PostDAO dao;
        public PostController(PostDAO dao)
        {
            this.dao = dao;
        }
        public IActionResult Index()
        {
            IList<Post> lista = dao.Lista();
            return View(lista);
        }

        public IActionResult Novo()
        {
            var model = new Post();
            return View(model);
        }
        public IActionResult Categoria([Bind(Prefix = "id")] string categoria)
        {
            IList<Post> lista = dao.FiltraPorCategoria(categoria);
            return View("Index", lista);
        }
        [HttpPost]
        public IActionResult Adiciona(Post post)
        {
            if (ModelState.IsValid)
            {
                dao.Adiciona(post);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Novo", post);
            }
        }
        public IActionResult RemovePost(int id)
        {
            dao.Remove(id);
            return RedirectToAction("Index");
        }
        public IActionResult Visualiza(int id)
        {
            Post post = dao.BuscaPorId(id);
            return View(post);
        }
        [HttpPost]
        public IActionResult EditaPost(Post post)
        {
            if (ModelState.IsValid)
            {
                dao.Atualiza(post);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Visualiza", post);
            }
        }

        public IActionResult PublicaPost(int id)
        {
            dao.Publicado(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult CategoriaAutocomplete(string termoDigitado)
        {
            var model = dao.ListaCategoriasQueContemTermo(termoDigitado);
            return Json(model);
        }
    }
}
