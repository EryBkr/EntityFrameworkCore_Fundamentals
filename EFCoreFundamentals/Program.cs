using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace EFCoreFundamentals
{
    class Program
    {
        static void Main(string[] args)
        {

            //GetProducts();
            //Console.WriteLine("------------");
            //GetProductById(2);
            //GetProductByName("MSI");
            //GetProductByPrice();
            //UpdateProduct();
            //DeleteProduct(1);
            //AddUsers();
            //AddAddress();
            //AddAddressToUser();
            //AddCustomer();
            //AddUserAndCustomer();
            AddProductCategory();

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

        public static void AddUsers()
        {
            var users = new List<User>()
            {
                new User{Name="Eray",Email="eray.mail"},
                new User{Name="Berkay",Email="berkay.mail"},
            };
            using (var db = new ExampleContext())
            {
                db.Users.AddRange(users);
                db.SaveChanges();
            }
        }

        public static void AddAddress()
        {
            var address = new List<Address>()
            {
                new Address{FullName="Eray",Title="Ev",Body="IST",UserId=1},
                new Address{FullName="Eray",Title="İş",Body="USA",UserId=1},
                new Address{FullName="Berkay",Title="Ev",Body="IST",UserId=2},
                new Address{FullName="Berkay",Title="İş",Body="UK",UserId=2}
            };
            using (var db = new ExampleContext())
            {
                db.Addresses.AddRange(address);
                db.SaveChanges();
            }
        }

        public static void AddAddressToUser()
        {
            using (var db = new ExampleContext())//belli bir kullanıcıya adres ekledik
            {
                var user = db.Users.Where(i => i.Id == 1).FirstOrDefault();
                user.Addresses.Add(new Address { FullName = "Eray V2", Title = "Funny", Body = "B.Çekmece" });
                db.SaveChanges();
            }
        }

        public static void AddCustomer()
        {
            var customer = new Customer { FirstName = "Eray", UserId = 1, IdentityNumber = "5555555", LastName = "Bakır" };
            using (var db = new ExampleContext())//belli bir kullanıcıya müsteri rolü eklendi
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                Console.WriteLine("Customer Kaydedildi");
            }
        }

        public static void AddUserAndCustomer()
        {
            var user = new User { Name = "John", Email = "john@mail", Customer = new Customer { FirstName = "John", IdentityNumber = "4444", LastName = "Cames" } };
            using (var db = new ExampleContext()) //musteri ile kullanıcı aynı anda eklendi
            {
                db.Users.Add(user);
                db.SaveChanges();
                Console.WriteLine("Eklendi");
            }
        }

        public static void AddProductCategory()
        {
            //var products = new List<Product>()
            //{
            //    new Product{Name="Samsung S5", Price=2000},
            //    new Product{Name="Samsung S6", Price=3000},
            //    new Product{Name="Samsung S7", Price=4000}
            //};

            //var categories = new List<Category>()
            //{
            //    new Category{Name="Teknoloji"},
            //    new Category{Name="Cep Telefonu"}
            //};
           
            using (var db = new ExampleContext())
            {
                //db.Products.AddRange(products);
                //db.Categories.AddRange(categories);
                //db.SaveChanges();
                var Ids = new int[] { 1, 2 };
                var product = db.Products.Find(2);//Id bilgisi veriliyor
                product.ProductCategories = Ids.Select(i => new ProductCategory() //Category Id lerini Product Entity si içerisinde ProductCategory Listesine aktardık
                {
                    CategoryId=i,
                    ProductId=product.Id
                }).ToList();
                db.SaveChanges();
                Console.WriteLine("Kaydedildi");
            }
        }

        //ADD

        //GET
        public static void GetProducts()
        {
            using (var db = new ExampleContext()) //SEÇME ISLEMI
            {
                var products = db.Products.Select(i => i.Name).ToList();//Select Sorgusunu çalıştırır
                foreach (var item in products)
                {
                    Console.WriteLine(item);
                }
            }
        }

        public static void GetProductById(int id)
        {
            using (var db = new ExampleContext()) //Id e göre SEÇME ISLEMI
            {
                var product = db.Products.Where(i => i.Id == id).Select(i => i.Name).FirstOrDefault();//Select ve Where Sorgusunu çalıştırır
                Console.WriteLine(product);
            }
        }

        public static void GetProductByName(string name)
        {
            using (var db = new ExampleContext()) //Urun adına a göre SEÇME ISLEMI
            {
                var product = db.Products.Where(i => i.Name.Contains(name)).Select(i => i.Name).FirstOrDefault();//Select ve Where Sorgusunu çalıştırır
                Console.WriteLine(product);
            }
        }

        public static void GetProductByPrice()
        {
            using (var db = new ExampleContext()) //Fiyat aralığına  göre SEÇME ISLEMI
            {
                var product = db.Products.Where(i => i.Price > 1000 && i.Price < 5000).Select(i => i.Name).FirstOrDefault();//Select ve Where Sorgusunu çalıştırır
                Console.WriteLine(product);
            }
        }
        //GET

        //UPDATE
        public static void UpdateProduct()
        {
            using (var db = new ExampleContext()) //UPDATE ISLEMI
            {
                var product = db.Products.Where(i => i.Id == 1).FirstOrDefault();
                if (product != null)
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
