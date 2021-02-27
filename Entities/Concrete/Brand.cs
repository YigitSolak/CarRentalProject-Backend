using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Brand:IEntity
    {
        public int BrandsId { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
    }
}
