using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Курсова_Пеньков_Егор_Игоревич_221_373.product;
using Курсова_Пеньков_Егор_Игоревич_221_373.ShoppingProcces;
using Курсова_Пеньков_Егор_Игоревич_221_373.Users;

namespace Курсова_Пеньков_Егор_Игоревич_221_373.Repos
{
    internal class orderRepository:Repository<Order> // класс, который представляет из себя репозиторий для хранения в себе всех заказов
    {  
        public void AddOrder(Order order) // добавляет заказ в лист
        {
            items.Add(order);
        }
        public void GetOrdersinfo()// выводит информацию о заказах на консоль
        {
            int k = 0;
            foreach(Order order in items)
            {
                Console.Write($"Ind: {k} \t ");
                order.GetInfo();
                k++;
            }
        }
        public void RemoveOrderbyid(string id)// удаляет заказ по id
        {
            for (int k = 0; k < items.Count; k++)
            {
                if (items[k].Id == id)
                {
                    items[k].RemoveAll();
                    items.RemoveAt(k);
                }
            }
        }
        public void RemoveOrderByInd(int ind) // удаляет заказ по индексу из листа
        {
            try
            {
                items[ind].RemoveAll();
                items.RemoveAt(ind);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void SetDeliverymantOorderByInd(int ind,string deliverymanid,DateOnly date)//прикрепляет курьера к заказу и ставит дату доставки по индексу в листе
        {
            items[ind].Date=date;
            items[ind].DeliverymanId=deliverymanid;
        }
        public Order FindOrderByInd(int ind)// вохвращает заказ по индексу, если такого нет, то ничего не возвращает
        {
            try
            {
                return items[ind];
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }        
        }
        public Order FindOrderById(string id)// возвращает заказ по id
        {
            foreach(Order order in items)
            {
                if(order.Id==id) return order;
            }
            return null;
        }
        public void GetUserOrderList(userCustomer userCustomer)// переносит заказ из корзины пользователя в общий лист заказов
        {
            int c=userCustomer.GetListCount();
            for(int k=0;k<c;k++)
            {
                if(this.FindOrderById(userCustomer.FindOrderListByInd(k).Id) is null)
                {
                    this.AddOrder(userCustomer.FindOrderListByInd(k));
                    items[items.Count() - 1].CustomerId = userCustomer.Id;
                    
                }            
            }
        }
        public void GetOrdersByDeliverymanId(string deliverymanId)// выводит информацию о заказе, к которому приереплен курьер с нужным id
        {
            foreach(var order in items)
            {
                if (order.DeliverymanId == deliverymanId)
                {
                    order.GetInfo();
                }
            }
        }
        public void RemoveAllUserProducts(string id)// удаляет все заказы связанные с оперделенным пользователем
        {
            int l=items.Count();
            for(int i=l-1;i>=0;i--)
            {
                if (items[i].CustomerId==id) { 
                    items.RemoveAt(i);
                }
            }
        }
    }
}
