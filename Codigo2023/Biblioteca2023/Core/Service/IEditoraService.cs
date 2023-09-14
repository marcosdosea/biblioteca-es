namespace Core.Service
{
    public interface IEditoraService
    {
        uint Create(Editora editora);
        void Edit(Editora editora);
        void Delete(int id);
        Editora? Get(int id);
        IEnumerable<Editora> GetAll();
        IEnumerable<Editora> GetByNome(string nome);
    }
}
