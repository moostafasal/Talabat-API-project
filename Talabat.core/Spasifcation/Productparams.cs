using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.core.Spasifcation
{
    public class Productparams
    {
        private const int  MaxPageSize= 10;
        public int pageIndex { get; set; } = 1;
        private int pageSize = 5;

        public int  Pagesize
        {
            get { return pageSize; }
            set { pageSize = value > MaxPageSize ? MaxPageSize : value; }
        }
        private string serch;

        public string Serch
        {
            get { return serch; }
            set { serch = value.ToLower(); }
        }



        public string sort { get; set; }
      public  int? brandId { get; set; }
       public  int? TypeId { get; set; }

    }
}
