using BookStore.Models;

namespace BookStore.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Catergory>
    {
        void Update(Catergory category);
        void Save();
    }
}
