using System;
using System.Collections.Generic;
using System.Text;
using Starbuck.Business.Interfaces;
using Starbuck.Business.Models;
using Starbuck.Data.Context;

namespace Starbuck.Data.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(MyDbContext context) : base(context) { }
    }
}
