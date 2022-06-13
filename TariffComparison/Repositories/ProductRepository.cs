using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TariffComparison.Contract;
using TariffComparison.Models;

namespace TariffComparison.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ComparisonTariffDBContext _context;

        public ProductRepository(ComparisonTariffDBContext context)
        {
            _context = context;
        }
     
        public async Task<Product> AddAsync(Product product)
        {
            await _context.Product.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> FindAsync(int id)
        {
            return await _context.Product.SingleOrDefaultAsync(p => p.Productid == id);

        }
        public IEnumerable<Product> GetAll(double ConsumptionProductA ,double ConsumptionProductB )
        {
            return Comparison(ConsumptionProductA, ConsumptionProductB);
        }

        public IEnumerable<Product> Comparison(double ConsumptionProductA, double ConsumptionProductB)
        {
                        
            int basecostspermonth = 5;

            // with ConsumptionA
            int basecosts = basecostspermonth * 12;
            double ConsumptioncostsA = (float)(ConsumptionProductA * 0.22);                   // 22 cent/kWh    
            double AnnualcostsA = basecosts + (ConsumptioncostsA);

            //with ConsumptionB
            double AnnualcostsB;
            if (ConsumptionProductB < 4000)
            {
                AnnualcostsB = 800;
            }
            else
            {
                double additionalconsumptioncosts = (ConsumptionProductB - 4000) * 0.3;      //30 cent/kWh
                AnnualcostsB = 800 + additionalconsumptioncosts;
            }

            if (AnnualcostsA > AnnualcostsB)
            {
                
                Console.WriteLine("$ The Annualcosts of ProductA is biger that Annualcosts of ProductB");

            }
            else if (AnnualcostsA < AnnualcostsB)
            {
                Console.WriteLine("$ The Annualcosts of ProductA is small that Annualcosts of ProductB");
            }
            else
            {
                Console.WriteLine("$  Annualcosts of ProductA and ProductB are the same");
            }

            var ProductList = new List<Product>()
            {
                new Product(){ Productid = 1, Tariffname="basic electricity tariff",Annualcosts= AnnualcostsA },
                new Product(){ Productid = 2, Tariffname="Packaged tariff",Annualcosts=AnnualcostsB},
            };
            List<Product> SortedList = ProductList.OrderBy(P => P.Annualcosts).ToList();
            return SortedList;
        }

        //public IEnumerable<Product> GetAll()
        //{
        //    return _context.Product.ToList();
        //}

        public async Task<bool> IsExistedAsync(int id)
        {
            return await _context.Product.AnyAsync(p=>p.Productid == id );
        }

        public async Task<Product> RemoveAsync(int id)
        {
            var product = await _context.Product.SingleAsync(p => p.Productid == id);
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            _context.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }
        public async Task<int> CountProduct()
        {
            return await _context.Product.CountAsync();
        }

       
    }
}
