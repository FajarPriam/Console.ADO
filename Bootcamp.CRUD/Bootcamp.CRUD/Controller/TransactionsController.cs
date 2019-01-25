using Bootcamp.CRUD.Context;
using Bootcamp.CRUD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.CRUD.Controller
{
    public class TransactionsController
    {
        public int? count;
        public void AddTransactions()
        {

            Item item = new Item();
            Transaction transaction = new Transaction();
            MyContext _context = new MyContext();
            TransactionItem transactionitem = new TransactionItem();

            //Insert date time table Transaction pada colom TransactionDate
            transaction.TransactionDate = DateTimeOffset.Now.LocalDateTime;
            //Insert date time table TransactionItem pada colo CreateDate
            transactionitem.CreateDate = DateTimeOffset.Now.LocalDateTime;
            _context.Transactions.Add(transaction);
            _context.SaveChanges();

            //memasukkan Id terakhir dari table Transactions ke getTransaction
            var getTransaction = _context.Transactions.Max(x => x.Id);
            //memasukkan data dari table Transaction ke getTransactionDetail
            var getTransactionDetail = _context.Transactions.Find(getTransaction);
            
            //menampilkan id dan transaction date 
            Console.WriteLine("Id Transaction   : " + getTransaction);
            Console.WriteLine("Transaction Date : " + getTransactionDetail.TransactionDate);
            
            Console.Write("How many items : ");
            count = Convert.ToInt16(Console.ReadLine());
            if (count == null)
            {
                Console.WriteLine("Please insert count of item that you want to buy");
                Console.Read();
            }
            else
            {
                for(int i = 1; i <= count; i++)
                {
                    Console.Write("Insert id item : ");
                    int? id = Convert.ToInt16(Console.ReadLine());
                    if(id == null)
                    {
                        Console.WriteLine("Please insert id that you want to buy");
                        Console.Read();
                    }
                    else
                    {
                        var getItem = _context.Items.Find(id);
                        if(getItem == null)
                        {
                            Console.WriteLine("We don't have item with id : " + id);
                            Console.Read();
                        }
                        else
                        {
                            Console.Write("Insert amount of item : ");
                            var quantity = Convert.ToInt16(Console.ReadLine());
                            if (getItem.Stock < quantity)
                            {
                                Console.Write("Stock is not enough, we have " + getItem.Stock);
                                Console.Read();
                            }
                            else
                            {
                                transactionitem.Transaction = getTransactionDetail;
                                transactionitem.Items = getItem;
                                transactionitem.Quantity = quantity;
                                _context.TransactionItem.Add(transactionitem);
                                _context.SaveChanges();
                            }
                        }
                    }
                }

                var getPrice = _context.TransactionItem.Where(x => x.Transaction.Id == getTransactionDetail.Id).ToList();
                int? total = 0;
                foreach (var proceed in getPrice)
                {
                    total += (proceed.Quantity * proceed.Items.Price);
                }
                Console.WriteLine("Total Price : " + total);
                Console.Write("Balance     : ");
                int? balance = Convert.ToInt32(Console.ReadLine());
                Console.Write("Exchange    : " + (balance - total));
                Console.Read();


                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("              TRRANSACTION ID  " + getTransaction);
                Console.WriteLine(getTransactionDetail.TransactionDate.Date);
                Console.WriteLine(getTransactionDetail.TransactionDate.TimeOfDay);
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("Name\t\tQuantity\t\tPrice\t\tTotal");
                Console.WriteLine("----------------------------------------------------");

                var getDatatoDisplay = _context.TransactionItem.Where(x => x.Transaction.Id == getTransactionDetail.Id).ToList();
                //var getDatatoDisplay = _context.Items.Where(x => x.IsDelete == false).ToList();

                foreach (var tampilin in getDatatoDisplay)
                {
                    Console.WriteLine("" + tampilin.Items.Name + "\t\t" + tampilin.Quantity + "\t\t" + tampilin.Items.Price + "\t\t" + total);
                }
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("Total Price : " + total);
                Console.WriteLine("Balance     : " + balance);
                Console.WriteLine("Exchange    : " + (balance - total));
                Console.WriteLine("----------------------------------------------------");
                Console.ReadLine();
                Console.Read();
            }
        }
    }
}
