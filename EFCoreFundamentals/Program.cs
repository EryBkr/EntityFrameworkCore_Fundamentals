using System;
using System.Collections.Generic;
using System.Linq;

namespace EFCoreFundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
           
            GetProducts();
            Console.WriteLine("------------");
            GetProductById(2);
            GetProductByName("MSI");
            GetProductByPrice();
            UpdateProduct();
            DeleteProduct(1);

        }
        //ADD
        public static void AddProducts()
        {
            using (var db = new ExampleContext()) //EKLEME ISLEMI
            {
                var product = new Product { Name = "Bosh", Price = 5000 };
                db.Products.Add(product);//Database Ekliyoruz
                db.SaveChanges();//değişiklikler database'e ekleniyor

                //Çoklu ekleme işlemi
                var products = new List<Product>
                {
                     new Product { Name = "Lenovo Laptop", Price = 6000 },
                     new Product { Name = "Iphone S5", Price = 3000 }
                };
                db.Products.AddRange(products);//Çoklu Ekleme
                db.SaveChanges();//Kaydetme işlei
                Console.WriteLine("Eklendiler");
            }
        }
        //ADD

        //GET
        public static void GetProducts()
        {
            using (var db = new ExampleContext()) //SEÇME ISLEMI
            {
                var products = db.Products.Select(i=>i.Name).ToList();//Select Sorgusunu çalıştırır
                foreach (var item in products )
                {
                    Console.WriteLine(item);
                }
            }
        }

        public static void GetProductById(int id)
        {
            using (var db = new ExampleContext()) //Id e göre SEÇME ISLEMI
            {
                var product = db.Products.Where(i=>i.Id==id).Select(i => i.Name).FirstOrDefault();//Select ve Where Sorgusunu çalıştırır
                Console.WriteLine(product);
            }
        }

        public static void GetProductByName(string name)
        {
            using (var db = new ExampleContext()) //Urun adına a göre SEÇME ISLEMI
            {
                var product = db.Products.Where(i=>i.Name.Contains(name)).Select(i => i.Name).FirstOrDefault();//Select ve Where Sorgusunu çalıştırır
                Console.WriteLine(product);
            }
        }

        public static void GetProductByPrice()
        {
            using (var db = new ExampleContext()) //Fiyat aralığına  göre SEÇME ISLEMI
            {
                var product = db.Products.Where(i => i.Price>1000 && i.Price<5000).Select(i => i.Name).FirstOrDefault();//Select ve Where Sorgusunu çalıştırır
                Console.WriteLine(product);
            }
        }
        //GET

        //UPDATE
        public static void UpdateProduct()
        {
            using (var db = new ExampleContext()) //UPDATE ISLEMI
            {
                var product = db.Products.Where(i=>i.Id==1).FirstOrDefault();
                if (product!=null)
                {
                    product.Name = "Yeni Urun";
                    db.Products.Update(product);
                    db.SaveChanges();
                    Console.WriteLine("Urun guncellendi");
                }
            }
        }
        //UPDATE

        //DELETE
        public static void DeleteProduct(int id)
        {
            using (var db = new ExampleContext()) //DELETE ISLEMI
            {
                var product = db.Products.Where(i => i.Id == id).FirstOrDefault();
                if (product != null)
                {
                    product.Name = "Yeni Urun";
                    db.Products.Remove(product);
                    db.SaveChanges();
                    Console.WriteLine("Urun Silindi");
                }
            }
        }
        //DELETE
    }
}
