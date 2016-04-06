using System;
using System.Runtime.Remoting;
using System.Collections.Generic;
using RemoteObject;
using System.Linq;

class Server
{
    static void Main(string[] args)
    {
        RemotingConfiguration.Configure("Server.exe.config", false);
        Console.WriteLine("[Server]: Press return to exit");
        Console.ReadLine();
    }
}


public class RemoteObj : MarshalByRefObject, IRemoteObj
{
    List<Order> orders;
    SortedDictionary<int, MenuItem> menu;
    List<string> tables;

    public RemoteObj()
    {
        Console.WriteLine("[Register] Register created");

        // Orders
        orders = new List<Order>();

        // Menu
        menu = new SortedDictionary<int, MenuItem>();

        //kitchen
        AddToMenu(new MenuItem("Big Mac", RoomType.Kitchen, 5));

        //bar
        AddToMenu(new MenuItem("Milkshake", RoomType.Bar, 2));

        // Tables
        tables = new List<string>();

        for (int i = 0; i < 10; i++) { tables.Add("" + (i + 1)); }
    }

    private void AddToMenu(MenuItem item) { menu.Add(item.Id, item); }


    public List<Order> getOrders() { return orders; }
    public List<string> getTables() { return tables; }
    public SortedDictionary<int, MenuItem> getMenu() { return menu; }
    public void getTableBill(int destTable) { /*TODO*/ }


    public void setOrderStatus(int order, OrderStatus s)
    {
        orders.Where(o => o.Id == order).ToList().ForEach(updated_order => updated_order.Status = s);
    }

    public void addOrder(Order o)
    {
        orders.Add(o);

        Console.WriteLine("----- Orders list ------");
        for (int i = 0; i < orders.Count; i++)
        {
            Console.WriteLine(orders.ElementAt(i).ToString());
        }

    }

    public void ping(string name)
    {
        Console.WriteLine("[Register] " + name + " connected");
    }

}
