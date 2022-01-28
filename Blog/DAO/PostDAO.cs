﻿using Blog.Infra;
using Blog.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace Blog.DAO
{
    public class PostDAO
    {
        public IList<Post> Lista() 
        {
            using (BlogContext contexto = new BlogContext()) 
            {
                var lista = contexto.Posts.ToList();
                return lista;
            }
        }
        public void Adiciona(Post post) 
        {
            using (BlogContext contexto = new BlogContext()) 
            {
               contexto.Posts.Add(post);
               contexto.SaveChanges();
            }
            
        }
        public IList<Post> FiltraPorCategoria(string categoria)
        {
            using (BlogContext contexto = new BlogContext())
            {
                var lista = contexto.Posts.Where(post => post.Categoria.Contains(categoria)).ToList();
                return lista;
            }
        }
        public void Remove(int id)
        {
            using (BlogContext contexto = new BlogContext())
            {
                Post post = contexto.Posts.Find(id);
                contexto.Posts.Remove(post);
                contexto.SaveChanges();
            }
        }

        public Post BuscaPorId(int id)
        {
            using (BlogContext contexto = new BlogContext())
            {
                Post post = contexto.Posts.Find(id);
                return post;
            }
        }

        public void Atualiza(Post post)
        {
            using (BlogContext contexto = new BlogContext())
            {
                contexto.Entry(post).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }
    }
}