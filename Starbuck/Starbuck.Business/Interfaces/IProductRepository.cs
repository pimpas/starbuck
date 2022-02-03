using System;
using System.Collections.Generic;
using System.Text;
using Starbuck.Business.Models;
using System.Threading.Tasks;

namespace Starbuck.Business.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsByCategory(Guid categoryId);
    }
}
