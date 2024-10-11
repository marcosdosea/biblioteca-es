using Core;
using Core.DTO;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    /// <summary>
    /// Implementa os serviços para manter os dados de editoras
    /// </summary>
    public class EditoraService : IEditoraService
    {
        private readonly BibliotecaContext context;

        public EditoraService(BibliotecaContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Criar uma nova editora na base de dados 
        /// </summary>
        /// <param name="editora">dados da editora</param>
        /// <returns>id gerado</returns>
        public uint Create(Editora editora)
        {
            context.Add(editora);
            context.SaveChanges();
            return editora.Id;
        }

        /// <summary>
        /// Remover editora da base de dados
        /// </summary>
        /// <param name="idEditora">id a ser removido</param>
        public void Delete(int id)
        {
            var editora = context.Editoras.Find(id);
            if (editora != null)
            {
                context.Remove(editora);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Atualizar dados da editora
        /// </summary>
        /// <param name="editora">novos dados da editora</param>
        public void Edit(Editora editora)
        {
            context.Update(editora);
            context.SaveChanges();
        }

        /// <summary>
        /// Obter os dados de uma editora na base de dados
        /// </summary>
        /// <param name="idEditora">id da editora</param>
        /// <returns>Dados da editora</returns>
        public Editora? Get(int id)
        {
            return context.Editoras.Find(id);
        }

        /// <summary>
        /// Obter dados de todas as editoras
        /// </summary>
        /// <returns>lista de editoras</returns>
        public IEnumerable<Editora> GetAll()
        {
            return context.Editoras.AsNoTracking();
        }

        /// <summary>
        /// Obter editoras que iniciam com o nome
        /// </summary>
        /// <param name="nome">nome da editora</param>
        /// <returns>lista de editoras</returns>
        public IEnumerable<Editora> GetByNome(string nome)
        {
            var query = from editora in context.Editoras
                        where editora.Nome.StartsWith(nome)
                        orderby editora.Nome
                        select editora;
            return query.AsNoTracking();
        }


        public IEnumerable<Editora> GetByEstados()
        {
            return context.Editoras.Where(
                editora => editora.Nome.Contains("Editora") &&
                (editora.Estado.Equals("SP") ||
                 editora.Estado.Equals("RS")));

            //var query = from editora in context.Editoras
            //            where editora.Nome.Contains("Editora") &&
            //                (editora.Estado.Equals("SP") ||
            //                editora.Estado.Equals("RS"))
           //             select editora;
           // return query.AsNoTracking();
        }
    }
}
