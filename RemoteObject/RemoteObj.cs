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

        Boolean ping();
    }
}
