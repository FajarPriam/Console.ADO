using Bootcamp.CRUD.Context;
using Bootcamp.CRUD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.CRUD.Controller
{
    public class ItemsController
    {
        public int? idSupplier;
        public void ManageItem()
        {
            var result = 0;

            Item item = new Item();
            MyContext _context = new MyContext();
            Console.WriteLine("=========== Item Data ============");
            Console.WriteLine("1. Insert");
            Console.WriteLine("2. Update");
            Console.WriteLine("3. Delete");
            Console.WriteLine("4. Retrieve");
            Console.WriteLine("======================================");
            Console.Write("Going to : ");
            int chance = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("======================================");

            switch (chance)
            {
                case 1:
                    // ini untuk memasukkan nilai Name, Price, Stock dan idsupplier di Item
                    // ini untuk manampilkan 'Insert Data Item'
                    Console.WriteLine("Insert Data Item");
                    // ini untuk memasukkan nilai 'Nama Item'
                    Console.Write("Insert Name Item : ");
                    item.Name = Console.ReadLine();
                    // ini untuk memasukkan  nilai 'Price Item'
                    Console.Write("Insert Price Item : ");
                    item.Price = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Insert Stock Item : ");
                    item.Stock = Convert.ToInt32(Console.ReadLine());
                    item.CreateDate = DateTimeOffset.Now.LocalDateTime;
                    Console.Write("Insert Supplier Id : ");
                    int? idSupplier = Convert.ToInt16(Console.ReadLine());

                    if (idSupplier == null)
                    {
                        Console.Write("Please Insert Supplier Id :");
                        Console.Read();
                    }
                    else
                    {
                        var getSupplier = _context.Suppliers.Find(idSupplier);
                        if(getSupplier == null)
                        {
                            Console.Write("We don't have id :" + idSupplier);
                            Console.Read();
                        }
                        else
                        {
                            item.Suppliers = getSupplier;
                            _context.Items.Add(item);
                            result = _context.SaveChanges();
                            if (result > 0)
                            {
                                Console.Write("Insert Successfully");
                                Console.Read();
                            }
                            else
                            {
                                Console.Write("Insert Failed");
                                Console.Read();
                            }
                        }
                    }
                    Console.Read();
                    break;
                case 2:
                    // input id untuk dicari
                    Console.Write("Insert Id to Update Data : ");
                    int id = Convert.ToInt16(Console.ReadLine());

                    // mencari data sesuai dengan id di database
                    var get = _context.Items.Find(id);

                    // pengecekan data di database
                    if (get == null)
                    {
                        // jika tidak ada, maka akan menampilkan seperti berikut
                        Console.Write("Sorry, your data is not found");
                        Console.Read();
                    }
                    else
                    {
                        // jika ada, maka akan meminta inputan nama dan akan disimpan di database
                        Console.Write("Update Name Item : ");
                        get.Name = Console.ReadLine();
                        Console.Write("Update Price Item : ");
                        get.Price = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Update Stock Item : ");
                        get.Stock = Convert.ToInt32(Console.ReadLine());
                        get.UpdateDate = DateTimeOffset.Now.LocalDateTime;
                        Console.Write("Update Supplier Id : ");
                        idSupplier = Convert.ToInt16(Console.ReadLine());

                        if (idSupplier == null)
                        {
                            Console.Write("Please Insert Supplier Id :");
                            Console.Read();
                        }
                        else
                        {
                            var getSupplier = _context.Suppliers.Find(idSupplier);
                            if (getSupplier == null)
                            {
                                Console.Write("We don't have id :" + idSupplier);
                                Console.Read();
                            }
                            else
                            {
                                get.Suppliers = getSupplier;
                                result = _context.SaveChanges();
                                if (result > 0)
                                {
                                    Console.Write("Update Successfully");
                                    Console.Read();
                                }
                                else
                                {
                                    Console.Write("Update Failed");
                                    Console.Read();
                                }
                            }
                        }
                    }
                    break;
                case 3:
                    // input id untuk dicari
                    Console.Write("Insert Id to Update Data : ");

                    // mencari data sesuai dengan id di database
                    var getData = _context.Items.Find(Convert.ToInt16(Console.ReadLine()));

                    // pengecekan data di database
                    if (getData == null)
                    {
                        // jika tidak ada, maka akan menampilkan seperti berikut
                        Console.Write("Sorry, your data is not found");
                        Console.Read();
                    }
                    else
                    {
                        // jika ada, maka akan mengubah status isDelete dan akan disimpan di database
                        getData.IsDelete = true;
                        getData.DeleteDate = DateTimeOffset.Now.LocalDateTime;

                        result = _context.SaveChanges();
                        if (result > 0)
                        {
                            Console.Write("Delete Successfully");
                            Console.Read();
                        }
                        else
                        {
                            Console.Write("Delete Failed");
                            Console.Read();
                        }
                    }
                    break;
                case 4:
                    var getDatatoDisplay = _context.Items.Where(x => x.IsDelete == false).ToList();

                    if (getDatatoDisplay.Count == 0)
                    {
                        Console.Write("No Data in your Database");
                        Console.Read();
                    }
                    else
                    {
                        foreach (var tampilin in getDatatoDisplay)
                        {
                            Console.WriteLine("============================");
                            Console.WriteLine("Name      : " + tampilin.Name);
                            Console.WriteLine("Price     : " + tampilin.Price);
                            Console.WriteLine("Stock     : " + tampilin.Stock);
                            Console.WriteLine("Supplier  : " + tampilin.Suppliers.Name);
                            Console.WriteLine("============================");
                        }
                        Console.WriteLine("");
                        Console.Write("Total Item " + getDatatoDisplay.Count);
                        Console.Read();
                    }
                    break;
                default:
                    Console.Write("Something Wrong, Please try again next time.");
                    break;
            }
        }
    }
}
