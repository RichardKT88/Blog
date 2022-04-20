using Blog.Infra;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.DAO
{
    public class PostDAO
    {
        private BlogContext contexto;
        public PostDAO(BlogContext contexto)
        {
            this.contexto = contexto;
        }
        public IList<Post> Lista()
        {

            var lista = contexto.Posts.ToList();
            return lista;

        }
        public void Adiciona(Post post)
        {

            contexto.Posts.Add(post);
            contexto.SaveChanges();
        }
        public IList<Post> FiltraPorCategoria(string categoria)
        {

            var lista = contexto.Posts.Where(post => post.Categoria.Contains(categoria)).ToList();
            return lista;

        }
        public void Remove(int id)
        {

            Post post = contexto.Posts.Find(id);
            contexto.Posts.Remove(post);
            contexto.SaveChanges();

        }

        public Post BuscaPorId(int id)
        {

            Post post = contexto.Posts.Find(id);
            return post;

        }

        public void Atualiza(Post post)
        {

            contexto.Entry(post).State = EntityState.Modified;
            contexto.SaveChanges();

        }

        public void Publicado(int id)
        {

            Post post = contexto.Posts.Find(id);
            post.Publicado = true;
            post.DataPublicacao = DateTime.UtcNow.ToLocalTime();
            contexto.SaveChanges();

        }

        public IList<string> ListaCategoriasQueContemTermo(string termo)
        {

            return contexto.Posts
                .Where(p => p.Categoria.Contains(termo))
                .Select(p => p.Categoria)
                .Distinct()
                .ToList();

        }

        public IList<Post> ListaPublicados()
        {

            return contexto.Posts.Where(p => p.Publicado).
                OrderByDescending(p => p.DataPublicacao).ToList();

        }
        public IList<Post> BuscaPeloTermo(string termo)
        {
           
                return contexto.Posts
                    .Where(p => (p.Publicado) && (p.Titulo.Contains(termo) || p.Resumo.Contains(termo)))
                    .ToList();

        }
    }
}
