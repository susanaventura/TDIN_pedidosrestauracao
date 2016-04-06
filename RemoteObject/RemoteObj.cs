using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting;


namespace RemoteObject
{

    public interface IRemoteObj
    {

        List<Order> getOrders();
        List<string> getTables();
        SortedDictionary<int, MenuItem> getMenu();
        void getTableBill(int destTable);


        void setOrderStatus(int order, OrderStatus s);

        void addOrder(Order o);

        void ping(string name);
    }



    
    public enum RoomType
    {
        Bar = 'b',
        Kitchen = 'k'
    }

    public enum OrderStatus
    {
        Waiting = 'w',
        Processing = 'p',
        Done = 'd'
    }

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

    [Serializable]
    public class Order
    {
        public int Id { get; set; }
        public int Qnt { get; set; }
        public int DestTable { get; set; }
        public OrderStatus Status { get; set; }
        public int Item { get; set; }

        static int idCounter = 0;
        public Order(int qnt, int destTable, int item)
        {
            this.Id = Order.idCounter++;
            this.Qnt = qnt;
            this.DestTable = destTable;
            this.Item = item;
        }

        public override string ToString()
        {
            return "<" + Id + "> "
                + "qnt=" + Qnt
                + ", destTable= " + DestTable //server.getTables().ElementAt(DestTable) +
                + ", order=" + Item //server.getMenu()[Item].Description;
                ;
        }

    }


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
}
