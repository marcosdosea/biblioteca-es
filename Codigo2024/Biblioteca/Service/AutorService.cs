﻿using Core;
using Core.DTO;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    /// <summary>
    /// Implementa serviços para manter dados do autor
    /// </summary>
    public class AutorService : IAutorService
    {
        private readonly BibliotecaContext context;

        public AutorService(BibliotecaContext context)
        {
            this.context = context;
        }


        /// <summary>
        /// Criar um novo autor na base de dados
        /// </summary>
        /// <param name="autor">dados do autor</param>
        /// <returns>id do autor</returns>
        public uint Create(Autor autor)
        {
            context.Add(autor);
            context.SaveChanges();
            return autor.Id;
        }

        /// <summary>
        /// Remover o autor da base de dados
        /// </summary>
        /// <param name="idAutor">id do autor</param>
        public void Delete(uint id)
        {
            var autor = context.Autors.Find(id);
            if (autor != null)
            {
                context.Remove(autor);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Editar dados do autor na base de dados
        /// </summary>
        /// <param name="autor"></param>
        /// <exception cref="ServiceException"></exception>
        public void Edit(Autor autor)
        {
            if (autor.DataNascimento.Year < 1000)
                throw new ServiceException("O ano de nascimento de autor deve ser maior do que 1000. Favor informar nova data.");

            context.Update(autor);
            context.SaveChanges();
        }

        /// <summary>
        /// Buscar todos os autores cadastrados
        /// </summary>
        /// <returns>lista de autores</returns>
        public IEnumerable<Autor> GetAll()
        {
            return context.Autors.AsNoTracking();
        }

        /// <summary>
        /// Buscar um autor na base de dados
        /// </summary>
        /// <param name="idAutor">id autor</param>
        /// <returns>dados do autor</returns>
        public Autor? Get(uint id)
        {
            return context.Autors.FirstOrDefault(a => a.Id == id);
        }



        public IEnumerable<Autor> GetOrderByDescending()
        {
            //var query = from autor in context.Autors
            //            orderby autor.Nome descending
            //            select autor;

            return context.Autors.
                OrderByDescending(autor => autor.Nome);
        }


        /// <summary>
        /// Buscar autores iniciando com o nome
        /// </summary>
        /// <param name="nome">nome do autor</param>
        /// <returns>lista de autores que inicia com o nome</returns>
        public IEnumerable<AutorDto> GetByNome(string nome)
        {
            var query = from autor in context.Autors
                        where autor.Nome.StartsWith(nome)
                        orderby autor.Nome
                        select new AutorDto
                        {
                            IdAutor = autor.Id,
                            Nome = autor.Nome
                        };
            return query;
        }
    }
}
