// See https://aka.ms/new-console-template for more information
using Blog.Models;

Console.WriteLine("Hello, World!");

//Cenário
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
Console.WriteLine(quantidadeDeFilmes == 2);