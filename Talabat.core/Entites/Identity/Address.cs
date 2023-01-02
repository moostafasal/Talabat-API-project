namespace Talabat.core.Entites.Identity
{
    public class Address
    {

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Country { get; set; }

        public string Street { get; set; }  


        public string AppUserId { get; set; }//ForingKey
        public AppUser User { get; set; } //Navigtinal Property [ONE]



    }
}