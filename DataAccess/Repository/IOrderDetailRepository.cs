using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject.Models;
namespace DataAccess.Repository
{
    public interface IOrderDetailRepository
    {
        IEnumerable<OrderDetail> GetOrderDetails();
        IEnumerable<OrderDetail> GetOrderDetailListByMemberID(int id);
        IEnumerable<OrderDetail> GetOrderDetailListByID(int id);
        OrderDetail GetOrderDetailByID(int? OrderID);
        OrderDetail GetOrderDetailByOrderAndProduct(int? OrderID, int? ProductID);
        void InsertOrderDetail(OrderDetail OrderDetail);
        void DeleteOrderDetail(int OrderID);
        void UpdateOrderDetail(OrderDetail OrderDetail);
        public double GetStatistic(IEnumerable<Order> id);
        public IEnumerable<OrderDetail> GetOrderDetailListByListOrder(IEnumerable<Order> id);
        public IEnumerable<OrderDetail> GetOrderDetailListByListOrder(List<Order> id);
    }
}
