using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

///
///Создадим класс, описывающий объект таблицы пользователей. Зачем это нужно? 
///В дальнейшем представление данных в базе также будет храниться не в переменных, 
///а в специальных классах для установки конфигурации, потому лучше сразу привыкнуть к подобному. 
///
namespace AdoNetLib
{
    public class Table
    {
        public Table()
        {
            Fields = new List<string>();
        }
        public string Name { get; set; }

        public List<string> Fields { get; set; }

        public string ImportantField { get; set; }
    }
}
