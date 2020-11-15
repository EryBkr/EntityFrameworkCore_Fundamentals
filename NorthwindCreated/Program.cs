using Microsoft.EntityFrameworkCore;
using NorthwindCreated.Entities;
using NorthwindCreated.Models;
using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace NorthwindCreated
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new NorthwindContext())
            {
                //Tüm Müşteri Kayıtları
                GetAllCustomers(db);

                //Musteri kayıtlarından sadece Country Kısmını alalım
                GetCustomersCountry(db);

                //USA da bulunan musterileri company sırasına göre getirelim
                GetCustomersUSA(db);

                //Beverages kategorisine ait ürünleri getirelim
                GetCategoryBeverages(db);

                //En Son Eklenen 5 ürün
                GetLastFiveProducts(db);

                //Fiyatı 10 ile 30 arasında olan ürünler
                GetPrice(db);

                //Beverages kategorisine ait ürünlerin ortalama fiyatı
                GetBevaresAvarage(db);

                //Beverages kategorisine ait kaç ürün vardır
                GetBevaresAvarage(db);

                //Beverages ve Condiments kategorilerini ait ürünlerin toplam fiyatı
                GetTotalPrice(db);

                //Tea kelimesini içeren ürünleri getirelim
                GetContaineTea(db);

                //En Pahalı ürün ve en Ucuz ürün
                GetExpensiveProduct(db);

                //Musterinin Sipariş Sayısı
                GetCustomersOrdersCount(db);
            }


        }

        //Tüm Müşteri Kayıtları
        public static void GetAllCustomers(NorthwindContext db)
        {

            var customer = db.Customers.ToList();
            foreach (var item in customer)
            {
                Console.WriteLine("Company Name: " + item.CompanyName);
            }
            Console.WriteLine("----------------------------------------------------------------");
        }

        //Musteri kayıtlarından sadece Country Kısmını alalım
        public static void GetCustomersCountry(NorthwindContext db)
        {
            var customer_Country = db.Customers.Select(i => i.Country).ToList();
            foreach (var item in customer_Country)
            {
                Console.WriteLine("Country: " + item);
            }
            Console.WriteLine("----------------------------------------------------------------");
        }

        //USA da bulunan musterileri company sırasına göre getirelim
        public static void GetCustomersUSA(NorthwindContext db)
        {
            var customer_Usa = db.Customers.Where(i => i.Country.ToLower() == "usa").OrderBy(i => i.CompanyName).ToList();
            foreach (var item in customer_Usa)
            {
                Console.WriteLine("Country:" + item.Country + " Company Name:" + item.CompanyName);
            }
            Console.WriteLine("----------------------------------------------------------------");
        }

        //Beverages kategorisine ait ürünleri getirelim
        public static void GetCategoryBeverages(NorthwindContext db)
        {
            var products = db.Products.Select(i => new { i.Category, i.ProductName }).Where(i => i.Category.CategoryName == "Beverages").ToList();
            foreach (var item in products)
            {
                Console.WriteLine("Kategori:" + item.Category.CategoryName + " Product Name:" + item.ProductName);
            }
            Console.WriteLine("----------------------------------------------------------------");
        }

        //En Son Eklenen 5 ürün
        public static void GetLastFiveProducts(NorthwindContext db)
        {
            var products_Last = db.Products.OrderByDescending(i => i.ProductId).Take(5);
            foreach (var item in products_Last)
            {
                Console.WriteLine("Last Product: " + item.ProductName);
            }
            Console.WriteLine("----------------------------------------------------------------");
        }

        //Fiyatı 10 ile 30 arasında olan ürünler
        public static void GetPrice(NorthwindContext db)
        {
            var products_price = db.Products.Where(i => i.UnitPrice > 10 && i.UnitPrice <= 30).ToList();
            foreach (var item in products_price)
            {
                Console.WriteLine("Name:" + item.ProductName + " Price:" + item.UnitPrice);
            }
            Console.WriteLine("----------------------------------------------------------------");
        }

        //Beverages kategorisine ait ürünlerin ortalama fiyatı
        public static void GetBevaresAvarage(NorthwindContext db)
        {
            var ortalama = db.Products.Select(i => new { i.Category, i.UnitPrice }).Where(i => i.Category.CategoryName == "Beverages").Average(i => i.UnitPrice);
            Console.WriteLine("Ortalama: " + ortalama);
            Console.WriteLine("----------------------------------------------------------------");
        }

        //Beverages kategorisine ait kaç ürün vardır
        public static void GetBevaresProductsCount(NorthwindContext db)
        {
            var count = db.Products.Select(i => i.Category.CategoryName).Where(i => i == "Beverages").Count();
            Console.WriteLine("Count:" + count);
            Console.WriteLine("----------------------------------------------------------------");
        }

        //Beverages ve Condiments kategorilerini ait ürünlerin toplam fiyatı
        public static void GetTotalPrice(NorthwindContext db)
        {
            var totalPrice = db.Products.Select(i => new { i.Category.CategoryName, i.UnitPrice }).Where(i => i.CategoryName == "Beverages" || i.CategoryName == "Condiments").Sum(i => i.UnitPrice);
            Console.WriteLine("Total Price: " + totalPrice);
            Console.WriteLine("----------------------------------------------------------------");
        }

        //Tea kelimesini içeren ürünleri getirelim
        public static void GetContaineTea(NorthwindContext db)
        {
            var teaProducts = db.Products.Where(i => i.ProductName.ToLower().Contains("tea")).ToList();
            foreach (var item in teaProducts)
            {
                Console.WriteLine("Tea Name:" + item.ProductName);
            }
            Console.WriteLine("----------------------------------------------------------------");
        }

        //En Pahalı ürün ve en Ucuz ürün
        public static void GetExpensiveProduct(NorthwindContext db)
        {
            var ExpensiveProduct = db.Products.OrderByDescending(i => i.UnitPrice).FirstOrDefault();
            var cheepProduct = db.Products.OrderBy(i => i.UnitPrice).FirstOrDefault();
            Console.WriteLine($"Ucuz ürün ismi {cheepProduct.ProductName} ve Fiyatı {cheepProduct.UnitPrice} ve En Pahalı Ürün {ExpensiveProduct.ProductName} Fiyatı {ExpensiveProduct.UnitPrice}");
            Console.WriteLine("----------------------------------------------------------------");
        }

        //Musterinin Sipariş Sayıları
        public static void GetCustomersOrdersCount(NorthwindContext db)
        {
            var customers = db.Customers.Where(i => i.Orders.Any()).Select(i => new CustomerDemo
            {
                CompanyName = i.CompanyName,
                OrderCount = i.Orders.Count(),
                OrdersDemo=i.Orders.Select(a=>new OrdersDemo 
                {
                    OrderId=a.OrderId,
                    TotalPrice=a.OrderDetails.Sum(od=>od.UnitPrice*od.Quantity),
                    ProductDemos=a.OrderDetails.Select(p=>new ProductDemo {ProductName=p.Product.ProductName }).ToList()
                }).ToList()
            }).ToList();

            foreach (var item in customers)
            {
                Console.WriteLine(item.CompanyName+" Sipariş Sayısı: "+item.OrderCount+" Toplam Fiyat:"+item.OrdersDemo.Sum(i=>i.TotalPrice));
                foreach (var order in item.OrdersDemo)
                {
                    foreach (var product in order.ProductDemos)
                    {
                        Console.WriteLine("Product Name: "+product.ProductName);
                    }
                }
            }

            Console.WriteLine("----------------------------------------------------------------");
        }
    }
}
