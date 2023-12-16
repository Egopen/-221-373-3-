using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Курсова_Пеньков_Егор_Игоревич_221_373.product;
using Курсова_Пеньков_Егор_Игоревич_221_373.ShoppingProcces;

namespace Курсова_Пеньков_Егор_Игоревич_221_373.Repos.Tests
{
    public class orderRepositoryTest
    {
        [Fact]
        public void AddOrderTest()
        {
            Order order = new Order("", "");
            productSneakers productSneakers = new productSneakers("nike", 40, 20, "38", "");
            productSweater sweater = new productSweater("sweater", 100, 20, "M", "");
            order.AddProduct(productSneakers);
            order.AddProduct(sweater);
            orderRepository orderRepository = new orderRepository();
            orderRepository.AddOrder(order);
            Assert.Equal(order.Id, orderRepository.Items[0].Id);
            Assert.Equal(productSneakers.Id, orderRepository.Items[0].Products[0].Id);
        }
        [Fact]
        public void RemoveOrderByIndTest()
        {
            Order order = new Order("", "");
            productSneakers productSneakers = new productSneakers("nike", 40, 20, "38", "");
            productSweater sweater = new productSweater("sweater", 100, 20, "M", "");
            order.AddProduct(productSneakers);
            order.AddProduct(sweater);
            orderRepository orderRepository = new orderRepository();
            orderRepository.AddOrder(order);
            orderRepository.RemoveOrderByInd(0);
            Assert.Equal(0, orderRepository.Items.Count);

        }
        [Fact]
        public void RemoveOrderByIdTest()
        {
            Order order = new Order("", "");
            productSneakers productSneakers = new productSneakers("nike", 40, 20, "38", "");
            productSweater sweater = new productSweater("sweater", 100, 20, "M", "");
            order.AddProduct(productSneakers);
            order.AddProduct(sweater);
            orderRepository orderRepository = new orderRepository();
            orderRepository.AddOrder(order);
            orderRepository.RemoveOrderbyid(order.Id);
            Assert.Equal(0, orderRepository.Items.Count);

        }
    }
}
