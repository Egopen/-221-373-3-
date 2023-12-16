using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Курсова_Пеньков_Егор_Игоревич_221_373.Repos;

namespace Курсова_Пеньков_Егор_Игоревич_221_373.Users
{
    internal class userAdmin: User// этот класс пердставляет из себя администартора
    {
        public override void SuccesMessege()
        {
            Console.WriteLine($"Здравствуйте администратор, {Name}, вы успешно зашли");
        }
        public override void GetJob()
        {
            Console.Write("Admin \t ");
        }
        public userAdmin(string name, string email, string password) : base(name, email, password)
        { }
        public void RemoveOrderByIndFromRepo(int ind,orderRepository orderRepository)//удаление заказа из определенного репозитория по индексу
        {
            try
            {
                orderRepository.RemoveOrderByInd(ind);
            }
            catch(Exception ex) { Console.WriteLine(ex.Message); }
            
        }
        public void RemoveOrderByIdFromRepo(string id,orderRepository orderRepository)//удаление заказа из определенного репозитория по id
        {
            orderRepository.RemoveOrderbyid(id);
        }
        public void RemoveUserByIndFromRepo(int ind,userRepository userRepository)//удаление пользователя из определенного репозитория по индексу
        {
            userRepository.RemoveUserbyind(ind);
        }
        public void RemoveUserByIdFromRepo(string id, userRepository userRepository)//удаление пользователя из определенного репозитория по id
        {
            userRepository.RemoveUserbyid(id);
        }
        public void GetUserRepoInfo(userRepository userRepository)//вывоит информациюо всех пользователях из определенного репозитоория
        {
            userRepository.GetUserinfo();
        }
        public void GetOrderRepoInfo(orderRepository orderRepository) { orderRepository.GetOrdersinfo(); }// выводит информацию о всех заказах из определенного репохитория
    }
}
