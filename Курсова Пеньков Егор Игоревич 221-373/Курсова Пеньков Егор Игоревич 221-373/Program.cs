using Курсова_Пеньков_Егор_Игоревич_221_373.product;
using Курсова_Пеньков_Егор_Игоревич_221_373.Repos;
using Курсова_Пеньков_Егор_Игоревич_221_373.ShoppingProcces;
using Курсова_Пеньков_Егор_Игоревич_221_373.Users;

namespace Курсова_Пеньков_Егор_Игоревич_221_373
{
    internal class Program
    {
        static void Main(string[] args) 
        {

            userAdmin userAdminEgor = new userAdmin("Egor", "eg@gmail.com", "123");// данные для входа под админом
            userCustomer userCustomerAlex = new userCustomer("Alex", "al@gmail.com", "123", "Moscow");// данные для входа под покупателем
            userCustomer userCustomerKate = new userCustomer("Kate", "kt@gmail.com", "123", "Moscow");// данные для входа под покупателем
            userDeliveryman userDeliverymanPetr = new userDeliveryman("Petr", "pe@gmail.com", "123");// данные для входа под курьером
            userRepository userRepository = new userRepository();
            userRepository.Items.Add(userAdminEgor);
            userRepository.Items.Add(userCustomerAlex);
            userRepository.Items.Add(userCustomerKate);
            userRepository.Items.Add(userDeliverymanPetr);
            productSneakers productSneakersRun = new productSneakers("Running boots nike", 9000, 38, "42", "");
            productSweater productSweaterHoodie = new productSweater("Custom hoodie", 3500, 12, "M", "White oversize hoodie");
            productTshirt productTshirtPolo = new productTshirt("Custom polo", 2200, 8, "L", "Base polo");
            orderRepository orderRepository = new orderRepository();
            userCustomerAlex.CreateOrder();
            userCustomerAlex.BuyProduct(productSneakersRun);
            userCustomerAlex.BuyProduct(productTshirtPolo);
            userCustomerKate.CreateOrder();
            userCustomerKate.BuyProduct(productSweaterHoodie);
            userCustomerKate.BuyProduct(productSneakersRun);
            orderRepository.GetUserOrderList(userCustomerKate);
            orderRepository.GetUserOrderList(userCustomerAlex);
            productRepository ProductRepository = new productRepository();
            ProductRepository.AddProduc(productSneakersRun);
            ProductRepository.AddProduc(productTshirtPolo);
            ProductRepository.AddProduc(productSweaterHoodie);
            string correct = "y";
            while(correct=="y")
            {
                User newuser;
                Console.WriteLine("Что бы вы хотели сделать?");
                Console.WriteLine("Введите '0', если хотите выйти");
                Console.WriteLine("Введите '1', если хотите зарегистрироваться");
                Console.WriteLine("Введите '2', если хотите войти в аккаунт");
                string answer=Console.ReadLine();
                Console.WriteLine();
                if (answer == "1")
                {
                    Console.Write("Введите ваше имя: ");
                    string username = Console.ReadLine();
                    Console.Write("Введите вашу почту: ");
                    string useremail = Console.ReadLine();
                    Console.Write("Введите ваш пароль: ");
                    string userpasswor = Console.ReadLine();
                    Console.Write("Введите ваш адрес: ");
                    string adress = Console.ReadLine();
                    userRepository.AddUser(new userCustomer(username, useremail, userpasswor, adress));
                    Console.WriteLine();
                    newuser = userRepository.Registration(useremail, userpasswor);
                    Console.WriteLine();
                }
                else if (answer == "2")
                {
                    Console.Write("Введите вашу почту: ");
                    string useremail = Console.ReadLine();
                    Console.Write("Введите ваш пароль: ");
                    string userpasswor = Console.ReadLine();
                    Console.WriteLine();
                    newuser = userRepository.Registration(useremail, "123");
                    Console.WriteLine();

                }
                else
                {
                    newuser = null;
                    break;
                }
                
                if (newuser is null)
                {
                    Console.WriteLine("Такого пользователя нет");
                }
                else if (newuser is userAdmin)
                {
                    userAdmin admin = (userAdmin)newuser;
                    string k = "5";
                    while (k != "0")
                    {
                        Console.WriteLine("Что бы вы хотели сделать?");
                        Console.WriteLine("Введите '0', если хотите выйти");
                        Console.WriteLine("Введите '1', если хотите посмотреть информацию о всех пользователях");
                        Console.WriteLine("Введите '2', если хотите посмотреть информацию о всех заказах");
                        Console.WriteLine("Введите '3', если хотите удалить пользователя");
                        Console.WriteLine("Введите '4', если хотите удалить заказ");
                        Console.WriteLine("Введите '5', если хотите посмотреть информацию о всех товарах на складе");
                        
                        k = Console.ReadLine();
                        Console.WriteLine();
                        if (k == "0")
                        {
                            Console.WriteLine("Вы вышли");

                        }
                        else if (k == "1")
                        {
                            admin.GetUserRepoInfo(userRepository);

                        }
                        else if (k == "2")
                        {
                            admin.GetOrderRepoInfo(orderRepository);
                        }
                        else if (k == "3")
                        {
                            string k1 = "0";
                            Console.WriteLine("Введите '1', если хотите удалить пользователя по индексу в репозитории");
                            Console.WriteLine("Введите '2', если хотите удалить пользователя по id в репозитории");
                            k1 = Console.ReadLine();
                            if (k1 == "1")
                            {
                                Console.WriteLine("Введите индекс пользователя");
                                int ind = int.Parse(Console.ReadLine());
                                orderRepository.RemoveAllUserProducts(userRepository.FindUSerByInd(ind).Id);
                                admin.RemoveUserByIndFromRepo(ind, userRepository);
                            }
                            if (k1 == "2")
                            {
                                Console.WriteLine("Введите id пользователя");
                                string ind = Console.ReadLine();
                                orderRepository.RemoveAllUserProducts(userRepository.FindUSerById(ind).Id);
                                admin.RemoveUserByIdFromRepo(ind, userRepository);
                            }
                            else
                            {
                                Console.WriteLine("Вы вышли");

                            }

                        }
                        else if (k == "4")
                        {
                            string k1 = "0";
                            Console.WriteLine("Введите '1', если хотите удалить заказ по индексу в репозитории");
                            Console.WriteLine("Введите '2', если хотите удалить заказ по id в репозитории");
                            k1 = Console.ReadLine();
                            if (k1 == "1")
                            {
                                Console.WriteLine("Введите индекс заказа");
                                int ind = int.Parse(Console.ReadLine());
                                admin.RemoveOrderByIndFromRepo(ind, orderRepository);
                            }
                            else if (k1 == "2")
                            {
                                Console.WriteLine("Введите id заказа");
                                string ind = Console.ReadLine();
                                admin.RemoveOrderByIdFromRepo(ind, orderRepository);
                            }
                            else
                            {
                                Console.WriteLine("Вы вышли");

                            }
                        }
                        else if (k == "5")
                            {
                                ProductRepository.GetAllProductForAdmin();
                                Console.WriteLine();
                            }
                        else
                        {
                            Console.WriteLine("Вы вышли");
                            k = "0";

                        }
                    }

                }
                else if (newuser is userCustomer)
                {
                    userCustomer customer = (userCustomer)newuser;
                    string k = "5";
                    while (k != "0")
                    {
                        Console.WriteLine("Что бы вы хотели сделать?");
                        Console.WriteLine("Введите '0', если хотите выйти");
                        Console.WriteLine("Введите '1', если хотите посмотреть информацию о всех ваших заказах");
                        Console.WriteLine("Введите '2', если хотите посмотреть каталог");
                        Console.WriteLine("Введите '3', если хотите купить товар");
                        Console.WriteLine("Введите '4', если хотите удалить заказ");
                        k = Console.ReadLine();
                        Console.WriteLine();
                        if (k == "1")
                        {
                            Console.WriteLine();
                            customer.GetAllOrders();
                        }
                        else if (k == "2")
                        {
                            ProductRepository.GetAllProduct();
                        }
                        else if (k == "3")
                        {
                            customer.CreateOrder();
                            string k1 = "y";
                            while (k1 == "y")
                            {
                                Console.Write("Введите индекс товара: ");
                                int ind = int.Parse(Console.ReadLine());
                                customer.BuyProduct(ProductRepository.FindProductByInd(ind));
                                Console.Write("Хотите продолжить покупки y/n: ");
                                k1 = Console.ReadLine();
                                    if (k1 != "y")
                                    {
                                        orderRepository.GetUserOrderList(customer);
                                    }
                            }
                        }
                        else if (k == "4")
                        {
                            Console.WriteLine("Введите номер заказа: ");
                            int ind = int.Parse(Console.ReadLine());
                            customer.RemoveOrderByind(ind - 1);
                        }
                    }

                }
                else if (newuser is userDeliveryman)
                {
                    userDeliveryman deliveryman = (userDeliveryman)newuser;
                    string k = "5";
                    while (k != "0")
                    {
                        Console.WriteLine("Что бы вы хотели сделать?");
                        Console.WriteLine("Введите '0', если хотите выйти");
                        Console.WriteLine("Введите '1', если хотите посмотреть информацию о ваших заказах");
                        Console.WriteLine("Введите '2', если хотите взять заказ");
                        Console.WriteLine("Введите '3', если хотите отколнить заказ");
                        Console.WriteLine("Введите '4, если хотите посмотреть информацию о всех заказах");
                        k = Console.ReadLine();
                        Console.WriteLine();
                            if (k == "1")
                        {
                            deliveryman.GetDeliveryOrdersInfo(orderRepository);
                        }
                        else if (k == "2")
                        {
                            string k1;
                            Console.WriteLine("Введите '1', если хотите взять заказ по индексу в репозитории");
                            Console.WriteLine("Введите '2', если хотите взять заказ по id в репозитории");
                            k1 = Console.ReadLine();
                            if (k1 == "1")
                            {
                                Console.WriteLine("Введите индекс заказа");
                                int ind = int.Parse(Console.ReadLine());
                                Console.WriteLine("Введите дату доставки ");
                                DateOnly dateOnly = new DateOnly();
                                Console.Write("Введите год доставки ");
                                int year = int.Parse(Console.ReadLine());
                                Console.Write("Введите месяц доставки ");
                                int month = int.Parse(Console.ReadLine());
                                Console.Write("Введите день доставки ");
                                int day = int.Parse(Console.ReadLine());
                                DateOnly dateOnly1 = new DateOnly(year, month, day);
                                if (dateOnly1 < new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day))
                                {
                                    Console.WriteLine("Неправильная дата");

                                }
                                else
                                {
                                    deliveryman.TakeOrderByInd(ind, dateOnly1, orderRepository);
                                }
                            }
                            else if (k1 == "2")
                            {
                                Console.WriteLine("Введите id заказа");
                                string ind = Console.ReadLine();
                                Console.WriteLine("Введите дату доставки ");
                                DateOnly dateOnly = new DateOnly();
                                Console.Write("Введите год доставки ");
                                int year = int.Parse(Console.ReadLine());
                                Console.Write("Введите месяц доставки ");
                                int month = int.Parse(Console.ReadLine());
                                Console.Write("Введите день доставки ");
                                int day = int.Parse(Console.ReadLine());
                                DateOnly dateOnly1 = new DateOnly(year, month, day);
                                if (dateOnly1 < new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day))
                                {
                                    Console.WriteLine("Неправильная дата или формат");

                                }
                                else
                                {
                                    deliveryman.TakeOrderById(ind, new DateOnly(year, month, day), orderRepository);
                                }
                            }
                            else { }
                        }
                        else if (k == "3")
                        {
                            string k1;
                            Console.WriteLine("Введите '1', если хотите отклонить заказ по индексу в репозитории");
                            Console.WriteLine("Введите '2', если хотите отклонить  заказ по id в репозитории");
                            k1 = Console.ReadLine();
                            if (k1 == "1")
                            {
                                Console.WriteLine("Введите индекс заказа");
                                int ind = int.Parse(Console.ReadLine());
                                deliveryman.RejectTheOrderByInd(ind, orderRepository);
                            }
                            else if (k1 == "2")
                            {
                                Console.WriteLine("Введите id заказа");
                                string ind = Console.ReadLine();
                                deliveryman.RejectTheOrderById(ind, orderRepository);
                            }
                            else
                            {
                                k = "0";
                            }
                        }
                        else if (k == "4")
                        {
                            orderRepository.GetOrdersinfo();
                        }
                    }

            }
                Console.Write("Хотите продолжить y/n ");
                correct=Console.ReadLine();
                Console.WriteLine();
        }

        }

    }
}