using System;
using System.Runtime.Remoting;
using System.Collections.Generic;
using RemoteObject;
using System.Linq;

public class Server
{
    static void Main(string[] args)
    {
        RemotingConfiguration.Configure("Server.exe.config", false);
        Console.WriteLine("[Server] Press return to exit");
        Console.ReadLine();
    }

    public static IRemoteObj RemoteConnect(string name) {
        try
        {
            Console.WriteLine("[" + name + "] connecting to Server...");

            IRemoteObj remote = (IRemoteObj)GetRemote.New(typeof(IRemoteObj));
            remote.connect(name);

            Console.WriteLine("[" + name + "] connected.");
            return remote;
        }
        catch (System.Net.Sockets.SocketException)
        {
            Console.WriteLine("[" + name + "] connection failed!");
            return null;
        }
    }
}

public class RemoteObj : MarshalByRefObject, IRemoteObj
{
    #region events
    public event OrderHandler UpdateOrder;

    public event TableHandler GetBill;
    public event TableHandler PayBill;
    #endregion

    #region state_init

    List<Order> orders;
    SortedDictionary<int, MenuItem> menu;
    SortedDictionary<int, int> sales;
    List<bool> tables;

    public RemoteObj()
    {
        Console.WriteLine("[Server] Register created.");

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

        //Sales
        sales = new SortedDictionary<int, int>();
        foreach (int item in menu.Keys) { sales[item] = 0; }

        for (int i = 0; i < 10; i++) { tables.Add(true); }
    }
    private void AddToMenu(MenuItem item) { menu.Add(item.Id, item); }

    public override object InitializeLifetimeService() { return null; }
    #endregion

    #region interface_methods

    public List<Order> getOrders() { return orders; }
    public List<bool> getTables() { return tables; }
    public SortedDictionary<int, MenuItem> getMenu() { return menu; }
    public SortedDictionary<int, int> getSales() { return sales; }

    // Add Order
    public void addOrder(Order o)
    {
        if (o.Table < tables.Count 
            && tables[o.Table] 
            && o.Quantity > 0 
            && menu.ContainsKey(o.Item))
        {
            o.NewId();
            orders.Add(o);
        }

       
        if (UpdateOrder != null) UpdateOrder(o);
        Console.WriteLine("[Server] New order: " + o.ToStringBill(menu));
    }

    // Set Order Status
    public void setOrderStatus(Order order, OrderStatus s)
    {
        orders.Where(o => o.Id == order.Id).ToList().ForEach(updated_order => updated_order.Status = s);

        if (UpdateOrder != null) UpdateOrder(order);
        Console.WriteLine("[Server] Order status change: " + order.ToStringBill(menu));
    }

    // Get Table Bill (consulta de mesa)
    public void getTableBill(int table) {
        List<Order> tableOrders = orders.Where(o => o.Table == table).ToList();

        tables[table] = false;

        if (UpdateOrder != null) UpdateOrder(null);
        if (GetBill != null) GetBill(table, tableOrders);
        Console.WriteLine("[Server] Bill for table " + (table + 1));
    }

    // Pay Table Bill (emissao de fatura)
    public void payTableBill(int table) {
        Console.WriteLine("[Server] Invoice for table " + (table+1));

        List<Order> tableOrders = orders.Where(o => o.Table == table).ToList();        

        tables[table] = true;
        foreach(Order o in tableOrders) { sales[o.Item] += o.Quantity; }
        orders = orders.Where(o => o.Table != table).ToList();
        

        if (UpdateOrder != null) UpdateOrder(null);
        if (PayBill != null) PayBill(table, tableOrders);
    }

    // Connect
    public void connect(string name)
    {
        Console.WriteLine("[Server] " + name + " connected");
    }

    #endregion
}
