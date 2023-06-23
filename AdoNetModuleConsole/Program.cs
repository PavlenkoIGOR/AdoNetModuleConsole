using AdoNetLib;
using AdoNetLib.Configurations;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using System.Data;
using System.Runtime.CompilerServices;

namespace AdoNetModuleConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager();

            manager.Connect();
            manager.ShowData();
            manager.Disconnect();







            MainConnector connector = new MainConnector();

            //подключаемся к базе
            var result = connector.ConnectAsync();

            //DataSet и DataTable нужны для работы с БД локально. DataSet для записи БД, DataTable для записи таблицы из DataSet.
            DataTable data = new DataTable();

            if (result.Result)
            {
                Console.WriteLine("Подключено успешно!");

                //Сначала мы создаем объект DbExecutor, а далее мы вызываем его метод, который заполняет наш
                //объект data данными — всеми, которые есть в таблице. 
                var db = new DbExecutor(connector);

                var tablename = "NetworkUser";

                Console.WriteLine("Получаем данные таблицы " + tablename);

                //Метод, который заполняет наш объект data данными — всеми, которые есть в таблице.
                data = db.SelectAll(tablename);

                Console.WriteLine("Количество строк в " + tablename + ": " + data.Rows.Count);

                //и после отключение от базы
                Console.WriteLine("Отключаем БД!");
                connector.DisconnectAsync();

                //снова подключаемся к базе
                result = connector.ConnectAsync();

                if (result.Result)
                {
                    Console.WriteLine("Количество строк в " + tablename + ": " + data.Rows.Count);
                }

            }
            else
            {
                Console.WriteLine("Ошибка подключения!");
            }

            //выведем на экран данные по наименованиям колонок:
            foreach (DataColumn column in data.Columns)
            {
                Console.Write($"{column.ColumnName}\t");
            }
            Console.WriteLine();
            //обратимся к коллекции строк и выведем все данные в этой строке на экран:
            foreach (DataRow row in data.Rows)
            {
                var cells = row.ItemArray;
                foreach (var cell in cells)
                {
                    Console.Write($"{cell}\t");
                }
                Console.WriteLine();
            }

            
            Console.ReadKey();
        }


    }
}