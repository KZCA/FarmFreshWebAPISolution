using FarmFresh.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmFresh.DataAccess.Data
{
    public class SeedData
    {
        public static void SeedDataBase(ApplicationDBContext dbContext)
        {
            dbContext.Database.Migrate();

            if (dbContext.Products.Count()==0)
            {
                Category fruits = new Category { Name = "Fruit and Veg", Slug = "fruits" };
                Category meat = new Category { Name = "Meat & Seafood", Slug = "meat" };
                Category dairy = new Category { Name = "Dairy and Chilled", Slug = "dairy" };
                Category bakery = new Category { Name = "Bakery", Slug = "bakery" };
                Category beverage = new Category { Name = "Beverages", Slug = "beverage" };

                dbContext.Products.AddRange(
                    new Product
                    {
                        Name = "Ripe Blue Grape",
                        Slug = "ripe blue grape",
                        Description = "From the heart of the french Alps after a journey of more\r\nthan 70 years, springs this Ripe Blue Grapes. Thanks to\r\nthis amazing journey through the Chambotte mountains,\r\nit acquires its unique fresgqualities. With our passion for\r\npreserving this natural heritage, we are proud to offer you\r\nthis moment of purity in your busy lives.",
                        Category = fruits,
                        Image = "grape.jpg"
                    },
                    new Product
                    {
                        Name = "Spinach",
                        Slug = "spinach",
                        Description = "From the heart of the french Alps after a journey of more\r\nthan 70 years, springs this Ripe Blue Grapes. Thanks to\r\nthis amazing journey through the Chambotte mountains,\r\nit acquires its unique fresgqualities. With our passion for\r\npreserving this natural heritage, we are proud to offer you\r\nthis moment of purity in your busy lives.",
                        Category = fruits,
                        Image = "spinach.jpg"
                    },
                    new Product
                    {
                        Name = "Salmon",
                        Slug = "salmon",
                        Description = "From the heart of the french Alps after a journey of more\r\nthan 70 years, springs this Ripe Blue Grapes. Thanks to\r\nthis amazing journey through the Chambotte mountains,\r\nit acquires its unique fresgqualities. With our passion for\r\npreserving this natural heritage, we are proud to offer you\r\nthis moment of purity in your busy lives.",
                        Category = meat,
                        Image = "salmon.jpg"
                    },
                    new Product
                    {
                        Name = "Capsicum",
                        Slug = "capsicum",
                        Description = "From the heart of the french Alps after a journey of more\r\nthan 70 years, springs this Ripe Blue Grapes. Thanks to\r\nthis amazing journey through the Chambotte mountains,\r\nit acquires its unique fresgqualities. With our passion for\r\npreserving this natural heritage, we are proud to offer you\r\nthis moment of purity in your busy lives.",
                        Category = fruits,
                        Image = "capsicum.jpg"
                    },
                    new Product
                    {
                        Name = "Tomato",
                        Slug = "tomato",
                        Description = "From the heart of the french Alps after a journey of more\r\nthan 70 years, springs this Ripe Blue Grapes. Thanks to\r\nthis amazing journey through the Chambotte mountains,\r\nit acquires its unique fresgqualities. With our passion for\r\npreserving this natural heritage, we are proud to offer you\r\nthis moment of purity in your busy lives.",
                        Category = fruits,
                        Image = "tomato.jpg"
                    },
                    new Product
                    {
                        Name = "Broccoli",
                        Slug = "broccoli",
                        Description = "From the heart of the french Alps after a journey of more\r\nthan 70 years, springs this Ripe Blue Grapes. Thanks to\r\nthis amazing journey through the Chambotte mountains,\r\nit acquires its unique fresgqualities. With our passion for\r\npreserving this natural heritage, we are proud to offer you\r\nthis moment of purity in your busy lives.",
                        Category = fruits,
                        Image = "broccoli.jpg"
                    }
                    );

                dbContext.SaveChanges();
            }
        }
    }
}
