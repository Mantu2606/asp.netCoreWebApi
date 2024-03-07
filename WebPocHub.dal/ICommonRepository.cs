
namespace WebPocHub.dal
{
    public interface ICommonRepository<T> // ICommonRepository is called generic method
    {
        // T - Employee, Role, User, event
        List<T> GetAll();
        T GetDetails(int id);   
        void Insert(T item);
        void Update(T item);    
        void Delete(int id);    
        void SaveChanges();
    }
}
