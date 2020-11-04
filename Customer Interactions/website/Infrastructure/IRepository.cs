using System.Threading.Tasks;

namespace Gamer.Customer.Website.Infrastructure
{
    public interface IRepository
    {
        Task Add<T>(T entity, string collectionName);
    }
}