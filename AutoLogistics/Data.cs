using AutoLogistics.Models;
using Dapper;
using System;
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

        public static ModelList LoadItems()
        {
            var loaded = LoadTable<ItemModel>("items");
            var table = new ModelList();
            foreach (var model in loaded)
            {
                table.Add(model);
            }
            return table;
        }

        public static ModelList LoadPlaces()
        {
            var loaded = LoadTable<PlaceModel>("places");
            var table = new ModelList();
            foreach (var model in loaded)
            {
                table.Add(model);
            }
            return table;
        }

        public static ModelList LoadOwners()
        {
            var loaded = LoadTable<OwnerModel>("owners");
            var table = new ModelList();
            foreach (var model in loaded)
            {
                table.Add(model);
            }
            return table;
        }

        public static ModelList LoadCategories()
        {
            var loaded = LoadTable<CategoryModel>("categories");
            var table = new ModelList();
            foreach (var model in loaded)
            {
                table.Add(model);
            }
            return table;
        }

        private static List<T> LoadTable<T>(string table)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<T>("select * from " + table, new DynamicParameters());
                return output.ToList();
            }
        }

        #endregion Loading

        #region Saving

        public static void Save(ItemModel item)
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

        public static void Save(PlaceModel place)
        {
            SaveData("places",
                new[]
                {
                    "place_id",
                    "name",
                    "description",
                    "owner_id",
                    "addition",
                    "possession"
                }, place);
        }

        public static void Save(OwnerModel owner)
        {
            SaveData("owners",
                new[]
                {
                    "owner_id",
                    "name",
                    "addition",
                }, owner);
        }

        public static void Save(CategoryModel category)
        {
            SaveData("categories",
                new[]
                {
                    "category_id",
                    "name",
                    "addition"
                }, category);
        }

        private static void SaveData<T>(string table, string[] columns, T data)
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

        #endregion Saving

        #region Conversion

        public static class ConvertTo
        {
            public static ItemModel ItemModel(string model)
            {
                var split = model.Split('\ue001');
#if DEBUG

                Console.Write("\n\t\t\"");
                foreach (var str in split)
                {
                    Console.Write(str + ", ");
                }
                Console.Write("\"");

#endif
                ItemModel _model = null;
                if (split.Length != 10) return null;
                try
                {
                    _model = new ItemModel
                    {
                        item_id = Convert.ToInt32(split[0]),
                        name = split[1],
                        category_id = Convert.ToInt32(split[2]),
                        place_id = Convert.ToInt32(split[3]),
                        description = split[4],
                        owner_id = Convert.ToInt32(split[5]),
                        amount = Convert.ToInt32(split[6]),
                        unit = split[7],
                        addition = DateTime.Parse(split[8]),
                        possession = DateTime.Parse(split[9])
                    };
                }
                catch (Exception e)
                {
                    return null;
                }

                return _model;
            }

            public static CategoryModel CategoryModel(string model)
            {
                var split = model.Split('\ue001');
#if DEBUG
                Console.Write("\n\t\t\"");
                foreach (var str in split)
                {
                    Console.Write(str + ", ");
                }
                Console.Write("\"");
#endif
                CategoryModel _model = null;
                if (split.Length != 3) return null;
                try
                {
                    _model = new CategoryModel
                    {
                        category_id = Convert.ToInt32(split[0]),
                        name = split[1],
                        addition = DateTime.Parse(split[2])
                    };
                }
                catch (Exception e)
                {
                    return null;
                }

                return _model;
            }

            public static OwnerModel OwnerModel(string model)
            {
                var split = model.Split('\ue001');
#if DEBUG
                Console.Write("\n\t\t\"");
                foreach (var str in split)
                {
                    Console.Write(str + ", ");
                }
                Console.Write("\"");
#endif
                OwnerModel _model = null;

                if (split.Length != 3) return null;
                try
                {
                    _model = new OwnerModel
                    {
                        owner_id = Convert.ToInt32(split[0]),
                        name = split[1],
                        addition = DateTime.Parse(split[2])
                    };
                }
                catch (Exception e)
                {
                    return null;
                }

                return _model;
            }

            public static PlaceModel PlaceModel(string model)
            {
                var split = model.Split('\ue001');
#if DEBUG
                Console.Write("\n\t\t\"");
                foreach (var str in split)
                {
                    Console.Write(str + ", ");
                }
                Console.Write("\"");
#endif
                PlaceModel _model = null;

                if (split.Length != 6) return null;
                try
                {
                    _model = new PlaceModel
                    {
                        place_id = Convert.ToInt32(split[0]),
                        name = split[1],
                        description = split[2],
                        owner_id = Convert.ToInt32(split[3]),
                        addition = DateTime.Parse(split[4]),
                        possession = DateTime.Parse(split[5])
                    };
                }
                catch (Exception e)
                {
                    return null;
                }

                return _model;
            }
        }

        #endregion Conversion

        #region Search
        #endregion
    }
}