using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Курсова_Пеньков_Егор_Игоревич_221_373.product
{
    internal class productSneakers:Product // класс, который представляет из себя кроссовки
    {
        public override string Size { get { return size; } set { if (Regex.IsMatch(value, @"^[0-9]+$")) size = value; else { Console.WriteLine("Неправильный размер"); } } }
        public productSneakers(string name, decimal price, int quantity, string size, string description) : base(name, price, quantity,description) { this.Size = size; }

    }
}
