using AdoNetLib;
using AdoNetLib.Configurations;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Runtime.CompilerServices;

namespace AdoNetModuleConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //MainConnector connector = new MainConnector();

            //var result = connector.ConnectAsync();

            //DataTable data = new DataTable();

            //if (result.Result)
            //{
            //    Console.WriteLine("Подключено успешно!");

            //    //Сначала мы создаем объект DbExecutor, а далее мы вызываем его метод, который заполняет наш
            //    //объект data данными — всеми, которые есть в таблице. 
            //    var db = new DbExecutor(connector);

            //    var tablename = "NetworkUser";

            //    Console.WriteLine("Получаем данные таблицы " + tablename);

            //    //Метод, который заполняет наш объект data данными — всеми, которые есть в таблице.
            //    data = db.SelectAll(tablename);

            //    Console.WriteLine("Количество строк в " + tablename + ": " + data.Rows.Count);

            //    //и после отключение от базы
            //    Console.WriteLine("Отключаем БД!");
            //    connector.DisconnectAsync();

            //    result = connector.ConnectAsync();

            //    if (result.Result)
            //    {
            //        Console.WriteLine("Количество строк в " + tablename + ": " + data.Rows.Count);
            //    }

            //}
            //else
            //{
            //    Console.WriteLine("Ошибка подключения!");
            //}
            var connector = new MainConnector();

            var result = connector.ConnectAsync();

            if (result.Result)
            {
                Console.WriteLine("Подключено успешно!");
            }
            else
            {
                Console.WriteLine("Ошибка подключения!");
            }


            Console.ReadKey();
        }

    }
}