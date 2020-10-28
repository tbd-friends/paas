using System.Threading.Tasks;

namespace Gamer.Customer.Customers.Infrastructure
{
    public interface IRepository
    {
        Task Add<T>(T entity, string collectionName);
    }
}