using System.Collections.Generic;
using Talabat.DTOS;

namespace Talabat.Helper
{
    public class Pagin<T>
    {

        public int PageIndex { get; set; }
        public int PageSiez { get; set; }
        public int Count { get; set; }
        public IEnumerable<T> Data { get; set; } 

        public Pagin(int pageIndex, int pagesize, IEnumerable<T> data,int count)
        {
            PageIndex = pageIndex;
            PageSiez = pagesize;
            Data = data;
            Count = count;
        }
    }
}
