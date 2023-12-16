using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсова_Пеньков_Егор_Игоревич_221_373.product
{
    internal abstract class Product // класс, который является базовым для всех товаров
    {
        protected string id=Guid.NewGuid().ToString();
        public string Id { get { return id; } }
        protected string name;
        public string Name { get { return name; } set { name = value; } }
        protected decimal price;
        public decimal Price { get { return price;} set { if (value >= 0) price = value; } }
        protected int quantity;
        public int Quantity { get { return quantity;} set { if(value>=0) quantity = value; } }
        protected string size;
        public abstract string Size { get; set; }
        protected string description;
        public string Description { get; set; }
        public Product(string name, decimal price,int quantity,string description) {
            this.name = name;
            this.price = price;
            this.quantity = quantity;
            this.description = description;
        }
    }
}
