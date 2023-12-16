using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Курсова_Пеньков_Егор_Игоревич_221_373.product;
using Курсова_Пеньков_Егор_Игоревич_221_373.Repos;
using Курсова_Пеньков_Егор_Игоревич_221_373.ShoppingProcces;

namespace Курсова_Пеньков_Егор_Игоревич_221_373.Users
{
    internal class userCustomer:User// этот класс представляет из себя клиента
    {
        List<Order> customerorders=new List<Order>();
        private string deliveryaddress;
        public string Deliveryaddress { get { return deliveryaddress; } set { deliveryaddress = value; } }
        public override void SuccesMessege()// выводит сообщение об успешном входе
        {
            Console.WriteLine($"Здравствуйте, {Name}, вы успешно зашли");
        }
        public override void GetJob()// возвращает роль пользователя
        {
            Console.Write("Customer");
        }
        public userCustomer(string name, string email,string password,string deliveryaddress):base(name,email, password)
        {
            this.deliveryaddress = deliveryaddress;
        }
        public void BuyProduct(Product product)// имитирует покупку товара
        {
            customerorders[customerorders.Count()-1].AddProductwithoutdecr(product);
        }
        public void RemoveProductByInd(int ind)// удаление товара из текущего заказа по индексу
        {
            customerorders[customerorders.Count() - 1].RemoveProductbyindwithoutencr(ind);
        }
        public void CreateOrder()//создает заказ
        {
            customerorders.Add(new Order ( this.Id,this.deliveryaddress ));
        }
        public void RemoveOrderByind(int ind)//удаляет заказ по индексу
        {
            try
            {
                
                customerorders[ind].RemoveAllwithoutencr();
                customerorders.RemoveAt(ind);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public Order FindOrderListByInd(int ind)// возвращает заказ по определенному индексу
        {
            return customerorders[ind];
        }
        public int GetListCount()//возвращает количество элементов в листе заказов
        {
            return customerorders.Count();
        }
        public void GetAllOrders()//выводит все заказы
        {
            int c=this.GetListCount();
            for(int i=0;i<c;i++)
            {
                this.FindOrderListByInd(i).GetInfoCUstomer();
                Console.WriteLine();
            }
        }
    }
}
