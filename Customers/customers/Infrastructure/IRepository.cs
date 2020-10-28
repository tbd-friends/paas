using System.Threading.Tasks;

namespace customers.Infrastructure
{
    public interface IRepository
    {
        Task Add<T>(T entity, string collectionName);
    }
}