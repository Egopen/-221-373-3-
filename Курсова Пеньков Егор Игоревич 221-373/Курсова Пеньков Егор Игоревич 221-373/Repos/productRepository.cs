using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Курсова_Пеньков_Егор_Игоревич_221_373.product;

namespace Курсова_Пеньков_Егор_Игоревич_221_373.Repos
{
    internal class productRepository:Repository<Product>// представляет из себя репозиториий, который хранит все товары
    {
        
        public void AddProduc(Product produc)// добавляет продукт в лист
        {
            items.Add(produc);
        }
        public void RemoveProductByInd(int ind)// удаляет продукт из листа по индексу
        {
            items.RemoveAt(ind);
        }
        public void GetAllProduct()//выврдит информацию о всех продуктах в магазине
        {
            for(int i=0;i<items.Count;i++)
            {
                Console.WriteLine($"Наименование продукта: {items[i].Name} \t Цена: {items[i].Price} \t Индекс: {i}");
            }
            Console.WriteLine();
        }
        public void GetAllProductForAdmin()// выводит информацию о всех продуктах в магазине с необходимыми для модерации данными
        {
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"Наименование продукта: {items[i].Name} \t Цена: {items[i].Price} \t Количество:{items[i].Quantity} \t Id:{items[i].Id} \t Индекс: {i}");
            }
        }
        public Product FindProductByInd(int ind)// возвращает продукт по индексу
        {
            try
            {
                return items[ind];
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
    }
}
