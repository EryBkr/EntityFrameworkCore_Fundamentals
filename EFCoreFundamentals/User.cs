using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreFundamentals
{
    public class User
    {
        public User()
        {
            this.Addresses = new List<Address>();  //Null Ref hatası almamak için ekledik.
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Address> Addresses { get; set; }//İlişkinin çok tarafı
        public Customer Customer { get; set; } //Birebir ilişki
    }
}
