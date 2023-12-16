using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсова_Пеньков_Егор_Игоревич_221_373.Repos
{
    internal class Repository<T>// базовый класс для всех репозиториев
    {
        protected List<T> items=new List<T>();
        public List<T> Items { get { return items; }  }
    }
}
