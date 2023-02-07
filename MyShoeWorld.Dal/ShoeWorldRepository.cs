using Microsoft.EntityFrameworkCore;

namespace MyShoeWorld.Dal
{
    public class ShoeWorldRepository<T> : IShoeWorldRepository<T> where T : class
    {
        private readonly MyShoeWorldDbContext _dbContext;
        private DbSet<T> _dbSet;
        //Dependency injection :constructor
        public ShoeWorldRepository(MyShoeWorldDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }
        public void delete(int id)
        {
            _dbContext.Remove(GetDetails(id));
        }

        public T GetDetails(int id)
        {
            return _dbSet.Find(id);
        }

        public void insert(T item)
        {
            _dbSet.Add(item);
        }

        public int SaveChanges()
        {
           return  _dbContext.SaveChanges();
        }
        //NO OF ROWS AFFECR=ED DUE TO ROWS

        public void update(T item)
        {
            _dbSet.Attach(item);
             _dbContext.Entry(item).State = EntityState.Modified;
        }
        
    }
}
