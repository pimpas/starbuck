using System;
using System.Collections.Generic;
using System.Text;
using Starbuck.Business.Models;
using Starbuck.Business.Interfaces;
using System.Threading.Tasks;
using Starbuck.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Starbuck.Data.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(MyDbContext context) : base(context) { }

        public async Task<IEnumerable<Product>> GetProductsByCategory(Guid id)
        {
            return await Find(p => p.CategoryId == id);
        }
    }
}
