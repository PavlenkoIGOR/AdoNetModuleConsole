using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


///
///класс, который использует это подключение и работает с запросами в базу данных по разным принципам. 
///
namespace AdoNetLib
{
    public class DbExecutor
    {
        private MainConnector _connector;
        public DbExecutor(MainConnector connector)
        {
            _connector = connector;
        }

        //это универсальный метод выборки всех данных из любой таблицы вашей базы
        public DataTable SelectAll(string table) //принимает на вход имя таблицы
        {
            string selectcommandtext = $"select * from {table}";

            //SqlDataAdapter - объект для заполнения DataSet данными. Он является тем, что взаимодействует с базой данных,
            //именно через него выполняется подключение к базе данных и выполнение запроса в ней. 
            SqlDataAdapter adapter = new SqlDataAdapter(selectcommandtext, _connector.GetConnection());

            //DataSet - представляет хранилище или кэш данных в памяти, извлеченных из источника данных. Объект DataSet содержит таблицы,
            //которые представлены типом DataTable.Таблица DataTable, в свою очередь, состоит из столбцов и строк. Каждый столбец
            //представляет объект DataColumn, а строка — объект DataRow.
            DataSet ds = new DataSet();

            //Метод заполнения DataAdapter — это метод Fill. В качестве параметра ему передается DataSet. 
            adapter.Fill(ds);

            //Вернём первый элемент коллекции таблиц DataSet:
            return ds.Tables[0];
        }
    }
}
