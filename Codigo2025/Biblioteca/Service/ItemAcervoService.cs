using Core;
using Core.DTO;
using Core.Service;

namespace Service
{
    /// <summary>
    /// Implementa serviços para manter os dados do item do acervo
    /// </summary>
    public class ItemAcervoService : IItemAcervoService
    {
        private readonly BibliotecaContext context;

        public ItemAcervoService(BibliotecaContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Cria um novo item no acervo
        /// </summary>
        /// <param name="itemAcervo">dados do item acervo</param>
        /// <returns>id gerado</returns>
        public uint Create(Itemacervo itemAcervo)
        {
            context.Add(itemAcervo);
            context.SaveChanges();
            return itemAcervo.Id;
        }

        /// <summary>
        /// Remover item acervo da base de dados
        /// </summary>
        /// <param name="idItemAcervo">id a ser removido</param>
        public void Delete(int id)
        {
            var itemAcervo = context.Itemacervos.Find(id);
            if (itemAcervo != null)
            {
                context.Remove(itemAcervo);
                context.SaveChanges();
            }
        }
        /// <summary>
        /// Atualiza os dados de um item no acervo
        /// </summary>
        /// <param name="itemAcervo">novos dados do item acervo</param>
        public void Edit(Itemacervo itemAcervo)
        {
            context.Update(itemAcervo);
            context.SaveChanges();
        }

        /// <summary>
        /// Busca os dados de um item do acervo
        /// </summary>
        /// <param name="idItemAcervo">id a ser buscado</param>
        /// <returns>todos os dados do item acervo</returns>
        public Itemacervo? Get(int id)
        {
            return context.Itemacervos.Find(id);
        }

        /// <summary>
        /// Obter todos os itens do acervo cadastrados
        /// </summary>
        /// <returns>todos os itens acervo</returns>
        public IEnumerable<ItemAcervoDto> GetAll()
        {
            var query = from itemAcervo in context.Itemacervos
                        orderby itemAcervo.IdLivroNavigation.Nome descending
                        select new ItemAcervoDto
                        {
                            Id = itemAcervo.Id,
                            NomeLivro = itemAcervo.IdLivroNavigation.Nome,
                            NomeBiblioteca = itemAcervo.IdBibliotecaNavigation.Nome,
                            SituacaoItemAcervo = itemAcervo.IdSituacaoItemAcervoNavigation.Situacao
                        };
            return query;
        }
    }
}
