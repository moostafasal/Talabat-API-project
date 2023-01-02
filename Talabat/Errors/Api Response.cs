using System;

namespace Talabat.Errors
{
    public class Api_Response
    {
        public int StaterCode { get; set; }
        public string Massege { get; set; }

        public Api_Response(int staterCode, string massege=null)
        {
            StaterCode = staterCode;
            Massege = massege ?? GetDefultmassegForStatusCode(StaterCode);
        }

        private string GetDefultmassegForStatusCode(int staterCode)
        {
            return StaterCode switch
            {
                400=>"Abad requst tou have made",
                401=>"Authrized,U are not",
                404=>"Resours Not found!!!!!",
                500=>"DOXXXX =>SERVER ERRor plasse wate we wil back soon ",
                _=>null

            };
        }
    }
}
