namespace Talabat.Errors
{
    public class ApiExptionRespons:Api_Response
    {
        public string Details { get; set; }
        public ApiExptionRespons(int SutausCode,string Massage=null,string details=null):base(SutausCode,Massage)
        {
            Details = details;


        }
    }
}
