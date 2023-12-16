using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Курсова_Пеньков_Егор_Игоревич_221_373.Repos;

namespace Курсова_Пеньков_Егор_Игоревич_221_373.Users
{
    internal class userDeliveryman:User
    {
        public override void SuccesMessege()//выводит сообщение об успешной регистарции
        {
            Console.WriteLine($"Здравствуйте курьер, {Name}, вы успешно зашли");
        }
        public override void GetJob()//выводит роль пользователя
        {
            Console.Write("Deliveryman");
        }
        public userDeliveryman(string name, string email, string password) : base(name, email, password)
        { }
        public void TakeOrderByInd(int ind,DateOnly dateOnly, orderRepository orderRepository)//прикрепление к заказу по индексу в определенном репозитории
        {

            var order=orderRepository.FindOrderByInd(ind);
            if (order is null)
            {
                Console.WriteLine("Такого заказа нет");
            }
            else if (order.DeliverymanId==null || order.DeliverymanId == "")
            {
                order.DeliverymanId = this.id;
                order.Date = dateOnly;
            }
            else
            {
                Console.WriteLine("Заказ уже занят");
            }
        }
        public void TakeOrderById(string id, DateOnly dateOnly, orderRepository orderRepository)//прикрепление к заказу по id в определенном репозитории
        {
            var order = orderRepository.FindOrderById(id);
            if(order is null)
            {
                Console.WriteLine("Такого заказа нет");
            }
            else if (order.DeliverymanId == null || order.DeliverymanId == "")
            {
                order.DeliverymanId = this.id;
                order.Date = dateOnly;
            }
            else
            {
                Console.WriteLine("Заказ уже занят");
            }
        }
        public void RejectTheOrderByInd(int ind, orderRepository orderRepository)// открепляется от заказа по индексу в определенном репозитории
        {
            var order = orderRepository.FindOrderByInd(ind);
            if (order.DeliverymanId == this.id)
            {
                order.DeliverymanId = "";
                order.Date = new DateOnly(2023,1,1);
            }
            else
            {
                Console.WriteLine("Не ваш заказ");
            }
        }
    
        public void RejectTheOrderById(string id, orderRepository orderRepository)// открепляется от заказа по id в определенном репозитории
        {
            var order = orderRepository.FindOrderById(id);
            if(order.DeliverymanId==this.id)
            {
                order.DeliverymanId = "";
                order.Date = new DateOnly(2023, 1, 1);
            }
            else
            {
                Console.WriteLine("Не ваш заказ");
            }
        }
        public void GetDeliveryOrdersInfo(orderRepository orderRepository)// возвращает все заказы, к которым прикреплен этот курьер
        {
            orderRepository.GetOrdersByDeliverymanId(this.id);
        }
    }
}
