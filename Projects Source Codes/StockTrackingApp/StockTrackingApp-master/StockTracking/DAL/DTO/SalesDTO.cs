using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracking.DAL.DTO
{
   public class SalesDTO
    {
        public List<SalesDetailDTO> Sales { get; set; }
        public List<CustomerDetailDTO> Customers { get; set; }
        public List<ProductDetailDTO> Products { get; set; }
        public List<CategoryDetailDTO> Categories { get; set; }

    }
}
