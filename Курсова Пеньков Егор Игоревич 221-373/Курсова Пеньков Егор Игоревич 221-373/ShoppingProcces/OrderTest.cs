using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Курсова_Пеньков_Егор_Игоревич_221_373.product;

namespace Курсова_Пеньков_Егор_Игоревич_221_373.ShoppingProcces
{
    public class OrderTest
    {
        [Fact]
        public void OrderAddProductTest()
        {
            Order order = new Order("","");
            productSneakers productSneakers = new productSneakers("nike", 40, 20, "38", "");
            productSweater sweater = new productSweater("sweater", 100, 20, "M","");
            order.AddProduct(productSneakers);
            order.AddProduct(sweater);
            Assert.Equal(productSneakers.Id, order.Products[order.Products.Count()-2].Id);
            Assert.Equal(sweater.Id, order.Products[order.Products.Count() - 1].Id);
            Assert.Equal( 140, order.Pricesum);
            Assert.Equal(19, sweater.Quantity);
        }
        [Fact]
        public void RemoveProductbyindTest()
        {
            Order order = new Order("", "");
            productSneakers productSneakers = new productSneakers("nike", 40, 20, "38", "");
            productSweater sweater = new productSweater("sweater", 100, 20, "M", "");
            order.AddProduct(productSneakers);
            order.AddProduct(sweater);
            order.RemoveProductbyind(0);
            Assert.Equal(1,order.Products.Count());
            Assert.Equal(20, productSneakers.Quantity);
        }
    }
}
