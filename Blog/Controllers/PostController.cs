using Blog.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class PostController : Controller
    {
        private IList<Post> _list;
        public PostController()
        {
            this._list = new List<Post>()
            {
                new Post(){Titulo = "Harry Potter 1", Resumo = "Pedra Filosofal", Categoria = "Filme e Livro"},
                new Post(){Titulo = "Vigadores ", Resumo = "Ultimato", Categoria = "Filme"},
                new Post(){Titulo = "Dom Casmurro", Resumo = "Romance sobre a dúvida", Categoria = "Livro"},
                new Post(){Titulo = "Segredinho", Resumo = "Funk do bom!!!", Categoria = "Música"}
            };
        }
        public IActionResult Index()
        {
            
            return View(_list);
        }

        public IActionResult Novo()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Adiciona(Post post)
        {
            _list.Add(post);
            return View("Index", _list);
        }
    }
}
