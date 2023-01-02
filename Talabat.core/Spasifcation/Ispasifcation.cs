using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talabat.core.Entites;

namespace Talabat.core.Spasifcation
{
    public interface Ispasifcation<T> where T:BaseEntity
    {
        //just segnet
        public Expression<Func<T, bool>> Critera { get; set; }
        public List< Expression<Func<T,Object>>> Includs { get; set; }
        public Expression<Func<T, object>> OrderBy { get; set; }
        public Expression<Func<T, object>> orderByDesinding { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
        public bool IsPageinationON { get; set; }

    }
}
