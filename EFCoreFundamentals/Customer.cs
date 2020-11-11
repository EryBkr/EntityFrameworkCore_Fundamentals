using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreFundamentals
{
    public class Customer
    {
        public int Id { get; set; }
        public string IdentityNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UserId { get; set; } //Birebir ilişki
        public User User { get; set; }//Navigation Property
    }
}
