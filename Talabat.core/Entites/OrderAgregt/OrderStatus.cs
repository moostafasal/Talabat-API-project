using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.core.Entites.OrderAgregt
{
    public enum OrderStatus
    {

        //this is the status of the order
        [EnumMember(Value = "Pending")]
        Pending,
        [EnumMember(Value = "PaymentRecevied")]
        PaymentRecevied,
        [EnumMember(Value = "PaymentFailed")]

        PaymentFailed

    }
}
