using RemoteObject;
using System;
using System.Runtime.Remoting;
using System.Collections.Generic;

namespace Printer
{
    class PrinterProgram
    {
        static void Main(string[] args)
        {
            RemotingConfiguration.Configure("Printer.exe.config", false);

            Console.WriteLine("[Printer] connecting to Server...");
            IRemoteObj remote = (IRemoteObj)GetRemote.New(typeof(IRemoteObj));
            remote.ping("Printer");

            Intermediate inter = new Intermediate();
            inter.GetBill += PrintBill;
            inter.PayBill += PrintInvoice;

            remote.GetBill += inter.FireGetBill;
            remote.PayBill += inter.FirePayBill;
            
            Console.WriteLine("[Printer] connected. Press return to exit.");
            Console.ReadLine();
        }

        public static void PrintInvoice(int table, List<Order> orders)
        {
            
        }

        public static void PrintBill(int table, List<Order> orders)
        {
            throw new NotImplementedException();
        }
    }
}
