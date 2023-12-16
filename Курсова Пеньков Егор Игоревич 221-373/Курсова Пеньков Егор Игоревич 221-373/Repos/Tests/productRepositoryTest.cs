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
    public class productRepositoryTest
    {
        [Fact]
        public void AddProductTest()
        {
            productSneakers productSneakers = new productSneakers("nike", 40, 20, "38", "");
            productSweater sweater = new productSweater("sweater", 100, 20, "M", "");
            productRepository productRepository = new productRepository();
            productRepository.AddProduc(sweater);
            productRepository.AddProduc(productSneakers);
            Assert.Equal(productSneakers.Id, productRepository.Items[productRepository.Items.Count() - 1].Id);
            Assert.Equal(sweater.Id, productRepository.Items[productRepository.Items.Count() - 2].Id);
        }
        [Fact]
        public void RemoveProductByIndTest()
        {
            productSneakers productSneakers = new productSneakers("nike", 40, 20, "38", "");
            productSweater sweater = new productSweater("sweater", 100, 20, "M", "");
            productRepository productRepository = new productRepository();
            productRepository.AddProduc(sweater);
            productRepository.AddProduc(productSneakers);
            productRepository.RemoveProductByInd(0);
            Assert.Equal(1, productRepository.Items.Count());

        }

    }
}
