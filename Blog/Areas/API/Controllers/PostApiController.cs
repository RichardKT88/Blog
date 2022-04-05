using Blog.DAO;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Areas.API.Controllers
{
    [Area("Api")]
    [Route("api/[controller]")]
    [ApiController]
    public class PostApiController : ControllerBase
    {
        private readonly PostDAO _dao;
        public PostApiController(PostDAO dao)
        {
            _dao = dao;
        }

        [HttpGet]
        [Route("lista")]
        public IActionResult BuscaTodosPosts()
        {
            IList<Post> posts = _dao.Lista();
            return Ok(posts);

        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult BuscaPostsPorId(int id)
        {
            return Ok(_dao.BuscaPorId(id));

        }

        [HttpPost]
        [Route("Novo")]
        public IActionResult CadastraPost(Post post)
        {
            _dao.Adiciona(post);
            return CreatedAtAction("BuscaPostsPorId", new { Id = post.Id }, post);

        }
    }
}
