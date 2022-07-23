using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessObject.Models;
using DataAccess.Repository;

namespace eStore.Controllers
{
    public class OrderController : Controller
    {
        public IOrderRepository orderRepository;
        public IOrderDetailRepository orderDetailRepository;

        public OrderController()
        {
            this.orderRepository = new OrderRepository();
            this.orderDetailRepository = new OrderDetailRepository();
        }

        // GET: MemberController
        public ActionResult Index()
        {
            var list = orderRepository.GetOrders();
            return View(list);
        }

        public ActionResult OrderDetailsList(int id)
        {
            var list = orderDetailRepository.GetOrderDetailListByID(id);
            return View(list);
        }

        // GET: MemberController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var order = orderRepository.GetOrderByID(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // GET: MemberController/Details/5
        public ActionResult OrderDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var order = orderDetailRepository.GetOrderDetailByID(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // GET: MemberController/Create
        public ActionResult CreateOrder()
        {
            return View();
        }

        // POST: MemberController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrder(Order order)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    orderRepository.InsertOrder(order);
                }
                return RedirectToAction(nameof(CreateOrderDetail));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(order);
            }
        }

        // GET: MemberController/Create
        public ActionResult CreateOrderDetail()
        {
            return View();
        }

        // POST: MemberController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    orderDetailRepository.InsertOrderDetail(orderDetail);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(orderDetail);
            }
        }

        // GET: MemberController/Edit/5
        public ActionResult EditOrder(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var order = orderRepository.GetOrderByID(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // POST: MemberController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditOrder(int id, Order order)
        {
            try
            {
                if (id != order.OrderId)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    orderRepository.UpdateOrder(order);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }

        // GET: MemberController/Edit/5
        public ActionResult EditOrderDetail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var order = orderDetailRepository.GetOrderDetailByID(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // POST: MemberController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditOrderDetail(int id, OrderDetail orderDetail)
        {
            try
            {
                if (id != orderDetail.OrderId)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    orderDetailRepository.UpdateOrderDetail(orderDetail);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }

        // GET: MemberController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var order = orderRepository.GetOrderByID(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // POST: MemberController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                orderDetailRepository.DeleteOrderDetail(id);
                orderRepository.DeleteOrder(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }

        // GET: MemberController/Delete/5
        public ActionResult DeleteOrderDetail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var order = orderDetailRepository.GetOrderDetailByID(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // POST: MemberController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteOrderDetail(int id)
        {
            try
            {
                orderDetailRepository.DeleteOrderDetail(id);
                return RedirectToAction(nameof(OrderDetailsList));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }
    }
}
