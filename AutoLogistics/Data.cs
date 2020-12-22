using AutoLogistics.Models;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace AutoLogistics
{
    public class Data
    {
        #region Loading
        private static string LoadConnectionString(string id = "Default")
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        public static List<ItemModel> LoadItems()
        {
            return LoadTable<ItemModel>("items");
        }

        public static List<PlaceModel> LoadPlaces()
        {
            return LoadTable<PlaceModel>("places");
        }

        public static List<OwnerModel> LoadOwners()
        {
            return LoadTable<OwnerModel>("owners");
        }

        public static List<CategoryModel> LoadCategories()
        {
            return LoadTable<CategoryModel>("categories");
        }

        private static List<T> LoadTable<T>(string table)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<T>("select * from " + table, new DynamicParameters());
                return output.ToList();
            }
        }
        #endregion

        #region Saving
        public static void SaveItem(ItemModel item)
        {
            SaveData("items",
                new[]
                {
                    "item_id",
                    "name",
                    "category_id",
                    "place_id",
                    "description",
                    "place_id",
                    "description",
                    "owner_id",
                    "amount",
                    "unit",
                    "addition",
                    "possession"
                }, item);
        }

        public static void SavePlace(PlaceModel place)
        {
            SaveData("places",
                new []
                {
                    "place_id",
                    "name",
                    "description",
                    "owner_id",
                    "addition",
                    "possession"
                }, place);
        }

        public static void SaveOwner(OwnerModel owner)
        {
            SaveData("owners",
                new[]
                {
                    "owner_id",
                    "name",
                    "addition",
                    "possession"
                }, owner);
        }

        public static void SaveCategory(CategoryModel category)
        {
            SaveData("categories",
                new[]
                {
                    "category_id",
                    "name",
                    "addition"
                }, category);
        }
        public static void SaveData<T>(string table, string[] columns, T data)
        {
            string _columns = "";
            foreach (var column in columns)
            {
                _columns += $"{column}, ";
            }

            _columns = _columns.Substring(0, _columns.Length - 2);

            string _values = "";
            foreach (var value in columns)
            {
                _values += $"@{value}, ";
            }

            _values = _values.Substring(0, _values.Length - 2);

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var sql = $"insert into {table} ({_columns}) values ({_values})";
                cnn.Execute(sql, data);
            }
        }
        #endregion
    }
}