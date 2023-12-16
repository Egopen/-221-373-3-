using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Курсова_Пеньков_Егор_Игоревич_221_373.product
{
    internal class productTshirt:Product// класс который представляет из себя футболки
    {
        public override string Size { get { return size; } set { if (Regex.IsMatch(value, @"^[a-zA-Z]+$")) size = value; else{ Console.WriteLine("Неправильный размер"); } } }
        public productTshirt(string name, decimal price, int quantity, string size, string description):base (name, price, quantity, description) { this.Size = size; }      
    }
}
