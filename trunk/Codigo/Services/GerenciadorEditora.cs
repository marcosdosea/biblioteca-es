using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using Persistence;
using Models;


namespace Services
{
    /// <summary>
    /// Gerencia todas as regras de negócio da entidade Editora
    /// </summary>
    
    public class GerenciadorEditora

    {
        private IUnitOfWork unitOfWork;
        private bool shared;
        
        /// <summary>
        /// Construtor pode ser acessado externamente e não compartilha contexto
        /// </summary>
        public GerenciadorEditora()
        {
            this.unitOfWork = new UnitOfWork();
            shared = false;
        }

        /// <summary>
        /// Construtor acessado apenas dentro do componentes service e permite compartilhar
        /// contexto com outras classes de negócio
        /// </summary>
        /// <param name="unitOfWork"></param>
        internal GerenciadorEditora(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            shared = true;
        }

        /// <summary>
        /// Insere um novo na base de dados
        /// </summary>
        /// <param name="editoraModel">Dados do modelo</param>
        /// <returns>Chave identificante na base</returns>
        public int Inserir(Editora editoraModel)
        {
            tb_editora editoraE = new tb_editora();
            Atribuir(editoraModel, editoraE);
            unitOfWork.RepositorioEditora.Inserir(editoraE);
            unitOfWork.Commit(shared);
            return editoraE.idEditora;
        }

        /// <summary>
        /// Altera dados na base de dados
        /// </summary>
        /// <param name="editoraModel"></param>
        public void Editar(Editora editoraModel)
        {
            tb_editora editoraE = new tb_editora(); 
            Atribuir(editoraModel, editoraE);
            unitOfWork.RepositorioEditora.Editar(editoraE);
            unitOfWork.Commit(shared);
        }

        /// <summary>
        /// Remove da base de dados
        /// </summary>
        /// <param name="editoraModel"></param>
        public void Remover(int idEditora)
        {
            unitOfWork.RepositorioEditora.Remover(editora => editora.idEditora.Equals(idEditora));
            unitOfWork.Commit(shared);
        }


        /// <summary>
        /// Consulta padrão para retornar dados do editora como model
        /// </summary>
        /// <returns></returns>
        private IQueryable<Editora> GetQuery()
        {
             IQueryable<tb_editora> tb_editora = unitOfWork.RepositorioEditora.GetQueryable();
            var query = from editora in tb_editora 
                        select new Editora
                        {
                            Codigo = editora.idEditora,
                            Nome = editora.nome,
                            Bairro = editora.bairro,
                            Cep = editora.cep,
                            Cidade = editora.cidade,
                            Estado = editora.estado,
                            Numero = editora.numero,
                            Rua = editora.rua
                        };
            return query;
        }

        /// <summary>
        /// Obter todos as entidades cadastradas
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Editora> ObterTodos()
        {
            return GetQuery();
        }

        /// <summary>
        /// Obtém um editora
        /// </summary>
        /// <param name="idEditora">Identificador do editora na base de dados</param>
        /// <returns>Editora model</returns>
        public Editora Obter(int idEditora)
        {
            IEnumerable<Editora> editoraes = GetQuery().Where(editoraModel => editoraModel.Codigo.Equals(idEditora));
            return editoraes.ElementAtOrDefault(0);
        }


        /// <summary>
        /// Atribui dados do Editora Model para o Editora Entity
        /// </summary>
        /// <param name="editoraModel">Objeto do modelo</param>
        /// <param name="editoraE">Entity mapeada da base de dados</param>
        private void Atribuir(Editora editoraModel, tb_editora editoraE)
        {
            editoraE.idEditora = editoraModel.Codigo;
            editoraE.nome = editoraModel.Nome;
            editoraE.bairro = editoraModel.Bairro;
            editoraE.cidade = editoraModel.Cidade;
            editoraE.estado = editoraModel.Estado;
            editoraE.numero = editoraModel.Numero;
            editoraE.rua = editoraModel.Rua;
            editoraE.cep = editoraModel.Cep;
        }
    }
}
