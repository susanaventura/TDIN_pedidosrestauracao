using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteObject
{

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
                +   "qnt=" + Qnt
                + ", destTable= " + DestTable //server.getTables().ElementAt(DestTable) +
                + ", order=" + Item //server.getMenu()[Item].Description;
                ;
        }

    }
}
