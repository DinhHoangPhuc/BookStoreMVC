using BookStore.Data;
using BookStore.Models;
using BookStore.Repository.IRepository;

namespace BookStore.Repository
{
    public class CategoryRepository : Repository<Catergory>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Catergory category)
        {
            _db.Catergories.Update(category);
        }
    }
}
