using MVC04.Models;

namespace MVC04.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product GetById(int id);
        void Add(Product product);
        void Delete(int id);
        bool IsNameExists(string name);
    }
}