using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreFundamentals
{
    public class ProductCategory //Birleşim Tablosu Çoka çok ilişki için
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
