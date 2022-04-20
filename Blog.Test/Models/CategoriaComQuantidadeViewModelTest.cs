using Blog.Models;
using Xunit;

namespace Blog.Test.Models
{
    public class CategoriaComQuantidadeViewModelTest
    {
        [Fact]
        public void aListaDeCategoriasDeveIgnorarEspacoAEsquerdaEADireitaDoNomeQuandoAgrupar() 
        {
            //cenário
            Post filmeMulherMaravilha = new Post()
            {
                Titulo = "Mulher Maravilha",
                Resumo = "Filme de origem da princesa Diana",
                Categoria = "Filme"
            };
            Post filmeSenhorAneis = new Post()
            {
                Titulo = "Senhor dos anéis",
                Resumo = "As duas torres",
                Categoria = "  Filme  "
            };
            List<Post> posts = new List<Post>() { filmeMulherMaravilha, filmeSenhorAneis };

            //Ação
            CategoriaComQuantidadeViewModel categoriaComQuantidade = new CategoriaComQuantidadeViewModel(posts);
            int quantidadeDeFilmes = categoriaComQuantidade.GetQuantidadeDePostDa("Filme");

            //Validação
            Assert.Equal(2, quantidadeDeFilmes);

        }
    }
}
