using System;
using System.Collections.Generic;
using AutoLogistics;
using AutoLogistics.Models;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            //var communication = new Communication();
            //communication.Connect();
            //Console.WriteLine("Response: " + communication.Request(RequestTypes.GET));

            
            var item = new ItemModel
            {
                item_id = 0,
                name = "Sony WH-1000XM3",
                category_id = 0,
                place_id = 0,
                description = "Meine Bluetooth Kopfhörer",
                owner_id = 0,
                amount = 1,
                unit = null,
                addition = DateTime.Now,
                possession = DateTime.MinValue
            };
            var item1 = new ItemModel
            {
                item_id = 1,
                name = "Sony WH-C700N",
                category_id = 0,
                place_id = 0,
                description = "Meine alten Bluetooth Kopfhörer",
                owner_id = 0,
                amount = 1,
                unit = null,
                addition = DateTime.Now,
                possession = DateTime.MinValue
            };
            var category = new CategoryModel
            {
                category_id = 0,
                name = "Kopfhörer",
                addition = DateTime.Now
            };
            var owner = new OwnerModel()
            {
                owner_id = 0,
                name = "Moritz Kessler", 
                addition = DateTime.Now
            };
            var place = new PlaceModel()
            {
                place_id = 0,
                name = "Schreibtisch",
                description = "Mein Holzschreibtisch",
                owner_id = 0,
                addition = DateTime.Now,
                possession = DateTime.MinValue
            };

            Console.WriteLine("Created: ");
            Console.WriteLine("\t" + item);
            Console.WriteLine("\t" + category);
            Console.WriteLine("\t" + owner);
            Console.WriteLine("\t" + place);

            Data.Save(item);
            Data.Save(item1);
            Data.Save(category);
            Data.Save(owner);
            Data.Save(place);

            var items = Data.LoadItems();
            var categories = Data.LoadCategories();
            var owners = Data.LoadOwners();
            var places = Data.LoadPlaces();

            Console.WriteLine("Loaded: ");
            Console.WriteLine("\tItems: ");
            foreach (var _item in items)
            {
                Console.WriteLine("\t\t" + _item);
            }
            Console.WriteLine("\tCategories: ");
            foreach (var _category in categories)
            {
                Console.WriteLine("\t\t" + _category);
            }
            Console.WriteLine("\tOwners: ");
            foreach (var _owner in owners)
            {
                Console.WriteLine("\t\t" + _owner);
            }
            Console.WriteLine("\tPlaces: ");
            foreach (var _place in places)
            {
                Console.WriteLine("\t\t" + _place);
            }

            Console.WriteLine("Validation Tests for ItemModel Conversion:");
            Console.Write("\tEmpty String: ");
            Console.WriteLine(Data.ConvertTo.ItemModel("") == null
                ? "\n\t\tpassed"
                : "\n\t\tfailed");
            Console.Write("\tBad String: ");
            Console.WriteLine(Data.ConvertTo.ItemModel("This is\ue001 a test string ") == null
                ? "\n\t\tpassed"
                : "\n\t\tfailed"); ;
            Console.Write("\tReal String: ");
            Console.WriteLine(Data.ConvertTo.ItemModel(item.ToString()).ToString() == item.ToString()
                ? "\n\t\tpassed"
                : $"failed, result:\n\t\t{Data.ConvertTo.ItemModel(item.ToString())}");

            Console.WriteLine("Validation Tests for CategoryModel Conversion:");
            Console.Write("\tEmpty String: ");
            Console.WriteLine(Data.ConvertTo.CategoryModel("") == null
                ? "\n\t\tpassed"
                : "\n\t\tfailed");
            Console.Write("\tBad String: ");
            Console.WriteLine(Data.ConvertTo.CategoryModel("This is\ue001 a test string ") == null
                ? "\n\t\tpassed"
                : "\n\t\tfailed"); ;
            Console.Write("\tReal String: ");
            Console.WriteLine(Data.ConvertTo.CategoryModel(category.ToString()).ToString() == category.ToString()
                ? "\n\t\tpassed"
                : $"failed, result:\n\t\t{Data.ConvertTo.CategoryModel(category.ToString())}");

            Console.WriteLine("Validation Tests for OwnerModel Conversion:");
            Console.Write("\tEmpty String: ");
            Console.WriteLine(Data.ConvertTo.OwnerModel("") == null
                ? "\n\t\tpassed"
                : "\n\t\tfailed");
            Console.Write("\tBad String: ");
            Console.WriteLine(Data.ConvertTo.OwnerModel("This is\ue001 a test string ") == null
                ? "\n\t\tpassed"
                : "\n\t\tfailed"); ;
            Console.Write("\tReal String: ");
            Console.WriteLine(Data.ConvertTo.OwnerModel(owner.ToString()).ToString() == owner.ToString()
                ? "\n\t\tpassed"
                : $"failed, result:\n\t\t{Data.ConvertTo.OwnerModel(owner.ToString())}");

            Console.WriteLine("Validation Tests for PlaceModel Conversion:");
            Console.Write("\tEmpty String: ");
            Console.WriteLine(Data.ConvertTo.PlaceModel("") == null
                ? "\n\t\tpassed"
                : "\n\t\tfailed");
            Console.Write("\tBad String: ");
            Console.WriteLine(Data.ConvertTo.PlaceModel("This is\ue001 a test string ") == null
                ? "\n\t\tpassed"
                : "\n\t\tfailed"); ;
            Console.Write("\tReal String: ");
            Console.WriteLine(Data.ConvertTo.PlaceModel(place.ToString()).ToString() == place.ToString()
                ? "\n\t\tpassed"
                : $"failed, result:\n\t\t{Data.ConvertTo.PlaceModel(place.ToString())}");
            
            Console.WriteLine("Tests for ModelList.Search()");
            Console.Write("\tReal String: ");
            Console.WriteLine(items.Search("Sony")[0].ToString() == item.ToString() && items.Search("Sony")[1].ToString() == item1.ToString()
                ? "\n\t\tpassed"
                : $"failed, result:\n\t\t1 {items.Search("Sony")[0]}\n\t\t2 {items.Search("Sony")[1]}");
            Console.Read();
        }
    }
}
