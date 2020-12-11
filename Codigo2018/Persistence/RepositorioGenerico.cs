using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Objects;
using System.Data;

namespace Persistence
{
    /// <summary>
    /// Repositório genérico para trabalhar com dados no SGBD
    /// </summary>
    /// <typeparam name="T">Um POCO que representa uma entidade no Entity Framework </typeparam>
    public class RepositorioGenerico<T>: IRepositorioGenerico<T> 
        where T: class, new()
    {
        /// <summary>
        /// Objeto contexto para o sgbd
        /// </summary>
        private ObjectContext _context;

        /// <summary>
        /// Representa a entidade corrente
        /// </summary>
        private IObjectSet<T> _objectSet;

        /// <summary>
        /// Inicializa uma nova instância do repositório
        /// </summary>
        /// <param name="contexto">O Objeto contexto do Entity Framework </param>
        /// <param name="chave"> Identifica o contexto criado </param>
        public RepositorioGenerico(ObjectContext context)
        {
            _context = context;
            _objectSet = _context.CreateObjectSet<T>();
        }

        /// <summary>
        /// Insere uma nova entidade no contexto
        /// </summary>
        /// <param name="entity"></param>
        public T Inserir(T entidade)
        {
            if (entidade == null)
            {
                throw new ArgumentNullException("entity");
            }

            _objectSet.AddObject(entidade);
            return entidade;
        }

        /// <summary>
        /// Faz a edição dos dados de uma entidade
        /// </summary>
        /// <param name="entidade"></param>
        public void Editar(T entidade)
        {
            _objectSet.Attach(entidade);
            _context.ObjectStateManager.ChangeObjectState(entidade, EntityState.Modified);
        }

        /// <summary>
        /// Remove a entidade especificada
        /// </summary>
        /// <param name="entity">entidade que deve ser removida</param>
        public void Remover(T entidade)
        {
            if (entidade == null)
            {
                throw new ArgumentNullException("entity");
            }
            _objectSet.DeleteObject(entidade);
        }

        /// <summary>
        /// Exclui várias entidade que atendem ao critério especificado
        /// </summary>
        /// <param name="where">critério para exclusão da entidade</param>
        public void Remover(Func<T, bool> where)
        {
            _objectSet.Where(where).ToList().ForEach(entidade => _objectSet.DeleteObject(entidade));  
        }


        /// <summary>
        /// Obtém uma única entidade de acordo com o critério
        /// </summary>
        /// <param name="where">critério que deve retornar a entidade única</param>
        /// <returns>entidade única ou exceção quando existem mais de uma entidade </returns>
        public T ObterEntidade(Func<T, bool> where)
        {
            return _objectSet.Single<T>(where);
        }

        /// <summary>
        /// Obtém a primeira entidade do conjunto que atende a um determinado critério
        /// </summary>
        /// <param name="where">critério para busca das entidades</param>
        /// <returns>a primeira eentidade ou um valor default</returns>
        public T ObterPrimeiro(Func<T, bool> where)
        {
            return _objectSet.Where(where).FirstOrDefault();
        }

        /// <summary>
        /// Obter a lista de todas as entidades
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> ObterTodos()
        {
            return _objectSet.ToList();
        }

        /// <summary>
        /// Obter conjunto de entidades que atende a um determinado critério
        /// </summary>
        /// <param name="where">critério para recuperar entidades</param>
        /// <returns>conjunto de entidades</returns>
        public IEnumerable<T> Obter(Func<T, bool> where)
        {
            return _objectSet.Where(where);
        }

        /// <summary>
        /// Obter objeto para criação de consulta específica
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> GetQueryable()
        {
            return _objectSet;
        }

        /// <summary>
        /// Remove de objeto da memória
        /// </summary>
        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
            GC.SuppressFinalize(this);
        }
    }
}