using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using Persistence;

namespace Persistence
{
    /// <summary>
    /// UnitWork é um padrão de projeto que permite trabalhar 
    /// com vários repositórios compartilhando um mesmo contexto
    /// transacional
    /// </summary>
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private BibliotecaEntities _context;
        private IRepositorioGenerico<tb_autor> _repAutor;
        private IRepositorioGenerico<tb_editora> _repEditora;
        private IRepositorioGenerico<tb_livro> _repLivro;

        /// <summary>
        /// Construtor cria contexto transacional
        /// </summary>
        public UnitOfWork()
        {
            _context = new Models.BibliotecaEntities();
        }
        
        #region IUnitOfWork Members

        /// <summary>
        /// Repositório para manipular dados persistidos de Editoras
        /// </summary>
        public IRepositorioGenerico<tb_editora> RepositorioEditora
        {
            get
            {
                if (_repEditora == null)
                {
                    _repEditora = new RepositorioGenerico<tb_editora>(_context);
                }
                
                return _repEditora;
            }
        }

        /// <summary>
        /// Repositório para manipular dados persistidos de autores
        /// </summary>
        public IRepositorioGenerico<tb_autor> RepositorioAutor { 
            get
            {
                if (_repAutor == null) {
                    _repAutor = new RepositorioGenerico<tb_autor>(_context);
                }
                return _repAutor;
            }
        }

        /// <summary>
        /// Repositório para manipular dados persistidos de livros
        /// </summary>
        public IRepositorioGenerico<tb_livro> RepositorioLivro
        {
            get
            {
                if (_repLivro == null)
                {
                    _repLivro = new RepositorioGenerico<tb_livro>(_context);
                }
                return _repLivro;
            }
        }

        /// <summary>
        /// Salva todas as mudanças realizadas no contexto
        /// quando o contexto não for compartilhado
        /// </summary>
        public void Commit(bool shared)
        {
            if (!shared)
                _context.SaveChanges();
        }

        #endregion

        private bool disposed = false;
        /// <summary>
        /// Retira da memória um determinado contexto
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// Limpa contexto da memória
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
