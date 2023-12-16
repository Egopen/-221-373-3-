using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Курсова_Пеньков_Егор_Игоревич_221_373.Users;

namespace Курсова_Пеньков_Егор_Игоревич_221_373.Repos
{
    internal  class userRepository:Repository<User>// представляет из себя таблицу с данными, который хранит всех поьзователей
    {
        public void AddUser(User user)// добавляет пользователя в лист
        {
            if (user.Password.Length >= 8)
            {
                bool flag = false;
                foreach(char x in user.Password)
                {
                    if (char.IsUpper(x))
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag)
                {
                    string pattern = "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}";
                    Match isMatch = Regex.Match(user.Email, pattern, RegexOptions.IgnoreCase);
                    if(isMatch.Success)
                    {
                        Console.WriteLine("Успешная регистрация.");
                        items.Add(user);
                    }
                    else
                    {
                        Console.WriteLine("Неправильный формат почты.");
                    }
                }
                else
                {
                    Console.WriteLine("Неправильный формат пароля.");
                }
            }
            else
            {
                Console.WriteLine("Пароль слишком короткий.");
            }
            
        }
        public void RemoveUserbyind(int ind)// удаляет пользователя из листа по индексу в нем
        {
            try { 
                items.RemoveAt(ind);
                if (items[ind] is userCustomer)
                {
                    var user = (userCustomer)items[ind];
                    int l = user.GetListCount();
                    for (int i = 0; i < l; i++)
                    {
                        user.RemoveProductByInd(i);
                    }

                }
            } 
            catch(Exception ex) {
            Console.WriteLine(ex.Message);
            }  
        }
        public void RemoveUserbyid(string id)// удаляет пользователя из листа по его id
        {
            for(int k=0;k<items.Count;k++)
            {
                if (items[k].Id== id)
                {
                    if (items[k] is userCustomer)
                    {
                        var user = (userCustomer)items[k];
                        int l=user.GetListCount();
                        for(int i=0;i<l;i++)
                        {
                            user.RemoveProductByInd(i);
                        }   
                    }
                    items.RemoveAt(k);
                }
            }
        }
        public void GetUserinfo()// выводит информацию о пользователях
        {
            int k = 0;
            foreach (var user in items)
            {
                user.GetJob();
                Console.WriteLine($"\t Ind: {k} \t Id: {user.Id} \t Name: {user.Name} \t Email: {user.Email} \t  ");
                k++;
            }
        }
        public User FindUSerById(string id)// возвращает пользователя по его id из репозитория
        {
            for(int i=0;i<items.Count;i++)
            {
                if (items[i].Id == id)
                {
                    return items[i];
                }
            }
            return null;
        }
        public User FindUSerByInd(int ind)//возвращает пользователя по его индексу в репозитории
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
        public User Registration(string email,string password)//вход пользователя в систему
        {
            foreach (var user in items)
            {
                if(user.Password==password && user.Email==email)
                {
                    user.SuccesMessege();
                    return user;
                }
            }
            Console.WriteLine("Неправльный логин или пароль");
            return null;
        }
    }
}
