using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Курсова_Пеньков_Егор_Игоревич_221_373.product;
using Курсова_Пеньков_Егор_Игоревич_221_373.Users;

namespace Курсова_Пеньков_Егор_Игоревич_221_373.ShoppingProcces
{
    internal class Order// этот класс представляет из себя лист с товарами или заказ
    {
        private List<Product> products= new List<Product>();
        public List<Product> Products { get { return products; } set { products = value; } }
        private string id=Guid.NewGuid().ToString();
        public string Id { get { return id; } }
        private string customer_id;
        public string CustomerId { get { return customer_id; } set { customer_id = value; } }
        private string deliveryman_id;
        public string DeliverymanId { get { return deliveryman_id; } set { deliveryman_id = value; } }
        private DateOnly date;
        public DateOnly Date { get { return date; } set { date = value; } }
        private string address;
        public string Address { get { return address; } set{address = value;} }
        private decimal pricesum=0;
        public decimal Pricesum { get { return pricesum; } }
        public Order( string customer_id, string address)
        {
            this.customer_id = customer_id;
            Address = address;
        }
        public void GetInfo()//выводит информацию о заказе
        {
            Console.WriteLine($"Id: {id} \t Customer id: {customer_id} \t Delivery man id: {deliveryman_id} \t Date: {date}");
            Console.WriteLine($"Address: {address} \t Сумма заказа: {Pricesum}");
        }
        public void GetInfoCUstomer()//выводит информацию о заказе для покупателя
        {
            Console.WriteLine($"Ваш заказ: ");
            for(int i = 0; i < products.Count(); i++)
            {
                Console.WriteLine($"Наименование позиции : {products[i].Name} \t Цена: {products[i].Price}");
            }
            Console.WriteLine($"Адрес: {address} \t Сумма заказа: {Pricesum} \t Дата доставки: {date}" );
        }
        public void AddProduct(Product product) { if(product.Quantity>0) products.Add(product); product.Quantity = product.Quantity - 1; pricesum = pricesum + product.Price; }// добавление товара в заказ
        public void AddProductwithoutdecr(Product product) { products.Add(product); pricesum = pricesum + product.Price; }// добавление товара в заказ без уменьшения его количества на складе
        public void RemoveProductbyid(string id)//удаление товара по id
        {
            for (int k = 0; k < products.Count; k++)
            {
                if (products[k].Id == id)
                {
                    pricesum-= products[k].Price;
                    products[k].Quantity = products[k].Quantity + 1;
                    products.RemoveAt(k);

                }
            }
        }
        public void RemoveProductbyind(int ind)//удаление товара по индексу в заказе
        {
            try
            {
                pricesum-= products[ind].Price;
                products[ind].Quantity = products[ind].Quantity + 1;
                products.RemoveAt(ind);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void RemoveProductbyindwithoutencr(int ind)//удаление товара по id в заказе без увеличения количества товара на складе
        {
            try
            {
                pricesum-= products[ind].Price;
                products.RemoveAt(ind);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void RemoveAll()// удалить все товары из заказа
        {
            int k=products.Count;
            for(int i=k-1; i>-1; i--)
            {
                products[i].Quantity = products[i].Quantity + 1;
                products.RemoveAt(i);
            }
            pricesum= 0;
        }
        public void RemoveAllwithoutencr()// удалить все товары из заказа без увеличения количества этих товаров на складе
        {
            int k = products.Count;
            for (int i = k - 1; i > -1; i--)
            {
                products.RemoveAt(i);
            }
            pricesum = 0;
        }
    }
}
