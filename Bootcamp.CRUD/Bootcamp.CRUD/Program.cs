using Bootcamp.CRUD.Context;
using Bootcamp.CRUD.Controller;
using Bootcamp.CRUD.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.CRUD
{
    class Program
    {
        static void Main(string[] args)
        {
            SuppliersController callSupplier = new SuppliersController();
            ItemsController callItem = new ItemsController();

            Console.WriteLine("=========== Manage Data ============");
            Console.WriteLine("1. Item");
            Console.WriteLine("2. Supplier");
            Console.WriteLine("====================================");
            Console.Write("Going to : ");
            int chance = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("====================================");
            if(chance == 1)
            {
                callItem.ManageItem();
            }
            else if (chance == 2)
            {
                callSupplier.ManageSupplier();
            }
            else
            {
                Console.WriteLine("Something is wrong, please try again.");
                Console.Read();
            }
        }
    }
}
