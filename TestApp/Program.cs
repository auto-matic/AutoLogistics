using System;
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

            var i = new ItemModel
            {
                item_id = 0,
                name = "Sony WH-C700N",
                category_id = 0,
                place_id = 0,
                description = "Meine Bluetooth Kopfhörer",
                owner_id = 0,
                amount = 1,
                unit = null,
                addition = DateTime.Now,
                possession = DateTime.MinValue
            };
            Data.SaveItem(i);
            var items = Data.LoadItems();
            foreach (var item in items)
            {
                Console.WriteLine(item.name);
            }

            Console.Read();
        }
    }
}
