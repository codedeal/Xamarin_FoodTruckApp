using System;
using System.IO;
using FoodTruck.iOS.Persistence;
using FoodTruck.Persistence;
using SQLite;
using Xamarin.Forms;
//dependency attribute to do registration with depency service

[assembly: Dependency(typeof(SQLiteDB))]
namespace FoodTruck.iOS.Persistence
{
    public class SQLiteDB:ISQLite
    {
        public SQLiteDB()
        {
        }

        public SQLiteAsyncConnection GetConnection()
        {

            var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); //document folder
            Console.WriteLine("document Path is" + documentPath);
            var path = Path.Combine(documentPath, "FoodTruck.db3"); //name of database;
            Console.WriteLine("Whole PAth " + path);
            return new SQLiteAsyncConnection(path);
        }
    }
}
