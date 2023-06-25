using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetLib
{
    public class Manager
    {
        private MainConnector _connector;
        private DbExecutor _executor;
        private Table _userTable;
        public Manager()
        {
            _connector = new MainConnector();
            _userTable = new Table();
            _userTable.Name = "NetworkUser";
            _userTable.ImportantField = "Login";
            _userTable.Fields.Add("Id");
            _userTable.Fields.Add("Login");
            _userTable.Fields.Add("Name");
        }
        public void Connect()
        {
            if (_connector.ConnectAsync().Result)
            {
                Console.WriteLine("Подключено успешно!");
                _executor = new DbExecutor(_connector);
            }
            else
            {
                Console.WriteLine("Ошибка подключения!");
            }
        }

        public void ShowData()
        {
            var tablename = "NetworkUser";

            Console.WriteLine("Получаем данные таблицы " + tablename);

            //Метод, который заполняет наш объект data данными — всеми, которые есть в таблице.
            var data = _executor.SelectAll(tablename);

            Console.WriteLine("Количество строк в " + tablename + ": " + data.Rows.Count);

            Console.WriteLine();

            //выведем на экран данные по наименованиям колонок
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

            Console.WriteLine();
        }

        public void Disconnect()
        {
            Console.WriteLine("Отключаем БД!");
            _connector.DisconnectAsync();
        }

        public int DeleteUserByLogin(string value)
        {
            return _executor.DeleteByColumn(_userTable.Name, _userTable.ImportantField, value);
        }

        public void AddUser(string login, string name)
        {
            _executor.ExecProcedureAdding(name, login);
        }

        public int UpdateUserByLogin(string value, string newvalue)
        {
            return _executor.UpdateByColumn(_userTable.Name, _userTable.ImportantField, value, _userTable.Fields[2], newvalue);
        }

    }
}
