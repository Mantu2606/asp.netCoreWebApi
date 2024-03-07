using Microsoft.EntityFrameworkCore;
using WebPocHub.dal;

namespace WebPocHub.Dal
{
    // T - Employee, Role, User, event
    // CommonRepository - generic method
    public class CommonRepository<T> : ICommonRepository<T> where T : class
    {
        private readonly WebPocHubDbContext _dbContext;
        private DbSet<T> table;
        public CommonRepository(WebPocHubDbContext context)
        {
            _dbContext = context;
            table = _dbContext.Set<T>();
        }
        public List<T> GetAll()
        {
            return table.ToList();
        }
        public T GetDetails(int id)
        {
            return table.Find(id);
        }
        public void Insert(T item)
        {
            table.Add(item);
        }
        public void Update(T item)
        {
            table.Attach(item);
            _dbContext.Entry(item).State = EntityState.Modified;
        }
        public void Delete(T item)
        {
            table.Remove(item);
        }
        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        void ICommonRepository<T>.SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
