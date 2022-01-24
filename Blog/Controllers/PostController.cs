using Blog.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            var listaDePosts = new List<Post>()
            {
                new Post(){Titulo = "Harry Potter 1", Resumo = "Pedra Filosofal", Categoria = "Filme e Livro"},
                new Post(){Titulo = "Vigadores ", Resumo = "Ultimato", Categoria = "Filme"},
                new Post(){Titulo = "Dom Casmurro", Resumo = "Romance sobre a dúvida", Categoria = "Livro"},
                new Post(){Titulo = "Segredinho", Resumo = "Funk do bom!!!", Categoria = "Música"}
            };
            //ViewBag.Posts = listaDePosts;
            return View(listaDePosts);
        }
    }
}
