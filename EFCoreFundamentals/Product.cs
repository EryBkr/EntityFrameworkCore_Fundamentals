using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFCoreFundamentals
{
    public class Product
    {
        //Primary Key , Id yazdığımız için birincil anahtar olarak tanımlanır
        public int Id { get; set; }

        [MaxLength(100)]//Max karakter sayısı 100
        [Required]//Zorunlu olarak tanımladık
        public string Name { get; set; }
        public decimal Price { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }//Çoka çok ilişki

    }
}
