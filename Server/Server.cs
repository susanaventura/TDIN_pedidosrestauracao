using System;
using System.Collections.Generic;
using System.Linq;

namespace Server
{
    public class Server : MarshalByRefObject
    {
        List<Order> orders;
        public static SortedDictionary<int, MenuItem> menu;

        public Server()
        {
            Console.WriteLine("[Register] Register created");
            orders = new List<Order>();

            /* Menu */
            int id = 1;
            menu = new SortedDictionary<int, MenuItem>();

            //kitchen
            menu.Add(id, new MenuItem(id++, "Big Mac", RoomType.Kitchen, 5));

            //bar
            menu.Add(id, new MenuItem(id++, "Milkshake", RoomType.Bar, 2));

        }


        public void setOrderStatus(int order, OrderStatus s)
        {
            orders.Where(o => o.Id == order).ToList().ForEach(updated_order => updated_order.Status = s);
        }

        public void addOrder(Order o)
        {
            orders.Add(o);
        }

        public List<Order> getOrders()
        {
            return orders;
        }

        public SortedDictionary<int, MenuItem> getMenu() { return menu; }

        public void getTableBill(int destTable) { }

        


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


    public class MenuItem
    {
        public int Id { get; set; }
        public String Description { get; set; }
        public RoomType Type { get; set; }
        public float Price { get; set; }

        public MenuItem(int id, String desc, RoomType type, float price)
        {
            this.Id = id;
            this.Description = desc;
            this.Type = type;
            this.Price = price;
        }

    }

    

    public class Order
    {
        public int Id { get; set; }
        public int Qnt { get; set; }
        public int DestTable { get; set; }
        public OrderStatus Status { get; set; }
        public int Item { get; set; }
    }

}
