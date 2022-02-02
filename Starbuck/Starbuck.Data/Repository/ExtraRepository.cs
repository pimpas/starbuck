using System;
using System.Collections.Generic;
using System.Text;
using Starbuck.Business.Models;
using Starbuck.Business.Interfaces;
using Starbuck.Data.Context;
namespace Starbuck.Data.Repository
{
    public class ExtraRepository : Repository<Extra>, IExtraRepository
    {
        public ExtraRepository(MyDbContext context) : base(context) { }
    }
}
