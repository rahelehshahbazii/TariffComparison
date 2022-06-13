using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TariffComparison.Models;

namespace TariffComparison.Contract
{
   public interface IProductRepository
   {
      
        IEnumerable<Product> Comparison(double ConsumptionProductA, double ConsumptionProductB);
        IEnumerable<Product> GetAll(double ConsumptionProductA, double ConsumptionProductB);
        Task<Product> AddAsync(Product product);
        Task<Product> FindAsync(int id);
        Task<Product> UpdateAsync(Product product);
        Task<Product> RemoveAsync(int id);
        Task<bool> IsExistedAsync(int id);
        Task<int> CountProduct();
    }
}
