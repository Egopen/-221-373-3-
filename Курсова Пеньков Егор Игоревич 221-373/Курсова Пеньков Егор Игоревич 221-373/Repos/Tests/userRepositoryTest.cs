using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Курсова_Пеньков_Егор_Игоревич_221_373.product;
using Курсова_Пеньков_Егор_Игоревич_221_373.Users;

namespace Курсова_Пеньков_Егор_Игоревич_221_373.Repos.Tests
{
    public class userRepositoryTest
    {
        [Fact]
        public void AddUserTest()
        {
            userAdmin userAdmin = new userAdmin("Egor", "eg@gmail.com", "123");
            userCustomer userCustomer = new userCustomer("Alex", "al@gmail.com", "123","Moscow");
            userRepository userRepository = new userRepository();
            userRepository.AddUser(userAdmin);
            userRepository.AddUser(userCustomer);
            Assert.Equal(userAdmin.Id, userRepository.Items[0].Id);
            Assert.Equal(userCustomer.Id, userRepository.Items[1].Id);
        }
        [Fact]
        public void RemoveUserByIndTest()
        {
            userAdmin userAdmin = new userAdmin("Egor", "eg@gmail.com", "123");
            userCustomer userCustomer = new userCustomer("Alex", "al@gmail.com", "123", "Moscow");
            userRepository userRepository = new userRepository();
            userRepository.AddUser(userAdmin);
            userRepository.AddUser(userCustomer);
            userRepository.RemoveUserbyind(1);
            Assert.Equal(1,userRepository.Items.Count);
            Assert.Equal(userAdmin.Id, userRepository.Items[0].Id);
        }
        [Fact]
        public void RemoveUserByIdTest()
        {
            userAdmin userAdmin = new userAdmin("Egor", "eg@gmail.com", "123");
            userCustomer userCustomer = new userCustomer("Alex", "al@gmail.com", "123", "Moscow");
            userRepository userRepository = new userRepository();
            userRepository.AddUser(userAdmin);
            userRepository.AddUser(userCustomer);
            userRepository.RemoveUserbyid(userCustomer.Id);
            Assert.Equal(1, userRepository.Items.Count);
            Assert.Equal(userAdmin.Id, userRepository.Items[0].Id);
        }
        
    }
}
