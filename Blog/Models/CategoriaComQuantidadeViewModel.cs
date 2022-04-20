namespace Blog.Models
{
    public class CategoriaComQuantidadeViewModel
    {
        private Dictionary<string, int> categoriaPorQuantidade;
        public CategoriaComQuantidadeViewModel(IList<Post> posts)
        {
            categoriaPorQuantidade = new Dictionary<string, int>();
            foreach (Post post in posts)
            {
                string categoria = post.Categoria;
                if (categoriaPorQuantidade.ContainsKey(categoria))
                {
                    int quantidade = categoriaPorQuantidade[categoria];
                    categoriaPorQuantidade.Remove(categoria);
                    categoriaPorQuantidade.Add(categoria, quantidade + 1);

                }
                else 
                {
                    categoriaPorQuantidade.Add(categoria, 1);
                }
            }

        }

        public IList<string> GetCategorias()
        {
            return categoriaPorQuantidade.Keys.ToList();
        }

        public int GetQuantidadeDePostDa(string categoria)
        {
            return categoriaPorQuantidade[categoria];
        }
    }
}
