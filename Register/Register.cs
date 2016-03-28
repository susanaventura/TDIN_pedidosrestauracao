using System;
using System.Collections.Generic;
using System.Linq;

namespace Server
{
    public class Register : MarshalByRefObject
    {
        List<Order> orders;

        public Register()
        {
            orders = new List<Order>();
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


    public class Order
    {
        public int Id { get; set; }
        public String Description { get; set; }
        public String Qnt { get; set; }
        public Char DestTable { get; set; }
        public RoomType Type { get; set; }
        public float Price { get; set; }
        public OrderStatus Status { get; set; }

    }

}
