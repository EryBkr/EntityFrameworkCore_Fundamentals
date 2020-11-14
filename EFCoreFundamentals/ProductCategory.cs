using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFCoreFundamentals
{
    //[NotMapped]//Tablo olarak oluşturulmasını istemiyorsak alternatif olarak attribute ekleyebiliriz
    //[Table("UrunKategori")] Tablo ismini bu şekilde manipüle edebiliriz
    public class ProductCategory //Birleşim Tablosu Çoka çok ilişki için
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
