using RemoteObject;
using System;
using System.Runtime.Remoting;
using System.Collections.Generic;

namespace Printer
{
    class PrinterProgram
    {
        static IRemoteObj remote;
        static SortedDictionary<int, MenuItem> menu;

        static void Main(string[] args)
        {
            RemotingConfiguration.Configure("Printer.exe.config", false);

            Console.WriteLine("[Printer] connecting to Server...");
            remote = (IRemoteObj)GetRemote.New(typeof(IRemoteObj));
            remote.ping("Printer");

            Intermediate inter = new Intermediate();
            inter.GetBill += PrintBill;
            inter.PayBill += PrintInvoice;

            remote.GetBill += inter.FireGetBill;
            remote.PayBill += inter.FirePayBill;

            menu = remote.getMenu();

            Console.WriteLine("[Printer] connected. Press return to exit.");
            Console.ReadLine();
        }

        public static void PrintInvoice(int table, List<Order> orders) { PrintList("Invoice", table, orders); }
        public static void PrintBill(int table, List<Order> orders) { PrintList("Bill", table, orders); }

        
        static void PrintList(string name, int table, List<Order> orders) {
            float total = 0;
            string header = "----- " + name + " for table " + (table + 1) + " ------";
            Console.WriteLine(header);
            for (int i = 0; i < orders.Count; i++)
            {
                Console.WriteLine(orders[i].ToString(menu));
                total += orders[i].GetPrice(menu);
            }
            Console.WriteLine("Total: " + total + " euro(s)");
            Console.WriteLine(new String('-', header.Length));
        }
    }
}
