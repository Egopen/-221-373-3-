using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсова_Пеньков_Егор_Игоревич_221_373.Users
{
    internal abstract class User// этот класс представляет из себя базовый класс для всех пользователей
    {
        protected string id= Guid.NewGuid().ToString();
        public string Id { get { return id; } }
        protected string password;
        public string Password { get { return password; } }
        protected string name;
        public string Name { get { return name; } set { name = value; } }
        protected string email;
        public string Email { get { return email; } set { email=value; } }
        public abstract void SuccesMessege();
        public abstract void GetJob();
        public User(string name,string email,string password) { 
            this.name = name;
            this.email = email;
            this.password = password;
        }
    }
}
