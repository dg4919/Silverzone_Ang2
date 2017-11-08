using System;
using System.Collections.Generic;
using Silverzone.Entities;

namespace Silverzone.Data
{
    public interface IOrderRepository:IRepository<Order>
    {
        Order GetById(int id);
        IEnumerable<Order> GetByuserId(int userId);
        Order GetByOrderNumber(string id);
        IEnumerable<Order> GetByOrderDate(DateTime orderDate);
        string get_Order_Number(int orderId);

        bool sendEmail_Payment_Confirmation(string emailTemplate, string emailId);
        bool send_sms_orderConfirmation(string mobileNo, string orderNumber, decimal orderAmount, string orderTrackLink);

        Order GetByuser_andOrderId(int orderId, int userId);

    }
}
