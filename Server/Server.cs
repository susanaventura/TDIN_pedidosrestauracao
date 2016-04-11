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
    List<bool> tables;

    public event OrderHandler UpdateOrder;

    public event TableHandler GetBill;
    public event TableHandler PayBill;

    public RemoteObj()
    {
        Console.WriteLine("[Register] Register created");

        // Orders
        orders = new List<Order>();

        // Menu
        menu = new SortedDictionary<int, MenuItem>();

            //kitchen
            AddToMenu(new MenuItem("Big Mac", RoomType.Kitchen, 5));
            AddToMenu(new MenuItem("Cheeseburger", RoomType.Kitchen, 3));
            AddToMenu(new MenuItem("Chicken Nuggets", RoomType.Kitchen, 2));
            AddToMenu(new MenuItem("Beef", RoomType.Kitchen, 8.5f));

            //bar
            AddToMenu(new MenuItem("Milkshake", RoomType.Bar, 2));
            AddToMenu(new MenuItem("Water", RoomType.Bar, 0.75f));
            AddToMenu(new MenuItem("Juice", RoomType.Bar, 1.5f));

        // Tables
        tables = new List<bool>();

        for (int i = 0; i < 10; i++) { tables.Add(true); }
    }

    public override object InitializeLifetimeService()  { return null; }


    private void AddToMenu(MenuItem item) { menu.Add(item.Id, item); }

    public List<Order> getOrders() { return orders; }
    public List<bool> getTables() { return tables; }
    public SortedDictionary<int, MenuItem> getMenu() { return menu; }
    

    public void addOrder(Order o)
    {
        if (o.Table < tables.Count && tables[o.Table])
        {
            o.NewId();
            orders.Add(o);
        }

       
        if (UpdateOrder != null) UpdateOrder(o);
        Console.WriteLine("[Register] New order: " + o.ToStringBill(menu));
    }

    public void setOrderStatus(Order order, OrderStatus s)
    {
        orders.Where(o => o.Id == order.Id).ToList().ForEach(updated_order => updated_order.Status = s);

        if (UpdateOrder != null) UpdateOrder(order);
        Console.WriteLine("[Register] Order status change: " + order.ToStringBill(menu));
    }


    public void getTableBill(int table) {
        Console.WriteLine("[Register] Bill for table " + (table+1));

        List<Order> tableOrders = orders.Where(o => o.Table == table).ToList();

        tables[table] = false;

        if (UpdateOrder != null) UpdateOrder(null);
        if (GetBill != null) GetBill(table, tableOrders);
    }

    public void payTableBill(int table) {
        Console.WriteLine("[Register] Invoice for table " + (table+1));

        List<Order> tableOrders = orders.Where(o => o.Table == table).ToList();        

        tables[table] = true;
        orders = orders.Where(o => o.Table != table).ToList();

        if (UpdateOrder != null) UpdateOrder(null);
        if (PayBill != null) PayBill(table, tableOrders);
    }



    public void ping(string name)
    {
        Console.WriteLine("[Register] " + name + " connected");
    }

}
