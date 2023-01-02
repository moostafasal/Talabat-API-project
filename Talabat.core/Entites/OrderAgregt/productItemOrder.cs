using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.core.Entites.OrderAgregt
{
    public class productItemOrder
    {//not table in the data base
        public productItemOrder(int productId, string productName, string pictuerUrl)
        {
            ProductId = productId;
            this.productName = productName;
            this.pictuerUrl = pictuerUrl;
        }

        public int ProductId { get; set; }
        //public Product Product { get; set; }
        public int OrderId { get; set; }
        public string productName { get; set; }

        public string pictuerUrl { get; set; }
    }
}
