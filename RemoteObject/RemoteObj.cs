using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting;


namespace RemoteObject
{

    public delegate void OrderHandler(Order order);
    public delegate void TableHandler(int table, List<Order> orders);

    #region Interface
    public interface IRemoteObj
    {
        event OrderHandler UpdateOrder;
        event TableHandler GetBill;
        event TableHandler PayBill;

        List<Order> getOrders();
        List<bool> getTables();
        SortedDictionary<int, MenuItem> getMenu();
        SortedDictionary<int, int> getSales();

        void addOrder(Order o);
        void setOrderStatus(Order order, OrderStatus s);

        void getTableBill(int destTable);
        void payTableBill(int destTable);

        void connect(string name);
    }
    #endregion

    #region Intermediate
    public class Intermediate : MarshalByRefObject {
        public event OrderHandler UpdateOrder;
        public event TableHandler GetBill;
        public event TableHandler PayBill;

        public void FireUpdateOrder(Order order) { UpdateOrder(order); }
        public void FireGetBill(int table, List<Order> orders) { GetBill(table, orders); }
        public void FirePayBill(int table, List<Order> orders) { PayBill(table, orders); }
    }
    #endregion

    #region Objects
    public enum RoomType { Bar, Kitchen }

    public enum OrderStatus { Waiting, Processing, Done }

    [Serializable]
    public class MenuItem
    {
        public int Id { get; set; }
        public String Description { get; set; }
        public RoomType Type { get; set; }
        public float Price { get; set; }

        static int idCounter = 0;
        public MenuItem(String desc, RoomType type, float price)
        {
            this.Id = MenuItem.idCounter++;
            this.Description = desc;
            this.Type = type;
            this.Price = price;
        }
    }
    #endregion

    #region Order
    [Serializable]
    public class Order
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int Table { get; set; }
        public OrderStatus Status { get; set; }
        public int Item { get; set; }

        private string orderDescription;

        static int idCounter = 0;
        public Order(int qnt, int table, int item, string itemDescription)
        {
            NewId();
            this.Quantity = qnt;
            this.Table = table;
            this.Item = item;
            this.orderDescription = Quantity + "x " + itemDescription + " to table " + (table + 1);
        }

        public void NewId() { Id = Order.idCounter++; }

        public override string ToString()
        {
            return "<" + Id + "> "
                + "qnt=" + Quantity
                + ", table= " + Table //server.getTables().ElementAt(DestTable) +
                + ", order=" + Item //server.getMenu()[Item].Description;
                ;
        }

        public float GetPrice(SortedDictionary<int, MenuItem> menu)
        {
            return Quantity * menu[Item].Price;
        }

        public string ToStringStatus(SortedDictionary<int, MenuItem> menu)
        {
            MenuItem item = menu[Item];

            return Quantity + "x "+ item.Description 
                + " from " + item.Type.ToString() 
                + " to table " + (Table+1) 
                + ": " + Status.ToString();
        }

        public string ToStringBill(SortedDictionary<int, MenuItem> menu)
        {
            MenuItem item = menu[Item];

            return Quantity+"x "
                + item.Description + " - "
                + item.Price + " euro(s) - total:"
                + GetPrice(menu) + " euro(s)";
        }


        public string OrderDescription
        {
            get{
                return orderDescription;
            }
        }

    }
    #endregion

    #region GetRemote

    public class GetRemote
    {
        private static IDictionary wellKnownTypes;

        public static object New(Type type)
        {
            if (wellKnownTypes == null)
                InitTypeCache();
            WellKnownClientTypeEntry entry = (WellKnownClientTypeEntry)wellKnownTypes[type];
            if (entry == null)
                throw new RemotingException("Type not found!");
            return Activator.GetObject(type, entry.ObjectUrl);
        }

        public static void InitTypeCache()
        {
            Hashtable types = new Hashtable();
            foreach (WellKnownClientTypeEntry entry in RemotingConfiguration.GetRegisteredWellKnownClientTypes())
            {
                if (entry.ObjectType == null)
                    throw new RemotingException("A configured type could not be found!");
                types.Add(entry.ObjectType, entry);
            }
            wellKnownTypes = types;
        }
    }
    #endregion

    #region Aux
    public class UIKeyValuePair
    {
        public int Key { get; set; }
        public string Value { get; set; }

        public UIKeyValuePair(int key, string value)
        {
            this.Key = key;
            this.Value = value;
        }

        public override string ToString()
        {
            return Value;
        }
    }
    #endregion
}
